namespace MerchandisingSystem
{
    partial class StoreEditForm
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddressHint;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblCoords;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Button btnGeocode;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblName        = new System.Windows.Forms.Label();
            this.lblAddress     = new System.Windows.Forms.Label();
            this.lblAddressHint = new System.Windows.Forms.Label();
            this.lblType        = new System.Windows.Forms.Label();
            this.lblComment     = new System.Windows.Forms.Label();
            this.lblCoords      = new System.Windows.Forms.Label();
            this.lblLat         = new System.Windows.Forms.Label();
            this.lblLon         = new System.Windows.Forms.Label();
            this.txtName        = new System.Windows.Forms.TextBox();
            this.txtCity        = new System.Windows.Forms.TextBox();
            this.txtStreet      = new System.Windows.Forms.TextBox();
            this.txtBuilding    = new System.Windows.Forms.TextBox();
            this.btnGeocode     = new System.Windows.Forms.Button();
            this.cmbType        = new System.Windows.Forms.ComboBox();
            this.txtComment     = new System.Windows.Forms.TextBox();
            this.txtLat         = new System.Windows.Forms.TextBox();
            this.txtLon         = new System.Windows.Forms.TextBox();
            this.btnSave        = new System.Windows.Forms.Button();
            this.btnCancel      = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.Text     = "Название:";
            this.lblName.Location = new System.Drawing.Point(20, 18);
            this.lblName.Size     = new System.Drawing.Size(100, 20);

            // txtName
            this.txtName.Location = new System.Drawing.Point(130, 15);
            this.txtName.Size     = new System.Drawing.Size(310, 23);
            this.txtName.Name     = "txtName";

            // lblAddress
            this.lblAddress.Text      = "Адрес:";
            this.lblAddress.Location  = new System.Drawing.Point(20, 50);
            this.lblAddress.Size      = new System.Drawing.Size(100, 20);
            this.lblAddress.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold);

            // lblAddressHint — подсказка
            this.lblAddressHint.Text      = "Город           Улица                  Дом";
            this.lblAddressHint.Location  = new System.Drawing.Point(130, 50);
            this.lblAddressHint.Size      = new System.Drawing.Size(310, 16);
            this.lblAddressHint.ForeColor = System.Drawing.Color.Gray;
            this.lblAddressHint.Font      = new System.Drawing.Font("Microsoft Sans Serif", 7f);

            // txtCity
            this.txtCity.Location    = new System.Drawing.Point(130, 68);
            this.txtCity.Size        = new System.Drawing.Size(100, 23);
            this.txtCity.Name        = "txtCity";

            // txtStreet
            this.txtStreet.Location  = new System.Drawing.Point(238, 68);
            this.txtStreet.Size      = new System.Drawing.Size(140, 23);
            this.txtStreet.Name      = "txtStreet";

            // txtBuilding
            this.txtBuilding.Location = new System.Drawing.Point(386, 68);
            this.txtBuilding.Size     = new System.Drawing.Size(54, 23);
            this.txtBuilding.Name     = "txtBuilding";

            // btnGeocode
            this.btnGeocode.Text      = "🔍 Найти координаты по адресу";
            this.btnGeocode.Location  = new System.Drawing.Point(130, 98);
            this.btnGeocode.Size      = new System.Drawing.Size(220, 28);
            this.btnGeocode.Name      = "btnGeocode";
            this.btnGeocode.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnGeocode.ForeColor = System.Drawing.Color.White;
            this.btnGeocode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeocode.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.5f, System.Drawing.FontStyle.Bold);
            this.btnGeocode.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGeocode.Click    += new System.EventHandler(this.btnGeocode_Click);

            // lblCoords — разделитель
            this.lblCoords.Text      = "── Или введите координаты вручную ──";
            this.lblCoords.Location  = new System.Drawing.Point(20, 135);
            this.lblCoords.Size      = new System.Drawing.Size(420, 18);
            this.lblCoords.ForeColor = System.Drawing.Color.Gray;
            this.lblCoords.Font      = new System.Drawing.Font("Microsoft Sans Serif", 7.5f);

            // lblLat
            this.lblLat.Text     = "Широта:";
            this.lblLat.Location = new System.Drawing.Point(20, 160);
            this.lblLat.Size     = new System.Drawing.Size(100, 20);

            // txtLat
            this.txtLat.Location = new System.Drawing.Point(130, 157);
            this.txtLat.Size     = new System.Drawing.Size(140, 23);
            this.txtLat.Name     = "txtLat";

            // lblLon
            this.lblLon.Text     = "Долгота:";
            this.lblLon.Location = new System.Drawing.Point(20, 192);
            this.lblLon.Size     = new System.Drawing.Size(100, 20);

            // txtLon
            this.txtLon.Location = new System.Drawing.Point(130, 189);
            this.txtLon.Size     = new System.Drawing.Size(140, 23);
            this.txtLon.Name     = "txtLon";

            // lblType
            this.lblType.Text     = "Тип магазина:";
            this.lblType.Location = new System.Drawing.Point(20, 228);
            this.lblType.Size     = new System.Drawing.Size(100, 20);

            // cmbType
            this.cmbType.Location      = new System.Drawing.Point(130, 225);
            this.cmbType.Size          = new System.Drawing.Size(310, 23);
            this.cmbType.Name          = "cmbType";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblComment
            this.lblComment.Text     = "Комментарий:";
            this.lblComment.Location = new System.Drawing.Point(20, 263);
            this.lblComment.Size     = new System.Drawing.Size(100, 20);

            // txtComment
            this.txtComment.Location  = new System.Drawing.Point(130, 260);
            this.txtComment.Size      = new System.Drawing.Size(310, 55);
            this.txtComment.Name      = "txtComment";
            this.txtComment.Multiline = true;

            // btnSave
            this.btnSave.Text     = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(130, 328);
            this.btnSave.Size     = new System.Drawing.Size(100, 30);
            this.btnSave.Name     = "btnSave";
            this.btnSave.Click   += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text     = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(245, 328);
            this.btnCancel.Size     = new System.Drawing.Size(100, 30);
            this.btnCancel.Name     = "btnCancel";
            this.btnCancel.Click   += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize      = new System.Drawing.Size(470, 375);
            this.Text            = "Торговая точка";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load           += new System.EventHandler(this.StoreEditForm_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblName, txtName,
                lblAddress, lblAddressHint, txtCity, txtStreet, txtBuilding, btnGeocode,
                lblCoords, lblLat, txtLat, lblLon, txtLon,
                lblType, cmbType, lblComment, txtComment,
                btnSave, btnCancel
            });
            this.ResumeLayout(false);
        }

        #endregion
    }
}