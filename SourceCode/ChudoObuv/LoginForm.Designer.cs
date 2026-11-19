namespace ChudoObuv
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnGuest = new Button();
            picLogo = new PictureBox();
            txtLogin = new MaskedTextBox();
            btnLogin = new Button();
            label2 = new Label();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 187);
            label1.Name = "label1";
            label1.Size = new Size(53, 21);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // btnGuest
            // 
            btnGuest.Location = new Point(255, 290);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(180, 48);
            btnGuest.TabIndex = 2;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = true;
            btnGuest.Click += btnGuest_Click;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(255, 40);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(180, 120);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(325, 187);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(110, 28);
            txtLogin.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(255, 360);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 48);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 238);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 7;
            label2.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(325, 235);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(110, 28);
            txtPassword.TabIndex = 8;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 508);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(txtLogin);
            Controls.Add(picLogo);
            Controls.Add(btnGuest);
            Controls.Add(label1);
            Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Чудо Обувь - Вход";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGuest;
        private PictureBox picLogo;
        private MaskedTextBox txtLogin;
        private Button btnLogin;
        private Label label2;
        private TextBox txtPassword;
    }
}
