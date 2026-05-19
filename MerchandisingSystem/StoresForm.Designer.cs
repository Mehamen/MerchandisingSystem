namespace MerchandisingSystem
{
    partial class StoresForm
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
        private System.Windows.Forms.Panel panelButtons;

        private void InitializeComponent()
        {
            this.dgvStores    = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd       = new System.Windows.Forms.Button();
            this.btnEdit      = new System.Windows.Forms.Button();
            this.btnDelete    = new System.Windows.Forms.Button();
            this.btnRefresh   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // panelButtons — правая панель
            this.panelButtons.Dock  = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Width = 130;
            this.panelButtons.Name  = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnAdd, btnEdit, btnDelete, btnRefresh
            });

            // кнопки внутри панели
            this.btnAdd.Location = new System.Drawing.Point(5, 5);
            this.btnAdd.Size     = new System.Drawing.Size(115, 33);
            this.btnAdd.Name     = "btnAdd";
            this.btnAdd.Text     = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(5, 44);
            this.btnEdit.Size     = new System.Drawing.Size(115, 33);
            this.btnEdit.Name     = "btnEdit";
            this.btnEdit.Text     = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click   += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(5, 83);
            this.btnDelete.Size     = new System.Drawing.Size(115, 33);
            this.btnDelete.Name     = "btnDelete";
            this.btnDelete.Text     = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Location = new System.Drawing.Point(5, 122);
            this.btnRefresh.Size     = new System.Drawing.Size(115, 33);
            this.btnRefresh.Name     = "btnRefresh";
            this.btnRefresh.Text     = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click   += new System.EventHandler(this.btnRefresh_Click);

            // dgvStores — растягивается на всё оставшееся место
            this.dgvStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStores.Name = "dgvStores";
            this.dgvStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // StoresForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvStores);
            this.Controls.Add(this.panelButtons);
            this.Name = "StoresForm";
            this.Text = "Торговые точки";
            this.Load += new System.EventHandler(this.StoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStores;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
    }
}