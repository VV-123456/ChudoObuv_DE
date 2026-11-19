namespace ChudoObuv
{
    partial class OrdersForm
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
            dgvOrders = new DataGridView();
            btnDetails = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 12);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(776, 290);
            dgvOrders.TabIndex = 0;
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(30, 320);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(148, 45);
            btnDetails.TabIndex = 1;
            btnDetails.Text = "Состав заказа";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(225, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 45);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить заказ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(423, 320);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(148, 45);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(614, 320);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(148, 45);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 396);
            Controls.Add(btnClose);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnDetails);
            Controls.Add(dgvOrders);
            Name = "OrdersForm";
            Text = "Список заказов";
            Load += OrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvOrders;
        private Button btnDetails;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnClose;
    }
}