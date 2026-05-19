using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class TasksForm : Form
    {
        public TasksForm()
        {
            InitializeComponent();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.Items.Add("Все");
            cmbFilterStatus.Items.Add("новая");
            cmbFilterStatus.Items.Add("в работе");
            cmbFilterStatus.Items.Add("выполнена");
            cmbFilterStatus.Items.Add("отменена");
            cmbFilterStatus.SelectedIndex = 0;

            dgvTasks.ReadOnly = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;
            dgvTasks.AllowUserToAddRows = false;
            UITheme.StyleGrid(dgvTasks);
            UITheme.StyleButton(btnAdd,          UITheme.AccentGreen);
            UITheme.StyleButton(btnChangeStatus, UITheme.AccentBlue);
            UITheme.StyleButton(btnDelete,       UITheme.AccentRed);
            UITheme.StyleButton(btnRefresh,      UITheme.GridHeader);

            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                string filter = cmbFilterStatus.SelectedItem?.ToString();
                string where = (filter == "Все" || filter == null) ? "" : "WHERE t.status = @status";

                string sql = $@"
                    SELECT t.id, s.name AS store, u.full_name AS merchandiser,
                           t.task_type, t.description, t.planned_date, t.status, t.created_at
                    FROM tasks t
                    LEFT JOIN stores s ON s.id = t.store_id
                    LEFT JOIN merchandisers m ON m.id = t.merchandiser_id
                    LEFT JOIN users u ON u.id = m.user_id
                    {where}
                    ORDER BY t.planned_date DESC";

                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(sql, conn);
                    if (where != "")
                        cmd.Parameters.AddWithValue("status", filter);

                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvTasks.DataSource = table;

                    dgvTasks.Columns["id"].Visible = false;
                    dgvTasks.Columns["store"].HeaderText        = "Торговая точка";
                    dgvTasks.Columns["merchandiser"].HeaderText = "Мерчандайзер";
                    dgvTasks.Columns["task_type"].HeaderText    = "Тип задачи";
                    dgvTasks.Columns["description"].HeaderText  = "Описание";
                    dgvTasks.Columns["planned_date"].HeaderText = "Дата";
                    dgvTasks.Columns["status"].HeaderText       = "Статус";
                    dgvTasks.Columns["created_at"].HeaderText   = "Создана";

                    dgvTasks.Columns["store"].Width        = 150;
                    dgvTasks.Columns["merchandiser"].Width = 130;
                    dgvTasks.Columns["task_type"].Width    = 120;
                    dgvTasks.Columns["description"].Width  = 80;
                    dgvTasks.Columns["planned_date"].Width = 80;
                    dgvTasks.Columns["status"].Width       = 70;
                    dgvTasks.Columns["created_at"].Width   = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки задач: " + ex.Message, "Ошибка");
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TaskEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите задачу!", "Внимание");
                return;
            }

            int id = (int)dgvTasks.SelectedRows[0].Cells["id"].Value;
            string currentStatus = dgvTasks.SelectedRows[0].Cells["status"].Value.ToString();

            var form = new TaskStatusForm(id, currentStatus);
            if (form.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите задачу!", "Внимание");
                return;
            }

            if (MessageBox.Show("Удалить задачу?", "Подтверждение",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            int id = (int)dgvTasks.SelectedRows[0].Cells["id"].Value;
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    // сначала удаляем отчёты по задаче
                    var cmdRep = new NpgsqlCommand("DELETE FROM task_reports WHERE task_id = @id", conn);
                    cmdRep.Parameters.AddWithValue("id", id);
                    cmdRep.ExecuteNonQuery();

                    var cmd = new NpgsqlCommand("DELETE FROM tasks WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}
