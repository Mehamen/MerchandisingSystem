namespace MerchandisingSystem
{
    partial class RouteForm
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
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ListBox lstRoute;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSaveRoute;
        private System.Windows.Forms.DateTimePicker dtpRouteDate;
        private System.Windows.Forms.Label lblRouteDate;
        private System.Windows.Forms.ComboBox cmbMerch;
        private System.Windows.Forms.Label lblMerch;

        private void InitializeComponent()
        {
            this.gMapControl  = new GMap.NET.WindowsForms.GMapControl();
            this.panelLeft    = new System.Windows.Forms.Panel();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.btnAdd       = new System.Windows.Forms.Button();
            this.btnRemove    = new System.Windows.Forms.Button();
            this.lblRoute     = new System.Windows.Forms.Label();
            this.lstRoute     = new System.Windows.Forms.ListBox();
            this.btnUp        = new System.Windows.Forms.Button();
            this.btnDown      = new System.Windows.Forms.Button();
            this.btnSaveRoute = new System.Windows.Forms.Button();
            this.dtpRouteDate = new System.Windows.Forms.DateTimePicker();
            this.lblRouteDate = new System.Windows.Forms.Label();
            this.cmbMerch     = new System.Windows.Forms.ComboBox();
            this.lblMerch     = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.Dock  = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 260;
            this.panelLeft.Name  = "panelLeft";
            this.panelLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblMerch, cmbMerch, lblRouteDate, dtpRouteDate,
                lblAvailable, lstAvailable, btnAdd, btnRemove,
                lblRoute, lstRoute, btnUp, btnDown, btnSaveRoute
            });

            // lblMerch
            this.lblMerch.Text     = "Мерчандайзер:";
            this.lblMerch.Location = new System.Drawing.Point(5, 5);
            this.lblMerch.Size     = new System.Drawing.Size(100, 18);

            // cmbMerch
            this.cmbMerch.Location     = new System.Drawing.Point(5, 25);
            this.cmbMerch.Size         = new System.Drawing.Size(245, 23);
            this.cmbMerch.Name         = "cmbMerch";
            this.cmbMerch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblRouteDate
            this.lblRouteDate.Text     = "Дата маршрута:";
            this.lblRouteDate.Location = new System.Drawing.Point(5, 55);
            this.lblRouteDate.Size     = new System.Drawing.Size(100, 18);

            // dtpRouteDate
            this.dtpRouteDate.Location = new System.Drawing.Point(5, 75);
            this.dtpRouteDate.Size     = new System.Drawing.Size(245, 23);
            this.dtpRouteDate.Name     = "dtpRouteDate";
            this.dtpRouteDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblAvailable
            this.lblAvailable.Text     = "Доступные точки:";
            this.lblAvailable.Location = new System.Drawing.Point(5, 105);
            this.lblAvailable.Size     = new System.Drawing.Size(245, 18);

            // lstAvailable
            this.lstAvailable.Location = new System.Drawing.Point(5, 125);
            this.lstAvailable.Size     = new System.Drawing.Size(245, 130);
            this.lstAvailable.Name     = "lstAvailable";

            // btnAdd
            this.btnAdd.Text     = "▼ Добавить в маршрут";
            this.btnAdd.Location = new System.Drawing.Point(5, 260);
            this.btnAdd.Size     = new System.Drawing.Size(245, 28);
            this.btnAdd.Name     = "btnAdd";
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            // btnRemove
            this.btnRemove.Text     = "▲ Убрать из маршрута";
            this.btnRemove.Location = new System.Drawing.Point(5, 293);
            this.btnRemove.Size     = new System.Drawing.Size(245, 28);
            this.btnRemove.Name     = "btnRemove";
            this.btnRemove.Click   += new System.EventHandler(this.btnRemove_Click);

            // lblRoute
            this.lblRoute.Text     = "Маршрут (порядок посещения):";
            this.lblRoute.Location = new System.Drawing.Point(5, 328);
            this.lblRoute.Size     = new System.Drawing.Size(245, 18);

            // lstRoute
            this.lstRoute.Location = new System.Drawing.Point(5, 348);
            this.lstRoute.Size     = new System.Drawing.Size(245, 110);
            this.lstRoute.Name     = "lstRoute";

            // btnUp
            this.btnUp.Text     = "↑ Вверх";
            this.btnUp.Location = new System.Drawing.Point(5, 463);
            this.btnUp.Size     = new System.Drawing.Size(118, 28);
            this.btnUp.Name     = "btnUp";
            this.btnUp.Click   += new System.EventHandler(this.btnUp_Click);

            // btnDown
            this.btnDown.Text     = "↓ Вниз";
            this.btnDown.Location = new System.Drawing.Point(132, 463);
            this.btnDown.Size     = new System.Drawing.Size(118, 28);
            this.btnDown.Name     = "btnDown";
            this.btnDown.Click   += new System.EventHandler(this.btnDown_Click);

            // btnSaveRoute
            this.btnSaveRoute.Text     = "Сохранить маршрут";
            this.btnSaveRoute.Location = new System.Drawing.Point(5, 498);
            this.btnSaveRoute.Size     = new System.Drawing.Size(245, 32);
            this.btnSaveRoute.Name     = "btnSaveRoute";
            this.btnSaveRoute.Click   += new System.EventHandler(this.btnSaveRoute_Click);

            // gMapControl
            this.gMapControl.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.Name    = "gMapControl";
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MaxZoom = 18;

            // RouteForm
            this.ClientSize      = new System.Drawing.Size(1100, 600);
            this.Text            = "Формирование маршрута";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.Font;
            this.Load           += new System.EventHandler(this.RouteForm_Load);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.panelLeft);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}