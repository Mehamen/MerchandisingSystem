using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Npgsql;

namespace MerchandisingSystem
{
    public partial class MapForm : Form
    {
        // Ростов-на-Дону
        private const double RostovLat = 47.2357;
        private const double RostovLon = 39.7015;

        private GMapOverlay storesOverlay;
        private List<StoreMapItem> stores = new List<StoreMapItem>();

        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            GMap.NET.MapProviders.GMapProvider.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl.Position    = new PointLatLng(RostovLat, RostovLon);
            gMapControl.Zoom        = 12;
            gMapControl.DragButton  = System.Windows.Forms.MouseButtons.Left;

            storesOverlay = new GMapOverlay("stores");
            gMapControl.Overlays.Add(storesOverlay);

            gMapControl.OnMarkerClick += GMapControl_OnMarkerClick;

            LoadStores();
        }

        private void LoadStores()
        {
            stores.Clear();
            storesOverlay.Markers.Clear();
            lstStores.Items.Clear();

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
                        double? lat = reader["latitude"]  == DBNull.Value ? (double?)null : reader.GetDouble(3);
                        double? lon = reader["longitude"] == DBNull.Value ? (double?)null : reader.GetDouble(4);
                        var item = new StoreMapItem
                        {
                            Id      = reader.GetInt32(0),
                            Name    = reader.GetString(1),
                            Address = reader["address"] == DBNull.Value ? "" : reader.GetString(2),
                            Lat     = lat,
                            Lon     = lon
                        };
                        stores.Add(item);
                        lstStores.Items.Add(item);

                        if (lat.HasValue && lon.HasValue)
                        {
                            var marker = new GMarkerGoogle(
                                new PointLatLng(lat.Value, lon.Value),
                                GMarkerGoogleType.red_dot);
                            marker.ToolTipText = item.Name;
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            marker.Tag = item;
                            storesOverlay.Markers.Add(marker);
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
                MessageBox.Show(
                    "Название: " + item.Name + "\nАдрес: " + item.Address +
                    "\nКоординаты: " + item.Lat + ", " + item.Lon,
                    "Торговая точка");
            }
        }

        private void lstStores_DoubleClick(object sender, EventArgs e)
        {
            GoToSelected();
        }

        private void btnGoToStore_Click(object sender, EventArgs e)
        {
            GoToSelected();
        }

        private void GoToSelected()
        {
            if (lstStores.SelectedItem is StoreMapItem item && item.Lat.HasValue && item.Lon.HasValue)
            {
                gMapControl.Position = new PointLatLng(item.Lat.Value, item.Lon.Value);
                gMapControl.Zoom = 15;
            }
            else if (lstStores.SelectedItem != null)
            {
                MessageBox.Show("У этой точки нет координат!", "Внимание");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            gMapControl.Position = new PointLatLng(RostovLat, RostovLon);
            gMapControl.Zoom = 12;
        }
    }

    public class StoreMapItem
    {
        public int     Id      { get; set; }
        public string  Name    { get; set; }
        public string  Address { get; set; }
        public double? Lat     { get; set; }
        public double? Lon     { get; set; }
        public override string ToString() => Name;
    }
}
