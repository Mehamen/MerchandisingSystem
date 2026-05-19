using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MerchandisingSystem
{
    public partial class MainForm : Form
    {
        private string userRole;
        private string userName;
        public MainForm(string role, string name)
        {
            InitializeComponent();
            userRole = role;
            userName = name;
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "  Пользователь: " + userName + "   |   " + DateTime.Now.ToString("dd.MM.yyyy");

            if (userRole == "merchandiser")
                btnReports.Visible = false;
        }
        private void btnStores_Click(object sender, EventArgs e)
        {
            OpenForm(new StoresForm());
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            OpenForm(new TasksForm());
        }

        private void btnRoutes_Click(object sender, EventArgs e)
        {
            OpenForm(new RouteForm());
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            OpenForm(new MapForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenForm(new ReportsForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из системы?", "Выход",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OpenForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

    }
}
