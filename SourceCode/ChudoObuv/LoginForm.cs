using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using ChudoObuv.Models;

namespace ChudoObuv
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this, "Авторизация");
            StyleHelper.StyleAccentButton(btnLogin);
            StyleHelper.StyleSecondaryButton(btnGuest);

            txtLogin.BackColor = StyleHelper.SecondaryBg;

            string logoPath = Path.Combine(Application.StartupPath, "images", "Чудо Обувь.png");
            if (File.Exists(logoPath) && picLogo != null)
            {
                picLogo.Image = Image.FromFile(logoPath);
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин пользователя или нажмите «Войти как гость».",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = DbHelper.Query(
                    @"SELECT u.last_name, u.first_name, u.middle_name, r.name AS role 
                      FROM [User] u 
                      JOIN Role r ON r.id = u.role_id 
                      WHERE u.login = @log",
                    new SqlParameter("@log", login));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Пользователь с логином «" + login + "» не найден. Проверьте правильность ввода.",
                        "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dt.Rows[0];
                CurrentUser.Login = login;
                CurrentUser.FullName = $"{row["last_name"]} {row["first_name"]} {row["middle_name"]}".Trim();
                CurrentUser.Role = row["role"].ToString();

                OpenCatalog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser.Login = null;
            CurrentUser.FullName = "Гость";
            CurrentUser.Role = "Гость";
            OpenCatalog();
        }

        private void OpenCatalog()
        {
            Cart.Items.Clear();
            CatalogForm catalog = new CatalogForm();
            catalog.FormClosed += (s, args) => this.Show();
            catalog.Show();
            this.Hide();
        }
    }
}
