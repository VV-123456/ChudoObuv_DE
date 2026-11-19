using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Список заказов");
            StyleHelper.StyleAccentButton(btnDetails);
            StyleHelper.StyleSecondaryButton(btnDelete);
            StyleHelper.StyleAccentButton(btnEdit);
            StyleHelper.StyleSecondaryButton(btnClose);

            btnEdit.Visible = (CurrentUser.Role == "Администратор");

            LoadOrders();
        }

        private void LoadOrders()
        {
            string sql = @"
                SELECT o.id, 
                       o.order_number AS [№ заказа], 
                       o.order_date AS [Дата заказа],
                       LTRIM(RTRIM(CONCAT(o.customer_last_name, ' ', o.customer_first_name, ' ', o.customer_middle_name))) AS [ФИО клиента],
                       ISNULL(SUM(oi.quantity * oi.unit_price), 0) AS [Итоговая сумма (₽)]
                FROM [Order] o
                LEFT JOIN OrderItem oi ON oi.order_id = o.id
                GROUP BY o.id, o.order_number, o.order_date, o.customer_last_name, o.customer_first_name, o.customer_middle_name
                ORDER BY o.order_date DESC, o.order_number DESC";

            dgvOrders.DataSource = DbHelper.Query(sql);
            if (dgvOrders.Columns["id"] != null)
                dgvOrders.Columns["id"].Visible = false;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["id"].Value);

            OrderDetailsForm detailsForm = new OrderDetailsForm(orderId);
            StyleHelper.ApplyFormStyle(detailsForm, "Состав заказа");
            detailsForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["id"].Value);

            OrderEditForm editForm = new OrderEditForm(orderId);
            editForm.ShowDialog();
            LoadOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["id"].Value);
            string orderNum = dgvOrders.CurrentRow.Cells["№ заказа"].Value.ToString();

            var res = MessageBox.Show($"Удалить заказ № {orderNum}? Товары из заказа вернутся на склад.",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                try
                {
                    var items = DbHelper.Query("SELECT stock_item_id, quantity FROM OrderItem WHERE order_id = @oid",
                        new SqlParameter("@oid", orderId));

                    foreach (DataRow r in items.Rows)
                    {
                        DbHelper.Execute("UPDATE StockItem SET quantity = quantity + @qty WHERE id = @sid",
                            new SqlParameter("@qty", Convert.ToInt32(r["quantity"])),
                            new SqlParameter("@sid", Convert.ToInt32(r["stock_item_id"])));
                    }

                    DbHelper.Execute("DELETE FROM OrderItem WHERE order_id = @oid", new SqlParameter("@oid", orderId));
                    DbHelper.Execute("DELETE FROM [Order] WHERE id = @oid", new SqlParameter("@oid", orderId));

                    LoadOrders();
                    MessageBox.Show("Заказ успешно удалён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
