using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value   = DateTime.Today;

            LoadCompleted();
            LoadByEmployee();
            LoadByStatus();
            LoadHistory();

            // обновлять вкладку при переключении
            tabControl.SelectedIndexChanged += (s, ev) =>
            {
                switch (tabControl.SelectedIndex)
                {
                    case 1: LoadByEmployee(); break;
                    case 2: LoadByStatus();   break;
                    case 3: LoadHistory();    break;
                }
            };
        }

        // ── Вкладка 1: Выполненные задачи ──────────────────────────────

        private void LoadCompleted()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(@"
                        SELECT t.id,
                               s.name        AS store,
                               u.full_name   AS merchandiser,
                               t.task_type,
                               t.description,
                               t.planned_date,
                               tr.completed_at,
                               tr.comment
                        FROM tasks t
                        JOIN stores s       ON s.id = t.store_id
                        JOIN merchandisers m ON m.id = t.merchandiser_id
                        JOIN users u         ON u.id = m.user_id
                        LEFT JOIN task_reports tr ON tr.task_id = t.id
                        WHERE t.status = 'выполнена'
                          AND t.planned_date BETWEEN @from AND @to
                        ORDER BY tr.completed_at DESC", conn);
                    cmd.Parameters.AddWithValue("from", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("to",   dtpTo.Value.Date);

                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table   = new DataTable();
                    adapter.Fill(table);

                    dgvCompleted.DataSource = table;
                    dgvCompleted.Columns["id"].Visible             = false;
                    dgvCompleted.Columns["store"].HeaderText        = "Торговая точка";
                    dgvCompleted.Columns["merchandiser"].HeaderText = "Мерчандайзер";
                    dgvCompleted.Columns["task_type"].HeaderText    = "Тип задачи";
                    dgvCompleted.Columns["description"].HeaderText  = "Описание";
                    dgvCompleted.Columns["planned_date"].HeaderText = "Плановая дата";
                    dgvCompleted.Columns["completed_at"].HeaderText = "Выполнено";
                    dgvCompleted.Columns["comment"].HeaderText      = "Комментарий";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnRefreshCompleted_Click(object sender, EventArgs e) => LoadCompleted();

        // ── Вкладка 2: По сотрудникам ───────────────────────────────────

        private void LoadByEmployee()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(@"
                        SELECT u.full_name                              AS merchandiser,
                               COUNT(*)                                 AS total,
                               COUNT(*) FILTER (WHERE t.status = 'выполнена')  AS done,
                               COUNT(*) FILTER (WHERE t.status = 'в работе')   AS in_progress,
                               COUNT(*) FILTER (WHERE t.status = 'новая')      AS new_tasks,
                               COUNT(*) FILTER (WHERE t.status = 'отменена')   AS cancelled
                        FROM tasks t
                        JOIN merchandisers m ON m.id = t.merchandiser_id
                        JOIN users u         ON u.id = m.user_id
                        GROUP BY u.full_name
                        ORDER BY total DESC", conn);

                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table   = new DataTable();
                    adapter.Fill(table);

                    dgvByEmployee.DataSource = table;
                    dgvByEmployee.Columns["merchandiser"].HeaderText = "Мерчандайзер";
                    dgvByEmployee.Columns["total"].HeaderText        = "Всего";
                    dgvByEmployee.Columns["done"].HeaderText         = "Выполнено";
                    dgvByEmployee.Columns["in_progress"].HeaderText  = "В работе";
                    dgvByEmployee.Columns["new_tasks"].HeaderText    = "Новых";
                    dgvByEmployee.Columns["cancelled"].HeaderText    = "Отменено";

                    // подсветить строки
                    foreach (DataGridViewRow row in dgvByEmployee.Rows)
                    {
                        long total = row.Cells["total"].Value is DBNull ? 0 : Convert.ToInt64(row.Cells["total"].Value);
                        long done  = row.Cells["done"].Value  is DBNull ? 0 : Convert.ToInt64(row.Cells["done"].Value);
                        if (total > 0 && done == total)
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            LoadByEmployee();
            LoadByStatus();
            LoadHistory();
        }

        // ── Вкладка 3: По статусам ──────────────────────────────────────

        private void LoadByStatus()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(@"
                        SELECT status          AS status,
                               COUNT(*)        AS count,
                               ROUND(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER(), 1) AS percent
                        FROM tasks
                        GROUP BY status
                        ORDER BY count DESC", conn);

                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table   = new DataTable();
                    adapter.Fill(table);

                    dgvByStatus.DataSource = table;
                    dgvByStatus.Columns["status"].HeaderText  = "Статус";
                    dgvByStatus.Columns["count"].HeaderText   = "Количество";
                    dgvByStatus.Columns["percent"].HeaderText = "% от всех";

                    // цвет по статусу
                    foreach (DataGridViewRow row in dgvByStatus.Rows)
                    {
                        string status = row.Cells["status"].Value?.ToString() ?? "";
                        switch (status)
                        {
                            case "выполнена": row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;  break;
                            case "в работе":  row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow; break;
                            case "отменена":  row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;  break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        // ── Вкладка 4: История посещений ────────────────────────────────

        private void LoadHistory()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(@"
                        SELECT s.name        AS store,
                               u.full_name   AS merchandiser,
                               t.task_type,
                               tr.completed_at,
                               tr.comment,
                               tr.status
                        FROM task_reports tr
                        JOIN tasks t         ON t.id  = tr.task_id
                        JOIN stores s        ON s.id  = t.store_id
                        JOIN merchandisers m ON m.id  = t.merchandiser_id
                        JOIN users u         ON u.id  = m.user_id
                        ORDER BY tr.completed_at DESC
                        LIMIT 200", conn);

                    var adapter = new NpgsqlDataAdapter(cmd);
                    var table   = new DataTable();
                    adapter.Fill(table);

                    dgvHistory.DataSource = table;
                    dgvHistory.Columns["store"].HeaderText        = "Торговая точка";
                    dgvHistory.Columns["merchandiser"].HeaderText = "Мерчандайзер";
                    dgvHistory.Columns["task_type"].HeaderText    = "Тип задачи";
                    dgvHistory.Columns["completed_at"].HeaderText = "Дата/Время";
                    dgvHistory.Columns["comment"].HeaderText      = "Комментарий";
                    dgvHistory.Columns["status"].HeaderText       = "Статус";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }
    }
}

