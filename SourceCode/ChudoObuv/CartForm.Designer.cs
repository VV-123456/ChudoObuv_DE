namespace ChudoObuv
{
    partial class CartForm
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
            dgvCart = new DataGridView();
            btnOrder = new Button();
            btnRemove = new Button();
            btnClose = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(12, 12);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(712, 267);
            dgvCart.TabIndex = 0;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(12, 348);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(189, 52);
            btnOrder.TabIndex = 1;
            btnOrder.Text = "Оформить заказ";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(275, 348);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(189, 52);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Удалить позицию";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(535, 348);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(189, 52);
            btnClose.TabIndex = 3;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 291);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "label1";
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 450);
            Controls.Add(lblTotal);
            Controls.Add(btnClose);
            Controls.Add(btnRemove);
            Controls.Add(btnOrder);
            Controls.Add(dgvCart);
            Name = "CartForm";
            Text = "Корзина";
            Load += CartForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCart;
        private Button btnOrder;
        private Button btnRemove;
        private Button btnClose;
        private Label lblTotal;
    }
}