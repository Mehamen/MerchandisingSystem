namespace MerchandisingSystem
{
    partial class ReportsForm
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCompleted;
        private System.Windows.Forms.TabPage tabByEmployee;
        private System.Windows.Forms.TabPage tabByStatus;
        private System.Windows.Forms.TabPage tabHistory;

        private System.Windows.Forms.DataGridView dgvCompleted;
        private System.Windows.Forms.DataGridView dgvByEmployee;
        private System.Windows.Forms.DataGridView dgvByStatus;
        private System.Windows.Forms.DataGridView dgvHistory;

        private System.Windows.Forms.Panel panelFilterCompleted;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnRefreshCompleted;
        private System.Windows.Forms.Button btnRefreshAll;

        private void InitializeComponent()
        {
            this.tabControl           = new System.Windows.Forms.TabControl();
            this.tabCompleted         = new System.Windows.Forms.TabPage();
            this.tabByEmployee        = new System.Windows.Forms.TabPage();
            this.tabByStatus          = new System.Windows.Forms.TabPage();
            this.tabHistory           = new System.Windows.Forms.TabPage();
            this.dgvCompleted         = new System.Windows.Forms.DataGridView();
            this.dgvByEmployee        = new System.Windows.Forms.DataGridView();
            this.dgvByStatus          = new System.Windows.Forms.DataGridView();
            this.dgvHistory           = new System.Windows.Forms.DataGridView();
            this.panelFilterCompleted = new System.Windows.Forms.Panel();
            this.lblDateFrom          = new System.Windows.Forms.Label();
            this.dtpFrom              = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo            = new System.Windows.Forms.Label();
            this.dtpTo                = new System.Windows.Forms.DateTimePicker();
            this.btnRefreshCompleted  = new System.Windows.Forms.Button();
            this.btnRefreshAll        = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabCompleted.SuspendLayout();
            this.tabByEmployee.SuspendLayout();
            this.tabByStatus.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.panelFilterCompleted.SuspendLayout();
            this.SuspendLayout();

            // ── tabControl ──────────────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Name = "tabControl";
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                tabCompleted, tabByEmployee, tabByStatus, tabHistory
            });

            // ── Вкладка 1: Выполненные задачи ───────────────────────────
            this.tabCompleted.Text    = "Выполненные задачи";
            this.tabCompleted.Name    = "tabCompleted";
            this.tabCompleted.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompleted.Controls.AddRange(new System.Windows.Forms.Control[] {
                panelFilterCompleted, dgvCompleted
            });

            // панель фильтра
            this.panelFilterCompleted.Dock   = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCompleted.Height  = 40;
            this.panelFilterCompleted.Name    = "panelFilterCompleted";
            this.panelFilterCompleted.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDateFrom, dtpFrom, lblDateTo, dtpTo, btnRefreshCompleted
            });

            this.lblDateFrom.Text     = "С:";
            this.lblDateFrom.Location = new System.Drawing.Point(5, 12);
            this.lblDateFrom.Size     = new System.Drawing.Size(20, 18);

            this.dtpFrom.Location = new System.Drawing.Point(28, 8);
            this.dtpFrom.Size     = new System.Drawing.Size(110, 23);
            this.dtpFrom.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Name     = "dtpFrom";

            this.lblDateTo.Text     = "По:";
            this.lblDateTo.Location = new System.Drawing.Point(148, 12);
            this.lblDateTo.Size     = new System.Drawing.Size(25, 18);

            this.dtpTo.Location = new System.Drawing.Point(176, 8);
            this.dtpTo.Size     = new System.Drawing.Size(110, 23);
            this.dtpTo.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Name     = "dtpTo";

            this.btnRefreshCompleted.Text     = "Показать";
            this.btnRefreshCompleted.Location = new System.Drawing.Point(295, 6);
            this.btnRefreshCompleted.Size     = new System.Drawing.Size(90, 28);
            this.btnRefreshCompleted.Name     = "btnRefreshCompleted";
            this.btnRefreshCompleted.Click   += new System.EventHandler(this.btnRefreshCompleted_Click);

            this.dgvCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompleted.Name = "dgvCompleted";
            this.dgvCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompleted.ReadOnly         = true;
            this.dgvCompleted.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompleted.AllowUserToAddRows = false;

            // ── Вкладка 2: По сотрудникам ────────────────────────────────
            this.tabByEmployee.Text = "По сотрудникам";
            this.tabByEmployee.Name = "tabByEmployee";
            this.tabByEmployee.Controls.Add(dgvByEmployee);

            this.btnRefreshAll        = new System.Windows.Forms.Button();
            this.btnRefreshAll.Text   = "Обновить";
            this.btnRefreshAll.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefreshAll.Height = 30;
            this.btnRefreshAll.Name   = "btnRefreshAll";
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);

            this.dgvByEmployee.Dock   = System.Windows.Forms.DockStyle.Fill;
            this.dgvByEmployee.Name   = "dgvByEmployee";
            this.dgvByEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByEmployee.ReadOnly          = true;
            this.dgvByEmployee.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByEmployee.AllowUserToAddRows = false;

            // ── Вкладка 3: По статусам ───────────────────────────────────
            this.tabByStatus.Text = "По статусам";
            this.tabByStatus.Name = "tabByStatus";
            this.tabByStatus.Controls.Add(dgvByStatus);

            this.dgvByStatus.Dock   = System.Windows.Forms.DockStyle.Fill;
            this.dgvByStatus.Name   = "dgvByStatus";
            this.dgvByStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByStatus.ReadOnly          = true;
            this.dgvByStatus.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByStatus.AllowUserToAddRows = false;

            // ── Вкладка 4: История посещений ─────────────────────────────
            this.tabHistory.Text = "История посещений";
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Controls.Add(dgvHistory);

            this.dgvHistory.Dock   = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Name   = "dgvHistory";
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.ReadOnly          = true;
            this.dgvHistory.SelectionMode     = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.AllowUserToAddRows = false;

            // ── ReportsForm ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize    = new System.Drawing.Size(900, 500);
            this.Text          = "Отчёты";
            this.Name          = "ReportsForm";
            this.Load         += new System.EventHandler(this.ReportsForm_Load);
            this.Controls.Add(this.tabControl);
            this.tabByEmployee.Controls.Add(btnRefreshAll);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCompleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabCompleted.ResumeLayout(false);
            this.tabByEmployee.ResumeLayout(false);
            this.tabByStatus.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.panelFilterCompleted.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}