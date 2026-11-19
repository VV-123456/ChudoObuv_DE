using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class ProductForm : Form
    {
        private int productId;
        private decimal actualPrice;
        private Dictionary<string, int> sizeStockMap = new Dictionary<string, int>();

        public ProductForm(int id, decimal priceWithDiscount)
        {
            InitializeComponent();
            this.productId = id;
            this.actualPrice = priceWithDiscount;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Карточка товара");
            StyleHelper.StyleAccentButton(btnAddToCart);
            StyleHelper.StyleSecondaryButton(btnClose);

            bool isGuest = (CurrentUser.Role == "Гость" || string.IsNullOrEmpty(CurrentUser.Login));
            cmbSizes.Visible = !isGuest;
            numQty.Visible = !isGuest;
            btnAddToCart.Visible = !isGuest;

            var dt = DbHelper.Query(
                @"SELECT p.name, p.description, p.composition, p.image_path,
                         c.name AS category, m.name AS manufacturer
                  FROM Product p
                  JOIN Subcategory s ON s.id = p.subcategory_id
                  JOIN Category c ON c.id = s.category_id
                  JOIN Manufacturer m ON m.id = p.manufacturer_id
                  WHERE p.id = @id",
                new SqlParameter("@id", productId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblName.Text = $"{row["manufacturer"]} | {row["name"]}";
                lblPrice.Text = $"Цена: {actualPrice:N2} ₽";

                var allSizesDt = DbHelper.Query("SELECT value FROM Size ORDER BY value");
                var allSizesList = new List<string>();
                foreach (DataRow sr in allSizesDt.Rows)
                {
                    allSizesList.Add(sr["value"].ToString());
                }

                lblDescription.Text =
                    $"Категория: {row["category"]}\n\n" +
                    $"Состав: {row["composition"]}\n\n" +
                    $"Описание: {row["description"]}\n\n" +
                    $"Размерный ряд: {string.Join(", ", allSizesList)}";

                picProduct.Image = StyleHelper.LoadProductImage(row["image_path"].ToString());
                picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            }

            var sizes = DbHelper.Query(
                @"SELECT s.value, si.quantity 
                  FROM StockItem si 
                  JOIN Size s ON s.id = si.size_id 
                  WHERE si.product_id = @id AND si.quantity > 0 
                  ORDER BY s.value",
                new SqlParameter("@id", productId));

            cmbSizes.Items.Clear();
            sizeStockMap.Clear();

            foreach (DataRow r in sizes.Rows)
            {
                string display = $"{r["value"]} (в наличии: {r["quantity"]} шт.)";
                int qty = Convert.ToInt32(r["quantity"]);
                cmbSizes.Items.Add(display);
                sizeStockMap[display] = qty;
            }

            if (cmbSizes.Items.Count > 0)
            {
                cmbSizes.SelectedIndex = 0;
            }
            else
            {
                btnAddToCart.Enabled = false;
                btnAddToCart.Text = "Нет в наличии";
            }
        }

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSizes.SelectedItem == null) return;
            string key = cmbSizes.SelectedItem.ToString();
            if (sizeStockMap.ContainsKey(key))
            {
                numQty.Minimum = 1;
                numQty.Maximum = sizeStockMap[key];
                numQty.Value = 1;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbSizes.SelectedItem == null)
            {
                MessageBox.Show("Выберите доступный размер.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedText = cmbSizes.SelectedItem.ToString();
            int maxAvailable = sizeStockMap[selectedText];
            int qty = (int)numQty.Value;

            if (qty <= 0 || qty > maxAvailable)
            {
                MessageBox.Show($"Укажите количество от 1 до {maxAvailable} шт.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sizeValueStr = selectedText.Split(' ')[0];
            decimal sizeValue = decimal.Parse(sizeValueStr.Replace(',', '.'), CultureInfo.InvariantCulture);

            var dt = DbHelper.Query(
                @"SELECT si.id FROM StockItem si 
                  JOIN Size s ON s.id = si.size_id 
                  WHERE si.product_id = @pid AND s.value = @size",
                new SqlParameter("@pid", productId),
                new SqlParameter("@size", sizeValue));

            if (dt.Rows.Count == 0) return;
            int stockItemId = Convert.ToInt32(dt.Rows[0]["id"]);

            var existing = Cart.Items.Find(x => x.StockItemId == stockItemId);
            if (existing != null)
            {
                if (existing.Quantity + qty > maxAvailable)
                {
                    MessageBox.Show($"В корзине уже есть {existing.Quantity} шт. Всего доступно {maxAvailable} шт.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existing.Quantity += qty;
            }
            else
            {
                Cart.Items.Add(new CartItem
                {
                    StockItemId = stockItemId,
                    ProductName = lblName.Text,
                    Price = actualPrice,
                    Size = sizeValueStr,
                    Quantity = qty
                });
            }

            MessageBox.Show("Товар добавлен в заказ!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
