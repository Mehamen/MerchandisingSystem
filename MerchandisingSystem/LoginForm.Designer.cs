namespace MerchandisingSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelCard   = new System.Windows.Forms.Panel();
            this.label1      = new System.Windows.Forms.Label();
            this.label2      = new System.Windows.Forms.Label();
            this.txtLogin    = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // panelHeader — тёмная шапка
            this.panelHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height    = 110;
            this.panelHeader.BackColor = UITheme.SidebarBg;
            this.panelHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblSubtitle });

            this.lblTitle.Text      = "Система мерчандайзинга";
            this.lblTitle.Font      = UITheme.FontTitle;
            this.lblTitle.ForeColor = UITheme.TextLight;
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Size      = new System.Drawing.Size(360, 40);
            this.lblTitle.Location  = new System.Drawing.Point(20, 25);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitle.Text      = "Постановка задач и маршрутизация";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblSubtitle.AutoSize  = false;
            this.lblSubtitle.Size      = new System.Drawing.Size(360, 22);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 68);
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panelCard — белая карточка
            this.panelCard.Location  = new System.Drawing.Point(30, 125);
            this.panelCard.Size      = new System.Drawing.Size(340, 190);
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                label1, txtLogin, label2, txtPassword, btnLogin
            });

            this.label1.Text      = "Логин";
            this.label1.Font      = UITheme.FontBold;
            this.label1.ForeColor = UITheme.TextDark;
            this.label1.Location  = new System.Drawing.Point(20, 20);
            this.label1.Size      = new System.Drawing.Size(60, 20);

            this.txtLogin.Location  = new System.Drawing.Point(20, 42);
            this.txtLogin.Size      = new System.Drawing.Size(300, 26);
            this.txtLogin.Name      = "txtLogin";
            this.txtLogin.Font      = UITheme.FontNormal;
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.label2.Text      = "Пароль";
            this.label2.Font      = UITheme.FontBold;
            this.label2.ForeColor = UITheme.TextDark;
            this.label2.Location  = new System.Drawing.Point(20, 80);
            this.label2.Size      = new System.Drawing.Size(60, 20);

            this.txtPassword.Location     = new System.Drawing.Point(20, 102);
            this.txtPassword.Size         = new System.Drawing.Size(300, 26);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Font         = UITheme.FontNormal;
            this.txtPassword.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnLogin.Text      = "Войти";
            this.btnLogin.Location  = new System.Drawing.Point(20, 144);
            this.btnLogin.Size      = new System.Drawing.Size(300, 36);
            this.btnLogin.Name      = "btnLogin";
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.BackColor = UITheme.AccentBlue;
            this.btnLogin.ForeColor = UITheme.TextLight;
            this.btnLogin.Font      = UITheme.FontLarge;
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode  = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize     = new System.Drawing.Size(400, 340);
            this.BackColor      = UITheme.BgLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox    = false;
            this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text           = "Авторизация";
            this.Name           = "LoginForm";
            this.Controls.AddRange(new System.Windows.Forms.Control[] { panelHeader, panelCard });
            this.panelHeader.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

    }
}

