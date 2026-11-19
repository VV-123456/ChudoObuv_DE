namespace ChudoObuv
{
    partial class MainForm
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
            lblFio = new Label();
            btnCatalog = new Button();
            btnOrders = new Button();
            btnExit = new Button();
            btnCart = new Button();
            SuspendLayout();
            // 
            // lblFio
            // 
            lblFio.AutoSize = true;
            lblFio.Location = new Point(202, 74);
            lblFio.Name = "lblFio";
            lblFio.Size = new Size(50, 20);
            lblFio.TabIndex = 0;
            lblFio.Text = "label1";
            // 
            // btnCatalog
            // 
            btnCatalog.Location = new Point(202, 229);
            btnCatalog.Name = "btnCatalog";
            btnCatalog.Size = new Size(94, 29);
            btnCatalog.TabIndex = 1;
            btnCatalog.Text = "Каталог";
            btnCatalog.UseVisualStyleBackColor = true;
            btnCatalog.Click += btnCatalog_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(347, 229);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(94, 29);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(499, 229);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnCart
            // 
            btnCart.Location = new Point(347, 276);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(94, 29);
            btnCart.TabIndex = 4;
            btnCart.Text = "Корзина";
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 334);
            Controls.Add(btnCart);
            Controls.Add(btnExit);
            Controls.Add(btnOrders);
            Controls.Add(btnCatalog);
            Controls.Add(lblFio);
            Name = "MainForm";
            Text = "Чудо Обувь - Главная";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFio;
        private Button btnCatalog;
        private Button btnOrders;
        private Button btnExit;
        private Button btnCart;
    }
}