namespace ChudoObuv
{
    partial class ProductForm
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
            picProduct = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            lblDescription = new Label();
            cmbSizes = new ComboBox();
            numQty = new NumericUpDown();
            btnAddToCart = new Button();
            btnClose = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            SuspendLayout();
            // 
            // picProduct
            // 
            picProduct.Location = new Point(25, 12);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(300, 218);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(25, 241);
            lblName.Name = "lblName";
            lblName.Size = new Size(66, 20);
            lblName.TabIndex = 1;
            lblName.Text = "lblName";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(25, 276);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 20);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "lblPrice";
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(25, 310);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(680, 170);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "lblDescription";
            // 
            // cmbSizes
            // 
            cmbSizes.FormattingEnabled = true;
            cmbSizes.Location = new Point(360, 59);
            cmbSizes.Name = "cmbSizes";
            cmbSizes.Size = new Size(220, 28);
            cmbSizes.TabIndex = 4;
            cmbSizes.SelectedIndexChanged += cmbSizes_SelectedIndexChanged;
            // 
            // numQty
            // 
            numQty.Location = new Point(360, 140);
            numQty.Name = "numQty";
            numQty.Size = new Size(150, 27);
            numQty.TabIndex = 5;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(25, 484);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(182, 57);
            btnAddToCart.TabIndex = 6;
            btnAddToCart.Text = "Добавить в корзину";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(223, 484);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 57);
            btnClose.TabIndex = 7;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(360, 36);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 8;
            label1.Text = "Выберите размер:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 117);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 9;
            label2.Text = "Количество:";
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 553);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnAddToCart);
            Controls.Add(numQty);
            Controls.Add(cmbSizes);
            Controls.Add(lblDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(picProduct);
            Name = "ProductForm";
            Text = "Карточка товара";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProduct;
        private Label lblName;
        private Label lblPrice;
        private Label lblDescription;
        private ComboBox cmbSizes;
        private NumericUpDown numQty;
        private Button btnAddToCart;
        private Button btnClose;
        private Label label1;
        private Label label2;
    }
}