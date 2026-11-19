using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChudoObuv.Models
{
    public static class StyleHelper
    {
        public static readonly Color MainBg = ColorTranslator.FromHtml("#FFFFFF");
        public static readonly Color SecondaryBg = ColorTranslator.FromHtml("#D2F6E7");
        public static readonly Color AccentColor = ColorTranslator.FromHtml("#70B2AF");
        public static readonly Color LowStockColor = ColorTranslator.FromHtml("#FF8080");
        public static readonly Font MainFont = new Font("Calibri", 11F, FontStyle.Regular);
        public static readonly Font BoldFont = new Font("Calibri", 12F, FontStyle.Bold);

        public static void ApplyFormStyle(Form form, string title)
        {
            form.Text = "Чудо Обувь — " + title;
            form.BackColor = MainBg;
            form.Font = MainFont;

            string iconPath = Path.Combine(Application.StartupPath, "images", "Чудо Обувь.ico");
            if (File.Exists(iconPath))
            {
                form.Icon = new Icon(iconPath);
            }
        }

        public static void StyleAccentButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = AccentColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Calibri", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleSecondaryButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = SecondaryBg;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = AccentColor;
            btn.Font = MainFont;
            btn.Cursor = Cursors.Hand;
        }

        public static Image LoadProductImage(string imageName)
        {
            string imgFolder = Path.Combine(Application.StartupPath, "images");
            if (!string.IsNullOrWhiteSpace(imageName))
            {
                string fullPath = Path.Combine(imgFolder, imageName.Trim());
                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath);
                }
            }

            string stubPath = Path.Combine(imgFolder, "picture.png");
            return File.Exists(stubPath) ? Image.FromFile(stubPath) : null;
        }
    }
}
