namespace ChudoObuv
{
    partial class OrderEditForm
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
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            btnSave = new Button();
            btnRemoveItem = new Button();
            btnClose = new Button();
            dgvItems = new DataGridView();
            cmbAddProduct = new ComboBox();
            cmbAddSize = new ComboBox();
            numAddQty = new NumericUpDown();
            btnAddToOrder = new Button();
            dtpOrderDate = new DateTimePicker();
            lblOrderTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAddQty).BeginInit();
            SuspendLayout();
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(12, 387);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(12, 431);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 1;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(12, 478);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(125, 27);
            txtMiddleName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(424, 327);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(198, 46);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить изменения";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(183, 327);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(198, 46);
            btnRemoveItem.TabIndex = 6;
            btnRemoveItem.Text = "Удалить позицию";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(590, 469);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(198, 44);
            btnClose.TabIndex = 7;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 93);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(776, 228);
            dgvItems.TabIndex = 8;
            // 
            // cmbAddProduct
            // 
            cmbAddProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddProduct.FormattingEnabled = true;
            cmbAddProduct.Location = new Point(156, 387);
            cmbAddProduct.Name = "cmbAddProduct";
            cmbAddProduct.Size = new Size(151, 28);
            cmbAddProduct.TabIndex = 9;
            cmbAddProduct.SelectedIndexChanged += cmbAddProduct_SelectedIndexChanged;
            // 
            // cmbAddSize
            // 
            cmbAddSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddSize.FormattingEnabled = true;
            cmbAddSize.Location = new Point(156, 431);
            cmbAddSize.Name = "cmbAddSize";
            cmbAddSize.Size = new Size(151, 28);
            cmbAddSize.TabIndex = 10;
            // 
            // numAddQty
            // 
            numAddQty.Location = new Point(156, 481);
            numAddQty.Name = "numAddQty";
            numAddQty.Size = new Size(156, 27);
            numAddQty.TabIndex = 11;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Location = new Point(358, 471);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(198, 44);
            btnAddToOrder.TabIndex = 12;
            btnAddToOrder.Text = "Добавить в заказ";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Format = DateTimePickerFormat.Short;
            dtpOrderDate.Location = new Point(12, 52);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(250, 27);
            dtpOrderDate.TabIndex = 13;
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Location = new Point(12, 18);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(68, 20);
            lblOrderTitle.TabIndex = 14;
            lblOrderTitle.Text = "Заказ №";
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 537);
            Controls.Add(lblOrderTitle);
            Controls.Add(dtpOrderDate);
            Controls.Add(btnAddToOrder);
            Controls.Add(numAddQty);
            Controls.Add(cmbAddSize);
            Controls.Add(cmbAddProduct);
            Controls.Add(dgvItems);
            Controls.Add(btnClose);
            Controls.Add(btnRemoveItem);
            Controls.Add(btnSave);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Name = "OrderEditForm";
            Text = "Редактирование заказа";
            Load += OrderEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAddQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private Button btnSave;
        private Button btnRemoveItem;
        private Button btnClose;
        private DataGridView dgvItems;
        private ComboBox cmbAddProduct;
        private ComboBox cmbAddSize;
        private NumericUpDown numAddQty;
        private Button btnAddToOrder;
        private DateTimePicker dtpOrderDate;
        private Label lblOrderTitle;
    }
}