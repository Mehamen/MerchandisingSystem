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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new Npgsql.NpgsqlCommand(
                        "SELECT id, full_name, role, password_hash FROM users WHERE login = @login", conn);
                    cmd.Parameters.AddWithValue("login", login);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string hash = reader.GetString(3);
                        if (BCrypt.Net.BCrypt.Verify(password, hash))
                        {
                            string role = reader.GetString(2);
                            string fullName = reader.GetString(1);
                            Application.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
                            MessageBox.Show("Добро пожаловать, " + fullName + "!" , "Успех");
                            MainForm mainForm = new MainForm(role, fullName);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль!", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при попытке входа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
