using System;
using System.Windows.Forms;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class TaskStatusForm : Form
    {
        private int taskId;
        private string currentStatus;

        public TaskStatusForm(int id, string status)
        {
            InitializeComponent();
            taskId = id;
            currentStatus = status;
        }

        private void TaskStatusForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new[] { "новая", "в работе", "выполнена", "отменена" });
            cmbStatus.Text = currentStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус!", "Ошибка");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    var cmdTask = new NpgsqlCommand("UPDATE tasks SET status = @status WHERE id = @id", conn);
                    cmdTask.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());
                    cmdTask.Parameters.AddWithValue("id", taskId);
                    cmdTask.ExecuteNonQuery();

                    if (!string.IsNullOrWhiteSpace(txtComment.Text))
                    {
                        var cmdReport = new NpgsqlCommand(@"
                            INSERT INTO task_reports (task_id, comment, completed_at, status)
                            VALUES (@task, @comment, @dt, @status)", conn);
                        cmdReport.Parameters.AddWithValue("task",    taskId);
                        cmdReport.Parameters.AddWithValue("comment", txtComment.Text.Trim());
                        cmdReport.Parameters.AddWithValue("dt",      DateTime.Now);
                        cmdReport.Parameters.AddWithValue("status",  cmbStatus.SelectedItem.ToString());
                        cmdReport.ExecuteNonQuery();
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
