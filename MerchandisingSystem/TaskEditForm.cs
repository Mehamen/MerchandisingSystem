using System;
using System.Windows.Forms;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class TaskEditForm : Form
    {
        public TaskEditForm()
        {
            InitializeComponent();
        }

        private void TaskEditForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.AddRange(new[]
            {
                "проверка выкладки товара",
                "проверка ценников",
                "фотоотчет",
                "проверка остатков",
                "проверка рекламных материалов",
                "аудит торговой точки"
            });
            cmbType.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today.AddDays(1);

            LoadStores();
            LoadMerchandisers();
        }

        private void LoadStores()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("SELECT id, name FROM stores ORDER BY name", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbStore.Items.Add(new ComboItem(reader.GetInt32(0), reader.GetString(1)));
                }
                if (cmbStore.Items.Count > 0) cmbStore.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки точек: " + ex.Message, "Ошибка");
            }
        }

        private void LoadMerchandisers()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(
                        "SELECT m.id, u.full_name FROM merchandisers m JOIN users u ON u.id = m.user_id ORDER BY u.full_name", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbMerch.Items.Add(new ComboItem(reader.GetInt32(0), reader.GetString(1)));
                }
                if (cmbMerch.Items.Count > 0) cmbMerch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки мерчандайзеров: " + ex.Message, "Ошибка");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStore.SelectedItem == null) { MessageBox.Show("Выберите торговую точку!", "Ошибка"); return; }
            if (cmbMerch.SelectedItem == null) { MessageBox.Show("Выберите мерчандайзера!", "Ошибка"); return; }

            int storeId = ((ComboItem)cmbStore.SelectedItem).Id;
            int merchId = ((ComboItem)cmbMerch.SelectedItem).Id;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(@"
                        INSERT INTO tasks (store_id, merchandiser_id, task_type, description, planned_date, status)
                        VALUES (@store, @merch, @type, @desc, @date, 'новая')", conn);
                    cmd.Parameters.AddWithValue("store", storeId);
                    cmd.Parameters.AddWithValue("merch", merchId);
                    cmd.Parameters.AddWithValue("type",  cmbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("desc",  txtDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("date",  dtpDate.Value.Date);
                    cmd.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public class ComboItem
    {
        public int Id { get; }
        public string Name { get; }
        public ComboItem(int id, string name) { Id = id; Name = name; }
        public override string ToString() => Name;
    }
}
