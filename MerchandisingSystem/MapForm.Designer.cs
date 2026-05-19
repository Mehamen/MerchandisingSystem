namespace MerchandisingSystem
{
    partial class MapForm
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
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblStoreList;
        private System.Windows.Forms.ListBox lstStores;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnGoToStore;

        private void InitializeComponent()
        {
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.panelRight  = new System.Windows.Forms.Panel();
            this.lblStoreList = new System.Windows.Forms.Label();
            this.lstStores   = new System.Windows.Forms.ListBox();
            this.btnShowAll  = new System.Windows.Forms.Button();
            this.btnGoToStore = new System.Windows.Forms.Button();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();

            // gMapControl
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MaxZoom = 18;

            // panelRight
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Width = 200;
            this.panelRight.Name = "panelRight";
            this.panelRight.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblStoreList, lstStores, btnGoToStore, btnShowAll
            });

            // lblStoreList
            this.lblStoreList.Text = "Торговые точки:";
            this.lblStoreList.Location = new System.Drawing.Point(5, 5);
            this.lblStoreList.Size = new System.Drawing.Size(185, 20);

            // lstStores
            this.lstStores.Location = new System.Drawing.Point(5, 28);
            this.lstStores.Size = new System.Drawing.Size(185, 330);
            this.lstStores.Name = "lstStores";
            this.lstStores.DoubleClick += new System.EventHandler(this.lstStores_DoubleClick);

            // btnGoToStore
            this.btnGoToStore.Text = "Перейти к точке";
            this.btnGoToStore.Location = new System.Drawing.Point(5, 365);
            this.btnGoToStore.Size = new System.Drawing.Size(185, 30);
            this.btnGoToStore.Name = "btnGoToStore";
            this.btnGoToStore.Click += new System.EventHandler(this.btnGoToStore_Click);

            // btnShowAll
            this.btnShowAll.Text = "Показать все";
            this.btnShowAll.Location = new System.Drawing.Point(5, 400);
            this.btnShowAll.Size = new System.Drawing.Size(185, 30);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // MapForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Text = "Карта торговых точек";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.panelRight);
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}