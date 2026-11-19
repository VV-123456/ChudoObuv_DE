using ChudoObuv.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class OrderDetailsForm : Form
    {
        private int orderId;

        public OrderDetailsForm(int id)
        {
            InitializeComponent();
            this.orderId = id;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Состав заказа");
            if (btnClose != null)
            {
                StyleHelper.StyleSecondaryButton(btnClose);
            }

            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.ReadOnly = true;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string sql = @"
                SELECT p.name AS [Товар], 
                       m.name AS [Производство], 
                       s.value AS [Размер], 
                       oi.quantity AS [Кол-во], 
                       oi.unit_price AS [Цена (₽)], 
                       (oi.quantity * oi.unit_price) AS [Сумма (₽)]
                FROM OrderItem oi
                JOIN StockItem si ON si.id = oi.stock_item_id
                JOIN Product p ON p.id = si.product_id
                JOIN Manufacturer m ON m.id = p.manufacturer_id
                JOIN Size s ON s.id = si.size_id
                WHERE oi.order_id = @oid";

            dgvDetails.DataSource = DbHelper.Query(sql, new SqlParameter("@oid", orderId));

            if (dgvDetails.Columns["Товар"] != null) dgvDetails.Columns["Товар"].FillWeight = 160;
            if (dgvDetails.Columns["Производство"] != null) dgvDetails.Columns["Производство"].FillWeight = 120;
            if (dgvDetails.Columns["Размер"] != null) dgvDetails.Columns["Размер"].FillWeight = 65;
            if (dgvDetails.Columns["Кол-во"] != null) dgvDetails.Columns["Кол-во"].FillWeight = 65;
            if (dgvDetails.Columns["Цена (₽)"] != null) dgvDetails.Columns["Цена (₽)"].FillWeight = 85;
            if (dgvDetails.Columns["Сумма (₽)"] != null) dgvDetails.Columns["Сумма (₽)"].FillWeight = 85;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
