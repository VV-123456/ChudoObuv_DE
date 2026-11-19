using ChudoObuv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChudoObuv
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblFio.Text = CurrentUser.FullName + " (" + CurrentUser.Role + ")";

            if (CurrentUser.Role != "Администратор" && CurrentUser.Role != "Менеджер")
            {
                btnOrders.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            CatalogForm cf = new CatalogForm();
            cf.ShowDialog();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cf = new CartForm();
            cf.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm of = new OrdersForm();
            of.ShowDialog();
        }
    }
}
