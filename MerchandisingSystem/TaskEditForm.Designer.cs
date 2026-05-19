namespace MerchandisingSystem
{
    partial class TaskEditForm
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
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label lblMerch;
        private System.Windows.Forms.ComboBox cmbMerch;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblStore  = new System.Windows.Forms.Label();
            this.cmbStore  = new System.Windows.Forms.ComboBox();
            this.lblMerch  = new System.Windows.Forms.Label();
            this.cmbMerch  = new System.Windows.Forms.ComboBox();
            this.lblType   = new System.Windows.Forms.Label();
            this.cmbType   = new System.Windows.Forms.ComboBox();
            this.lblDesc   = new System.Windows.Forms.Label();
            this.txtDesc   = new System.Windows.Forms.TextBox();
            this.lblDate   = new System.Windows.Forms.Label();
            this.dtpDate   = new System.Windows.Forms.DateTimePicker();
            this.btnSave   = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblStore.Text = "Торговая точка:";
            this.lblStore.Location = new System.Drawing.Point(20, 20);
            this.lblStore.Size = new System.Drawing.Size(120, 20);

            this.cmbStore.Location = new System.Drawing.Point(150, 17);
            this.cmbStore.Size = new System.Drawing.Size(280, 23);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblMerch.Text = "Мерчандайзер:";
            this.lblMerch.Location = new System.Drawing.Point(20, 55);
            this.lblMerch.Size = new System.Drawing.Size(120, 20);

            this.cmbMerch.Location = new System.Drawing.Point(150, 52);
            this.cmbMerch.Size = new System.Drawing.Size(280, 23);
            this.cmbMerch.Name = "cmbMerch";
            this.cmbMerch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblType.Text = "Тип задачи:";
            this.lblType.Location = new System.Drawing.Point(20, 90);
            this.lblType.Size = new System.Drawing.Size(120, 20);

            this.cmbType.Location = new System.Drawing.Point(150, 87);
            this.cmbType.Size = new System.Drawing.Size(280, 23);
            this.cmbType.Name = "cmbType";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblDesc.Text = "Описание:";
            this.lblDesc.Location = new System.Drawing.Point(20, 125);
            this.lblDesc.Size = new System.Drawing.Size(120, 20);

            this.txtDesc.Location = new System.Drawing.Point(150, 122);
            this.txtDesc.Size = new System.Drawing.Size(280, 70);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Multiline = true;

            this.lblDate.Text = "Дата выполнения:";
            this.lblDate.Location = new System.Drawing.Point(20, 208);
            this.lblDate.Size = new System.Drawing.Size(120, 20);

            this.dtpDate.Location = new System.Drawing.Point(150, 205);
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(150, 245);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(265, 245);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(480, 295);
            this.Text = "Новая задача";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TaskEditForm_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblStore, cmbStore, lblMerch, cmbMerch,
                lblType, cmbType, lblDesc, txtDesc,
                lblDate, dtpDate, btnSave, btnCancel
            });
            this.ResumeLayout(false);
        }

        #endregion
    }
}