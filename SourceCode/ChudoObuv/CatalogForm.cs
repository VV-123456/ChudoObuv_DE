using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Каталог товаров");
            StyleHelper.StyleAccentButton(btnDetails);
            StyleHelper.StyleAccentButton(btnCart);
            StyleHelper.StyleSecondaryButton(btnOrders);
            StyleHelper.StyleSecondaryButton(btnLogout);

            txtSearch.BackColor = StyleHelper.SecondaryBg;
            dgvCatalog.BackgroundColor = Color.White;

            string logoPath = Path.Combine(Application.StartupPath, "images", "Чудо Обувь.png");
            if (File.Exists(logoPath) && picLogo != null)
            {
                picLogo.Image = Image.FromFile(logoPath);
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }

            bool isGuest = CurrentUser.Role == "Гость" || string.IsNullOrEmpty(CurrentUser.Login);
            lblUserFio.Text = isGuest ? "Гость" : $"{CurrentUser.FullName} ({CurrentUser.Role})";

            pnlFilters.Visible = !isGuest;
            btnCart.Visible = !isGuest;
            btnOrders.Visible = (CurrentUser.Role == "Администратор" || CurrentUser.Role == "Менеджер");

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все категории");
            var cats = DbHelper.Query("SELECT DISTINCT name FROM Category ORDER BY name");
            foreach (DataRow r in cats.Rows)
            {
                cmbCategory.Items.Add(r["name"].ToString());
            }
            cmbCategory.SelectedIndex = 0;

            cmbSort.Items.Clear();
            cmbSort.Items.Add("Без сортировки");
            cmbSort.Items.Add("Цена: по возрастанию");
            cmbSort.Items.Add("Цена: по убыванию");
            cmbSort.SelectedIndex = 0;

            LoadData();
            UpdateCartButton();
        }

        private void LoadData()
        {
            DateTime firstDayCurrent = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime prevStart = firstDayCurrent.AddMonths(-1);
            DateTime prevEnd = firstDayCurrent.AddDays(-1);

            string catFilter = (cmbCategory.SelectedItem == null || cmbCategory.SelectedItem.ToString() == "Все категории")
                ? ""
                : " AND c.name = @cat ";

            string orderBy = " ORDER BY p.name ASC ";
            if (cmbSort.SelectedIndex == 1) orderBy = " ORDER BY [Цена со скидкой] ASC ";
            else if (cmbSort.SelectedIndex == 2) orderBy = " ORDER BY [Цена со скидкой] DESC ";

            string sql = $@"
                SELECT p.id,
                       p.name AS [Наименование],
                       c.name AS [Категория],
                       m.name AS [Производство],
                       p.price AS [Базовая цена],
                       CASE WHEN (
                           SELECT COUNT(*) FROM OrderItem oi
                           JOIN [Order] o ON o.id = oi.order_id
                           JOIN StockItem si2 ON si2.id = oi.stock_item_id
                           WHERE si2.product_id = p.id AND o.order_date BETWEEN @prevStart AND @prevEnd
                       ) = 0 THEN ROUND(p.price * 0.75, 2) ELSE p.price END AS [Цена со скидкой],
                       CASE WHEN ISNULL(SUM(si.quantity), 0) > 5 THEN N'много' ELSE N'мало' END AS [Наличие],
                       ISNULL(SUM(si.quantity), 0) AS [Остаток],
                       p.image_path
                FROM Product p
                JOIN Subcategory s ON s.id = p.subcategory_id
                JOIN Category c ON c.id = s.category_id
                JOIN Manufacturer m ON m.id = p.manufacturer_id
                LEFT JOIN StockItem si ON si.product_id = p.id
                WHERE (p.name LIKE @search OR p.description LIKE @search) {catFilter}
                GROUP BY p.id, p.name, c.name, m.name, p.price, p.image_path
                {orderBy}";

            dgvCatalog.DataSource = DbHelper.Query(sql,
                new SqlParameter("@search", "%" + txtSearch.Text.Trim() + "%"),
                new SqlParameter("@cat", cmbCategory.SelectedItem?.ToString() ?? ""),
                new SqlParameter("@prevStart", prevStart),
                new SqlParameter("@prevEnd", prevEnd));

            if (dgvCatalog.Columns["id"] != null) dgvCatalog.Columns["id"].Visible = false;
            if (dgvCatalog.Columns["image_path"] != null) dgvCatalog.Columns["image_path"].Visible = false;
        }

        private void dgvCatalog_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var cellVal = dgvCatalog.Rows[e.RowIndex].Cells["Остаток"].Value;
            if (cellVal != null && int.TryParse(cellVal.ToString(), out int qty))
            {
                if (qty <= 3)
                    dgvCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = StyleHelper.LowStockColor;
                else
                    dgvCatalog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvCatalog_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCatalog.CurrentRow == null) return;
            string imgName = dgvCatalog.CurrentRow.Cells["image_path"].Value?.ToString();
            picProduct.Image = StyleHelper.LoadProductImage(imgName);
        }

        private void OpenSelectedProduct()
        {
            if (dgvCatalog.CurrentRow == null) return;
            int productId = Convert.ToInt32(dgvCatalog.CurrentRow.Cells["id"].Value);
            decimal finalPrice = Convert.ToDecimal(dgvCatalog.CurrentRow.Cells["Цена со скидкой"].Value);

            ProductForm pf = new ProductForm(productId, finalPrice);
            pf.ShowDialog();
            LoadData();
            UpdateCartButton();
        }

        private void UpdateCartButton()
        {
            int count = Cart.Items.Sum(x => x.Quantity);
            btnCart.Text = count > 0 ? $"Корзина ({count})" : "Корзина";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        private void dgvCatalog_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => OpenSelectedProduct();
        private void btnDetails_Click(object sender, EventArgs e) => OpenSelectedProduct();

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cf = new CartForm();
            cf.ShowDialog();
            LoadData();
            UpdateCartButton();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm of = new OrdersForm();
            of.ShowDialog();
            LoadData();
        }

        private void btnLogout_Click(object sender, EventArgs e) => this.Close();
    }
}
