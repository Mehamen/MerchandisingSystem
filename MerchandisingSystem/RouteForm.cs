using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class RouteForm : Form
    {
        private const double RostovLat = 47.2357;
        private const double RostovLon = 39.7015;

        private GMapOverlay markersOverlay;
        private GMapOverlay routeOverlay;
        private GMapOverlay selectionOverlay;
        private List<StoreMapItem> allStores = new List<StoreMapItem>();

        // выделение прямоугольником
        private bool isSelecting = false;
        private System.Drawing.Point selStart;
        private System.Drawing.Point selCurrent;

        public RouteForm()
        {
            InitializeComponent();
        }

        private void RouteForm_Load(object sender, EventArgs e)
        {
            GMap.NET.MapProviders.GMapProvider.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl.Position    = new PointLatLng(RostovLat, RostovLon);
            gMapControl.Zoom        = 12;
            gMapControl.DragButton  = MouseButtons.Left;

            markersOverlay   = new GMapOverlay("markers");
            routeOverlay     = new GMapOverlay("route");
            selectionOverlay = new GMapOverlay("selection");
            gMapControl.Overlays.Add(routeOverlay);
            gMapControl.Overlays.Add(markersOverlay);
            gMapControl.Overlays.Add(selectionOverlay);

            // правая кнопка — перетаскивание карты
            // левая — выделение области
            gMapControl.DragButton = MouseButtons.Right;
            gMapControl.OnMarkerClick += GMapControl_OnMarkerClick;
            gMapControl.MouseDown  += GMap_MouseDown;
            gMapControl.MouseMove  += GMap_MouseMove;
            gMapControl.MouseUp    += GMap_MouseUp;
            gMapControl.Paint      += GMap_Paint;

            dtpRouteDate.Value = DateTime.Today.AddDays(1);

            LoadMerchandisers();
            LoadStores();
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

        private void LoadStores()
        {
            allStores.Clear();
            lstAvailable.Items.Clear();
            markersOverlay.Markers.Clear();

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(
                        "SELECT id, name, address, latitude, longitude FROM stores ORDER BY name", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new StoreMapItem
                        {
                            Id      = reader.GetInt32(0),
                            Name    = reader.GetString(1),
                            Address = reader["address"] == DBNull.Value ? "" : reader.GetString(2),
                            Lat     = reader["latitude"]  == DBNull.Value ? (double?)null : reader.GetDouble(3),
                            Lon     = reader["longitude"] == DBNull.Value ? (double?)null : reader.GetDouble(4)
                        };
                        allStores.Add(item);
                        lstAvailable.Items.Add(item);

                        if (item.Lat.HasValue && item.Lon.HasValue)
                        {
                            var marker = new GMarkerGoogle(
                                new PointLatLng(item.Lat.Value, item.Lon.Value),
                                GMarkerGoogleType.blue_dot);
                            marker.ToolTipText = item.Name;
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            marker.Tag = item;
                            markersOverlay.Markers.Add(marker);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки точек: " + ex.Message, "Ошибка");
            }
        }

        private void GMapControl_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            if (marker.Tag is StoreMapItem item)
            {
                // если точка в доступных — добавить в маршрут
                if (lstAvailable.Items.Contains(item))
                {
                    lstAvailable.Items.Remove(item);
                    lstRoute.Items.Add(item);
                    DrawRoute();
                }
                // если уже в маршруте — показать порядковый номер
                else
                {
                    int idx = lstRoute.Items.IndexOf(item);
                    MessageBox.Show(item.Name + "\nПорядок в маршруте: " + (idx + 1), "Точка маршрута");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedItem is StoreMapItem item)
            {
                lstAvailable.Items.Remove(item);
                lstRoute.Items.Add(item);
                DrawRoute();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstRoute.SelectedItem is StoreMapItem item)
            {
                lstRoute.Items.Remove(item);
                lstAvailable.Items.Add(item);
                DrawRoute();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int idx = lstRoute.SelectedIndex;
            if (idx <= 0) return;
            var item = lstRoute.Items[idx];
            lstRoute.Items.RemoveAt(idx);
            lstRoute.Items.Insert(idx - 1, item);
            lstRoute.SelectedIndex = idx - 1;
            DrawRoute();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int idx = lstRoute.SelectedIndex;
            if (idx < 0 || idx >= lstRoute.Items.Count - 1) return;
            var item = lstRoute.Items[idx];
            lstRoute.Items.RemoveAt(idx);
            lstRoute.Items.Insert(idx + 1, item);
            lstRoute.SelectedIndex = idx + 1;
            DrawRoute();
        }

        private void DrawRoute()
        {
            routeOverlay.Routes.Clear();
            markersOverlay.Markers.Clear();

            var waypoints = new List<StoreMapItem>();
            for (int i = 0; i < lstRoute.Items.Count; i++)
            {
                var item = lstRoute.Items[i] as StoreMapItem;
                if (item != null && item.Lat.HasValue && item.Lon.HasValue)
                    waypoints.Add(item);
            }

            // маркеры маршрутных точек
            for (int i = 0; i < waypoints.Count; i++)
            {
                var pt = new PointLatLng(waypoints[i].Lat.Value, waypoints[i].Lon.Value);
                var marker = new GMarkerGoogle(pt, GMarkerGoogleType.red_dot);
                marker.ToolTipText = (i + 1) + ". " + waypoints[i].Name;
                marker.ToolTipMode = MarkerTooltipMode.Always;
                markersOverlay.Markers.Add(marker);
            }

            // синие маркеры для доступных точек
            foreach (StoreMapItem item in lstAvailable.Items)
            {
                if (!item.Lat.HasValue || !item.Lon.HasValue) continue;
                var marker = new GMarkerGoogle(
                    new PointLatLng(item.Lat.Value, item.Lon.Value),
                    GMarkerGoogleType.blue_dot);
                marker.ToolTipText = item.Name;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                markersOverlay.Markers.Add(marker);
            }

            if (waypoints.Count < 2) return;

            // строим маршрут через OSRM по дорогам
            try
            {
                var coords = new System.Text.StringBuilder();
                foreach (var w in waypoints)
                    coords.Append(w.Lon.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        + "," + w.Lat.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) + ";");
                coords.Length--; // убрать последнюю ;

                string url = "http://router.project-osrm.org/route/v1/driving/"
                    + coords + "?overview=full&geometries=geojson";

                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "MerchandisingSystem/1.0");
                    string json = client.DownloadString(url);
                    var obj = JObject.Parse(json);

                    var coordinates = obj["routes"][0]["geometry"]["coordinates"] as JArray;
                    var routePoints = new List<PointLatLng>();
                    foreach (var coord in coordinates)
                        routePoints.Add(new PointLatLng((double)coord[1], (double)coord[0]));

                    var route = new GMapRoute(routePoints, "route");
                    route.Stroke = new Pen(Color.Red, 4);
                    routeOverlay.Routes.Add(route);
                }
            }
            catch
            {
                // если нет интернета — рисуем прямую
                var pts = new List<PointLatLng>();
                foreach (var w in waypoints)
                    pts.Add(new PointLatLng(w.Lat.Value, w.Lon.Value));
                var route = new GMapRoute(pts, "route");
                route.Stroke = new Pen(Color.OrangeRed, 3) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                routeOverlay.Routes.Add(route);
            }
        }

        private void btnSaveRoute_Click(object sender, EventArgs e)
        {
            if (cmbMerch.SelectedItem == null)
            {
                MessageBox.Show("Выберите мерчандайзера!", "Ошибка");
                return;
            }
            if (lstRoute.Items.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну точку в маршрут!", "Ошибка");
                return;
            }

            int merchId = ((ComboItem)cmbMerch.SelectedItem).Id;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        var cmdRoute = new NpgsqlCommand(
                            "INSERT INTO routes (merchandiser_id, route_date, status) VALUES (@m, @d, 'новый') RETURNING id", conn);
                        cmdRoute.Parameters.AddWithValue("m", merchId);
                        cmdRoute.Parameters.AddWithValue("d", dtpRouteDate.Value.Date);
                        int routeId = (int)cmdRoute.ExecuteScalar();

                        for (int i = 0; i < lstRoute.Items.Count; i++)
                        {
                            var item = lstRoute.Items[i] as StoreMapItem;
                            var cmdPt = new NpgsqlCommand(
                                "INSERT INTO route_points (route_id, store_id, point_order) VALUES (@r, @s, @o)", conn);
                            cmdPt.Parameters.AddWithValue("r", routeId);
                            cmdPt.Parameters.AddWithValue("s", item.Id);
                            cmdPt.Parameters.AddWithValue("o", i + 1);
                            cmdPt.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }
                MessageBox.Show("Маршрут сохранён!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка");
            }
        }
        // ── выделение прямоугольником ──────────────────────────────────

        private void GMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isSelecting  = true;
                selStart     = e.Location;
                selCurrent   = e.Location;
            }
        }

        private void GMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                selCurrent = e.Location;
                gMapControl.Invalidate(); // перерисовать прямоугольник
            }
        }

        private void GMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isSelecting)
            {
                isSelecting = false;
                gMapControl.Invalidate();

                // координаты прямоугольника в lat/lng
                int x1 = Math.Min(selStart.X, selCurrent.X);
                int y1 = Math.Min(selStart.Y, selCurrent.Y);
                int x2 = Math.Max(selStart.X, selCurrent.X);
                int y2 = Math.Max(selStart.Y, selCurrent.Y);

                if (Math.Abs(x2 - x1) < 5 || Math.Abs(y2 - y1) < 5) return; // слишком маленькое выделение

                PointLatLng topLeft     = gMapControl.FromLocalToLatLng(x1, y1);
                PointLatLng bottomRight = gMapControl.FromLocalToLatLng(x2, y2);

                double latMax = topLeft.Lat;
                double latMin = bottomRight.Lat;
                double lonMin = topLeft.Lng;
                double lonMax = bottomRight.Lng;

                int added = 0;
                // ищем все доступные точки внутри прямоугольника
                var toAdd = new List<StoreMapItem>();
                foreach (StoreMapItem item in lstAvailable.Items)
                {
                    if (item.Lat.HasValue && item.Lon.HasValue &&
                        item.Lat.Value >= latMin && item.Lat.Value <= latMax &&
                        item.Lon.Value >= lonMin && item.Lon.Value <= lonMax)
                    {
                        toAdd.Add(item);
                        added++;
                    }
                }

                foreach (var item in toAdd)
                {
                    lstAvailable.Items.Remove(item);
                    lstRoute.Items.Add(item);
                }

                if (added > 0)
                    DrawRoute();
                else
                    MessageBox.Show("В выделенной области нет торговых точек.", "Выделение");
            }
        }

        private void GMap_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (isSelecting)
            {
                int x = Math.Min(selStart.X, selCurrent.X);
                int y = Math.Min(selStart.Y, selCurrent.Y);
                int w = Math.Abs(selCurrent.X - selStart.X);
                int h = Math.Abs(selCurrent.Y - selStart.Y);

                using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(40, 0, 120, 215)))
                using (var pen   = new System.Drawing.Pen(System.Drawing.Color.FromArgb(180, 0, 120, 215), 2))
                {
                    e.Graphics.FillRectangle(brush, x, y, w, h);
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                }
            }
        }
    }
}
