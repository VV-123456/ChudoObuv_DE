namespace ChudoObuv
{
    partial class CatalogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            cmbCategory = new ComboBox();
            btnDetails = new Button();
            dgvCatalog = new DataGridView();
            picLogo = new PictureBox();
            lblUserFio = new Label();
            pnlFilters = new Panel();
            cmbSort = new ComboBox();
            picProduct = new PictureBox();
            btnLogout = new Button();
            btnCart = new Button();
            btnOrders = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(151, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 46);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(414, 313);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(151, 42);
            btnDetails.TabIndex = 2;
            btnDetails.Text = "Открыть товар";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // dgvCatalog
            // 
            dgvCatalog.AllowUserToAddRows = false;
            dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalog.Location = new Point(12, 65);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.ReadOnly = true;
            dgvCatalog.RowHeadersWidth = 51;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(776, 234);
            dgvCatalog.TabIndex = 3;
            dgvCatalog.CellDoubleClick += dgvCatalog_CellDoubleClick;
            dgvCatalog.SelectionChanged += dgvCatalog_SelectionChanged;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(12, 9);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(50, 50);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // lblUserFio
            // 
            lblUserFio.AutoSize = true;
            lblUserFio.Location = new Point(466, 9);
            lblUserFio.Name = "lblUserFio";
            lblUserFio.Size = new Size(142, 20);
            lblUserFio.TabIndex = 5;
            lblUserFio.Text = "ФИО пользователя";
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(cmbSort);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(cmbCategory);
            pnlFilters.Location = new Point(12, 313);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(179, 150);
            pnlFilters.TabIndex = 6;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(12, 80);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(151, 28);
            cmbSort.TabIndex = 2;
            cmbSort.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // picProduct
            // 
            picProduct.Location = new Point(213, 313);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(180, 150);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 7;
            picProduct.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(586, 361);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(151, 40);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnCart
            // 
            btnCart.AllowDrop = true;
            btnCart.Location = new Point(586, 313);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(151, 42);
            btnCart.TabIndex = 9;
            btnCart.Text = "Корзина";
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(414, 361);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(151, 40);
            btnOrders.TabIndex = 10;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // CatalogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 465);
            Controls.Add(btnOrders);
            Controls.Add(btnCart);
            Controls.Add(btnLogout);
            Controls.Add(picProduct);
            Controls.Add(pnlFilters);
            Controls.Add(lblUserFio);
            Controls.Add(picLogo);
            Controls.Add(dgvCatalog);
            Controls.Add(btnDetails);
            Name = "CatalogForm";
            Text = "Чудо Обувь - Каталог";
            Load += CatalogForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private Button btnDetails;
        private DataGridView dgvCatalog;
        private PictureBox picLogo;
        private Label lblUserFio;
        private Panel pnlFilters;
        private ComboBox cmbSort;
        private PictureBox picProduct;
        private Button btnLogout;
        private Button btnCart;
        private Button btnOrders;
    }
}