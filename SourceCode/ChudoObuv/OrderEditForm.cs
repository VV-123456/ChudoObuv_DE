using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class OrderEditForm : Form
    {
        private int orderId;

        public OrderEditForm(int id)
        {
            InitializeComponent();
            this.orderId = id;
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Редактирование заказа");
            StyleHelper.StyleAccentButton(btnSave);
            StyleHelper.StyleAccentButton(btnAddToOrder);
            StyleHelper.StyleSecondaryButton(btnRemoveItem);
            StyleHelper.StyleSecondaryButton(btnClose);

            dgvItems.BackgroundColor = Color.White;
            txtLastName.BackColor = StyleHelper.SecondaryBg;
            txtFirstName.BackColor = StyleHelper.SecondaryBg;
            txtMiddleName.BackColor = StyleHelper.SecondaryBg;

            LoadOrderInfo();
            LoadItems();

            var products = DbHelper.Query("SELECT id, name FROM Product ORDER BY name");
            cmbAddProduct.DisplayMember = "name";
            cmbAddProduct.ValueMember = "id";
            cmbAddProduct.DataSource = products;
        }

        private void LoadOrderInfo()
        {
            var dt = DbHelper.Query("SELECT * FROM [Order] WHERE id = @id", new SqlParameter("@id", orderId));
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblOrderTitle.Text = "Заказ № " + row["order_number"];
                txtLastName.Text = row["customer_last_name"].ToString();
                txtFirstName.Text = row["customer_first_name"].ToString();
                txtMiddleName.Text = row["customer_middle_name"].ToString();

                if (dtpOrderDate != null && row["order_date"] != DBNull.Value)
                {
                    dtpOrderDate.Value = Convert.ToDateTime(row["order_date"]);
                }
            }
        }

        private void LoadItems()
        {
            string sql = @"
                SELECT oi.id, oi.stock_item_id, p.name AS [Товар], s.value AS [Размер], 
                       oi.quantity AS [Кол-во], oi.unit_price AS [Цена],
                       (oi.quantity * oi.unit_price) AS [Сумма]
                FROM OrderItem oi
                JOIN StockItem si ON si.id = oi.stock_item_id
                JOIN Product p ON p.id = si.product_id
                JOIN Size s ON s.id = si.size_id
                WHERE oi.order_id = @oid";

            dgvItems.DataSource = DbHelper.Query(sql, new SqlParameter("@oid", orderId));
            if (dgvItems.Columns["id"] != null) dgvItems.Columns["id"].Visible = false;
            if (dgvItems.Columns["stock_item_id"] != null) dgvItems.Columns["stock_item_id"].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Фамилия и имя клиента не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime newDate = dtpOrderDate != null ? dtpOrderDate.Value.Date : DateTime.Today;
                DbHelper.Execute(
                    @"UPDATE [Order] 
                      SET order_date = @dt, customer_last_name = @ln, customer_first_name = @fn, customer_middle_name = @mn 
                      WHERE id = @id",
                    new SqlParameter("@dt", newDate),
                    new SqlParameter("@ln", txtLastName.Text.Trim()),
                    new SqlParameter("@fn", txtFirstName.Text.Trim()),
                    new SqlParameter("@mn", txtMiddleName.Text.Trim()),
                    new SqlParameter("@id", orderId));

                MessageBox.Show("Данные и дата заказа успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow == null) return;

            int itemId = Convert.ToInt32(dgvItems.CurrentRow.Cells["id"].Value);
            int stockItemId = Convert.ToInt32(dgvItems.CurrentRow.Cells["stock_item_id"].Value);
            int qty = Convert.ToInt32(dgvItems.CurrentRow.Cells["Кол-во"].Value);

            var result = MessageBox.Show("Удалить выбранную позицию из заказа? Остаток вернется на склад.",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DbHelper.Execute("DELETE FROM OrderItem WHERE id = @id", new SqlParameter("@id", itemId));
                DbHelper.Execute("UPDATE StockItem SET quantity = quantity + @qty WHERE id = @sid",
                    new SqlParameter("@qty", qty), new SqlParameter("@sid", stockItemId));
                LoadItems();
            }
        }

        private void cmbAddProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddProduct.SelectedValue == null) return;
            int productId = Convert.ToInt32(cmbAddProduct.SelectedValue);
            var sizes = DbHelper.Query(
                "SELECT si.id, s.value FROM StockItem si JOIN Size s ON s.id = si.size_id WHERE si.product_id = @pid AND si.quantity > 0",
                new SqlParameter("@pid", productId));
            cmbAddSize.DisplayMember = "value";
            cmbAddSize.ValueMember = "id";
            cmbAddSize.DataSource = sizes;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (cmbAddProduct.SelectedValue == null || cmbAddSize.SelectedValue == null) return;
            int stockItemId = Convert.ToInt32(cmbAddSize.SelectedValue);
            int qty = (int)numAddQty.Value;

            var stockDt = DbHelper.Query(
                "SELECT si.quantity, p.price FROM StockItem si JOIN Product p ON p.id = si.product_id WHERE si.id = @sid",
                new SqlParameter("@sid", stockItemId));

            if (stockDt.Rows.Count == 0) return;
            int available = Convert.ToInt32(stockDt.Rows[0]["quantity"]);
            decimal price = Convert.ToDecimal(stockDt.Rows[0]["price"]);

            if (qty <= 0 || qty > available)
            {
                MessageBox.Show($"Доступно для заказа только {available} шт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbHelper.Execute(
                "INSERT INTO OrderItem(order_id, stock_item_id, quantity, unit_price) VALUES (@oid, @sid, @qty, @price)",
                new SqlParameter("@oid", orderId),
                new SqlParameter("@sid", stockItemId),
                new SqlParameter("@qty", qty),
                new SqlParameter("@price", price));

            DbHelper.Execute("UPDATE StockItem SET quantity = quantity - @qty WHERE id = @sid",
                new SqlParameter("@qty", qty), new SqlParameter("@sid", stockItemId));

            LoadItems();
            MessageBox.Show("Товар добавлен в заказ!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
