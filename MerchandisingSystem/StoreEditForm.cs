using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class StoreEditForm : Form
    {
        private int? storeId;

        public StoreEditForm(int id = 0)
        {
            InitializeComponent();
            storeId = id == 0 ? (int?)null : id;
        }

        private void StoreEditForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.AddRange(new[] { "супермаркет", "магазин", "киоск", "гипермаркет" });

            // плейсхолдеры
            SetPlaceholder(txtCity,     "Ростов-на-Дону");
            SetPlaceholder(txtStreet,   "ул. Ленина");
            SetPlaceholder(txtBuilding, "1");

            if (storeId.HasValue)
            {
                this.Text = "Редактировать точку";
                LoadStore();
            }
            else
            {
                this.Text = "Добавить точку";
            }
        }

        private void SetPlaceholder(TextBox tb, string text)
        {
            tb.ForeColor = System.Drawing.Color.Gray;
            tb.Text = text;
            tb.GotFocus  += (s, e) => { if (tb.ForeColor == System.Drawing.Color.Gray) { tb.Text = ""; tb.ForeColor = System.Drawing.Color.Black; } };
            tb.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(tb.Text)) { tb.ForeColor = System.Drawing.Color.Gray; tb.Text = text; } };
        }

        private string GetAddress()
        {
            string city     = txtCity.ForeColor     == System.Drawing.Color.Gray ? "" : txtCity.Text.Trim();
            string street   = txtStreet.ForeColor   == System.Drawing.Color.Gray ? "" : txtStreet.Text.Trim();
            string building = txtBuilding.ForeColor == System.Drawing.Color.Gray ? "" : txtBuilding.Text.Trim();
            return string.Join(", ", new[] { city, street, building }).Trim(',', ' ');
        }

        private void LoadStore()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    "SELECT name, address, store_type, comment, latitude, longitude FROM stores WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", storeId.Value);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text    = reader["name"].ToString();
                    cmbType.Text    = reader["store_type"].ToString();
                    txtComment.Text = reader["comment"].ToString();
                    txtLat.Text     = reader["latitude"]  == DBNull.Value ? "" : reader["latitude"].ToString();
                    txtLon.Text     = reader["longitude"] == DBNull.Value ? "" : reader["longitude"].ToString();

                    // разбиваем адрес обратно на поля
                    string addr = reader["address"] == DBNull.Value ? "" : reader["address"].ToString();
                    var parts = addr.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 1) { txtCity.Text = parts[0];     txtCity.ForeColor = System.Drawing.Color.Black; }
                    if (parts.Length >= 2) { txtStreet.Text = parts[1];   txtStreet.ForeColor = System.Drawing.Color.Black; }
                    if (parts.Length >= 3) { txtBuilding.Text = parts[2]; txtBuilding.ForeColor = System.Drawing.Color.Black; }
                }
            }
        }

        private void btnGeocode_Click(object sender, EventArgs e)
        {
            string address = GetAddress();
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Введите хотя бы город!", "Ошибка");
                return;
            }

            btnGeocode.Enabled = false;
            btnGeocode.Text    = "Поиск...";

            try
            {
                string url = "https://nominatim.openstreetmap.org/search?q="
                    + Uri.EscapeDataString(address)
                    + "&format=json&limit=1&accept-language=ru";

                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "MerchandisingSystem/1.0");
                    string json = client.DownloadString(url);

                    var arr = JArray.Parse(json);
                    if (arr.Count > 0)
                    {
                        string lat = arr[0]["lat"].ToString();
                        string lon = arr[0]["lon"].ToString();

                        txtLat.Text = lat;
                        txtLon.Text = lon;
                        MessageBox.Show("Координаты найдены!\nШирота: " + lat + "\nДолгота: " + lon, "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Адрес не найден. Проверьте написание.", "Не найдено");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка геокодирования: " + ex.Message, "Ошибка");
            }
            finally
            {
                btnGeocode.Enabled = true;
                btnGeocode.Text    = "Найти координаты по адресу";
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название!", "Ошибка");
                return;
            }

            string fullAddress = GetAddress();

            double? lat = null, lon = null;
            if (!string.IsNullOrWhiteSpace(txtLat.Text))
            {
                if (!double.TryParse(txtLat.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double parsedLat))
                {
                    MessageBox.Show("Неверный формат широты!", "Ошибка");
                    return;
                }
                lat = parsedLat;
            }
            if (!string.IsNullOrWhiteSpace(txtLon.Text))
            {
                if (!double.TryParse(txtLon.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double parsedLon))
                {
                    MessageBox.Show("Неверный формат долготы!", "Ошибка");
                    return;
                }
                lon = parsedLon;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    NpgsqlCommand cmd;
                    if (storeId.HasValue)
                    {
                        cmd = new NpgsqlCommand(
                            "UPDATE stores SET name=@name, address=@address, store_type=@type, comment=@comment, latitude=@lat, longitude=@lon WHERE id=@id", conn);
                        cmd.Parameters.AddWithValue("id", storeId.Value);
                    }
                    else
                    {
                        cmd = new NpgsqlCommand(
                            "INSERT INTO stores (name, address, store_type, comment, latitude, longitude) VALUES (@name, @address, @type, @comment, @lat, @lon)", conn);
                    }
                    cmd.Parameters.AddWithValue("name",    txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("address", fullAddress);
                    cmd.Parameters.AddWithValue("type",    cmbType.Text ?? "");
                    cmd.Parameters.AddWithValue("comment", txtComment.Text ?? "");
                    cmd.Parameters.AddWithValue("lat",     (object)lat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("lon",     (object)lon ?? DBNull.Value);
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
}
