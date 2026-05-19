namespace MerchandisingSystem
{
    partial class TaskStatusForm
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
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.lblStatus  = new System.Windows.Forms.Label();
            this.cmbStatus  = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave    = new System.Windows.Forms.Button();
            this.btnCancel  = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblStatus.Text = "Новый статус:";
            this.lblStatus.Location = new System.Drawing.Point(20, 20);
            this.lblStatus.Size = new System.Drawing.Size(110, 20);

            this.cmbStatus.Location = new System.Drawing.Point(140, 17);
            this.cmbStatus.Size = new System.Drawing.Size(190, 23);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblComment.Text = "Комментарий:";
            this.lblComment.Location = new System.Drawing.Point(20, 55);
            this.lblComment.Size = new System.Drawing.Size(110, 20);

            this.txtComment.Location = new System.Drawing.Point(140, 52);
            this.txtComment.Size = new System.Drawing.Size(190, 60);
            this.txtComment.Name = "txtComment";
            this.txtComment.Multiline = true;

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(140, 130);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(250, 130);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(360, 180);
            this.Text = "Изменить статус задачи";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TaskStatusForm_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblStatus, cmbStatus, lblComment, txtComment, btnSave, btnCancel
            });
            this.ResumeLayout(false);
        }

        #endregion
    }
}