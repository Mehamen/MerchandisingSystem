using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MerchandisingSystem
{
    public partial class StoresForm : Form
    {
        public StoresForm()
        {
            InitializeComponent();
        }

        private void StoresForm_Load(object sender, EventArgs e)
        {
            UITheme.StyleGrid(dgvStores);
            UITheme.StyleButton(btnAdd,     UITheme.AccentBlue);
            UITheme.StyleButton(btnEdit,    UITheme.AccentBlue);
            UITheme.StyleButton(btnDelete,  UITheme.AccentRed);
            UITheme.StyleButton(btnRefresh, UITheme.GridHeader);
            LoadStores();
        }
        private void LoadStores()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(
                        "SELECT id, name, address, store_type, comment FROM stores ORDER BY name", conn);
                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvStores.DataSource = table;

                    dgvStores.Columns["id"].Visible = false;
                    dgvStores.Columns["name"].HeaderText       = "Название";
                    dgvStores.Columns["address"].HeaderText    = "Адрес";
                    dgvStores.Columns["store_type"].HeaderText = "Тип";
                    dgvStores.Columns["comment"].HeaderText    = "Комментарий";

                    dgvStores.ReadOnly = true;
                    dgvStores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                    dgvStores.MultiSelect = false;
                    dgvStores.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new StoreEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadStores();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите торговую точку!");
                return;
            }
            int id = (int)dgvStores.SelectedRows[0].Cells["id"].Value;
            var form = new StoreEditForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadStores();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите торговую точку!");
                return;
            }
            if (MessageBox.Show("Удалить точку?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)dgvStores.SelectedRows[0].Cells["id"].Value;
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("DELETE FROM stores WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadStores();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStores();
        }
    }

}

