namespace MerchandisingSystem
{
    partial class TasksForm
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
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;

        private System.Windows.Forms.Panel panelButtons;

        private void InitializeComponent()
        {
            this.dgvTasks        = new System.Windows.Forms.DataGridView();
            this.panelButtons    = new System.Windows.Forms.Panel();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnRefresh      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // panelButtons
            this.panelButtons.Dock    = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Width   = 165;
            this.panelButtons.Name    = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblFilterStatus, cmbFilterStatus, btnAdd, btnChangeStatus, btnDelete, btnRefresh
            });

            this.lblFilterStatus.Text     = "Фильтр по статусу:";
            this.lblFilterStatus.Location = new System.Drawing.Point(5, 8);
            this.lblFilterStatus.Size     = new System.Drawing.Size(150, 20);

            this.cmbFilterStatus.Location     = new System.Drawing.Point(5, 30);
            this.cmbFilterStatus.Size         = new System.Drawing.Size(150, 23);
            this.cmbFilterStatus.Name         = "cmbFilterStatus";
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            this.btnAdd.Location = new System.Drawing.Point(5, 65);
            this.btnAdd.Size     = new System.Drawing.Size(150, 33);
            this.btnAdd.Name     = "btnAdd";
            this.btnAdd.Text     = "Добавить задачу";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            this.btnChangeStatus.Location = new System.Drawing.Point(5, 104);
            this.btnChangeStatus.Size     = new System.Drawing.Size(150, 33);
            this.btnChangeStatus.Name     = "btnChangeStatus";
            this.btnChangeStatus.Text     = "Изменить статус";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click   += new System.EventHandler(this.btnChangeStatus_Click);

            this.btnDelete.Location = new System.Drawing.Point(5, 143);
            this.btnDelete.Size     = new System.Drawing.Size(150, 33);
            this.btnDelete.Name     = "btnDelete";
            this.btnDelete.Text     = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Location = new System.Drawing.Point(5, 182);
            this.btnRefresh.Size     = new System.Drawing.Size(150, 33);
            this.btnRefresh.Name     = "btnRefresh";
            this.btnRefresh.Text     = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click   += new System.EventHandler(this.btnRefresh_Click);

            // dgvTasks — растягивается
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // TasksForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.panelButtons);
            this.Name = "TasksForm";
            this.Text = "Задачи";
            this.Load += new System.EventHandler(this.TasksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}