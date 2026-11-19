using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Корзина (Оформление заказа)");
            StyleHelper.StyleAccentButton(btnOrder);
            StyleHelper.StyleSecondaryButton(btnRemove);
            StyleHelper.StyleSecondaryButton(btnClose);

            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = Cart.Items.ToList();

            if (dgvCart.Columns["StockItemId"] != null) dgvCart.Columns["StockItemId"].Visible = false;
            if (dgvCart.Columns["ProductName"] != null) dgvCart.Columns["ProductName"].HeaderText = "Наименование";
            if (dgvCart.Columns["Price"] != null) dgvCart.Columns["Price"].HeaderText = "Цена (₽)";
            if (dgvCart.Columns["Size"] != null) dgvCart.Columns["Size"].HeaderText = "Размер";
            if (dgvCart.Columns["Quantity"] != null) dgvCart.Columns["Quantity"].HeaderText = "Кол-во";
            if (dgvCart.Columns["Total"] != null) dgvCart.Columns["Total"].HeaderText = "Сумма (₽)";

            decimal totalSum = Cart.Items.Sum(i => i.Total);
            lblTotal.Text = $"Итого к оплате:\n{totalSum:N2} ₽";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Выберите позицию для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = (CartItem)dgvCart.CurrentRow.DataBoundItem;
            Cart.Items.Remove(item);
            RefreshCart();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста. Добавьте товары из каталога.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] fioParts = (CurrentUser.FullName ?? "").Split(' ');
            string lastName = fioParts.Length > 0 ? fioParts[0] : "Клиент";
            string firstName = fioParts.Length > 1 ? fioParts[1] : "";
            string middleName = fioParts.Length > 2 ? fioParts[2] : "";

            try
            {
                var maxDt = DbHelper.Query("SELECT ISNULL(MAX(order_number), 0) + 1 FROM [Order]");
                int nextOrderNum = Convert.ToInt32(maxDt.Rows[0][0]);

                var orderDt = DbHelper.Query(
                    @"INSERT INTO [Order] (order_number, order_date, customer_last_name, customer_first_name, customer_middle_name)
                      OUTPUT INSERTED.id
                      VALUES (@num, @dt, @ln, @fn, @mn)",
                    new SqlParameter("@num", nextOrderNum),
                    new SqlParameter("@dt", DateTime.Today),
                    new SqlParameter("@ln", lastName),
                    new SqlParameter("@fn", firstName),
                    new SqlParameter("@mn", middleName));

                int newOrderId = Convert.ToInt32(orderDt.Rows[0][0]);

                foreach (var item in Cart.Items)
                {
                    DbHelper.Execute(
                        "INSERT INTO OrderItem (order_id, stock_item_id, quantity, unit_price) VALUES (@oid, @sid, @qty, @price)",
                        new SqlParameter("@oid", newOrderId),
                        new SqlParameter("@sid", item.StockItemId),
                        new SqlParameter("@qty", item.Quantity),
                        new SqlParameter("@price", item.Price));

                    DbHelper.Execute(
                        "UPDATE StockItem SET quantity = quantity - @qty WHERE id = @sid",
                        new SqlParameter("@qty", item.Quantity),
                        new SqlParameter("@sid", item.StockItemId));
                }

                Cart.Items.Clear();
                MessageBox.Show($"Заказ № {nextOrderNum} успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при оформлении заказа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
