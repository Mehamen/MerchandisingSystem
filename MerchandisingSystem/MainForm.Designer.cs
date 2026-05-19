namespace MerchandisingSystem
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
        private System.Windows.Forms.Panel panelSideHeader;
        private System.Windows.Forms.Label lblSideTitle;

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSideHeader = new System.Windows.Forms.Panel();
            this.lblSideTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnRoutes = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnStores = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSideHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.задачиToolStripMenuItem,
            this.маршрутыToolStripMenuItem,
            this.картаToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.менюToolStripMenuItem.Text = "Торговые точки";
            this.менюToolStripMenuItem.Click += new System.EventHandler(this.менюToolStripMenuItem_Click);
            // 
            // задачиToolStripMenuItem
            // 
            this.задачиToolStripMenuItem.Name = "задачиToolStripMenuItem";
            this.задачиToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.задачиToolStripMenuItem.Text = "Задачи";
            // 
            // маршрутыToolStripMenuItem
            // 
            this.маршрутыToolStripMenuItem.Name = "маршрутыToolStripMenuItem";
            this.маршрутыToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.маршрутыToolStripMenuItem.Text = "Маршруты";
            // 
            // картаToolStripMenuItem
            // 
            this.картаToolStripMenuItem.Name = "картаToolStripMenuItem";
            this.картаToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.картаToolStripMenuItem.Text = "Карта";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // panelSideHeader — лого вверху сайдбара
            this.panelSideHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelSideHeader.Height    = 60;
            this.panelSideHeader.BackColor = UITheme.HeaderBg;
            this.panelSideHeader.Controls.Add(this.lblSideTitle);

            this.lblSideTitle.Text      = "Мерчандайзинг";
            this.lblSideTitle.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblSideTitle.ForeColor = UITheme.TextLight;
            this.lblSideTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblSideTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panel2 — сайдбар
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnMap);
            this.panel2.Controls.Add(this.btnRoutes);
            this.panel2.Controls.Add(this.btnTasks);
            this.panel2.Controls.Add(this.btnStores);
            this.panel2.Controls.Add(this.panelSideHeader);
            this.panel2.Dock      = System.Windows.Forms.DockStyle.Left;
            this.panel2.Name      = "panel2";
            this.panel2.Width     = 160;
            this.panel2.BackColor = UITheme.SidebarBg;

            // кнопки сайдбара
            this.btnStores.Text     = "  Торговые точки";
            this.btnStores.Name     = "btnStores";
            this.btnStores.Location = new System.Drawing.Point(0, 60);
            this.btnStores.Size     = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnStores);
            this.btnStores.Click += new System.EventHandler(this.btnStores_Click);

            this.btnTasks.Text     = "  Задачи";
            this.btnTasks.Name     = "btnTasks";
            this.btnTasks.Location = new System.Drawing.Point(0, 102);
            this.btnTasks.Size     = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnTasks);
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);

            this.btnRoutes.Text     = "  Маршруты";
            this.btnRoutes.Name     = "btnRoutes";
            this.btnRoutes.Location = new System.Drawing.Point(0, 144);
            this.btnRoutes.Size     = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnRoutes);
            this.btnRoutes.Click += new System.EventHandler(this.btnRoutes_Click);

            this.btnMap.Text     = "  Карта";
            this.btnMap.Name     = "btnMap";
            this.btnMap.Location = new System.Drawing.Point(0, 186);
            this.btnMap.Size     = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnMap);
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);

            this.btnReports.Text     = "  Отчёты";
            this.btnReports.Name     = "btnReports";
            this.btnReports.Location = new System.Drawing.Point(0, 228);
            this.btnReports.Size     = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnReports);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.btnExit.Text      = "  Выход";
            this.btnExit.Name      = "btnExit";
            this.btnExit.Location  = new System.Drawing.Point(0, 280);
            this.btnExit.Size      = new System.Drawing.Size(160, 42);
            UITheme.StyleSidebarButton(this.btnExit);
            this.btnExit.FlatAppearance.MouseOverBackColor = UITheme.AccentRed;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // panelMain — основная область
            this.panelMain.Controls.Add(this.lblUserName);
            this.panelMain.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Name      = "panelMain";
            this.panelMain.BackColor = UITheme.BgLight;

            // lblUserName — в шапке основной области
            this.lblUserName.AutoSize  = false;
            this.lblUserName.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblUserName.Height    = 36;
            this.lblUserName.Name      = "lblUserName";
            this.lblUserName.Font      = UITheme.FontBold;
            this.lblUserName.ForeColor = UITheme.TextDark;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserName.Padding   = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblUserName.BackColor = System.Drawing.Color.White;

            // statusStrip
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Name      = "statusStrip1";
            this.statusStrip1.BackColor = UITheme.SidebarBg;
            this.statusStrip1.ForeColor = UITheme.TextLight;
            this.lblStatus.Name         = "lblStatus";
            this.lblStatus.Text         = "Готово";
            this.lblStatus.ForeColor    = UITheme.TextLight;

            // menuStrip — скрываем (навигация через сайдбар)
            this.menuStrip1.Visible = false;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode  = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize     = new System.Drawing.Size(1000, 600);
            this.MinimumSize    = new System.Drawing.Size(800, 500);
            this.BackColor      = UITheme.BgLight;
            this.Text           = "Система мерчандайзинга";
            this.Name           = "MainForm";
            this.Load       += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelSideHeader.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem картаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnRoutes;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnStores;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblUserName;
    }
}