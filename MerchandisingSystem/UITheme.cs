using System.Drawing;
using System.Windows.Forms;

namespace MerchandisingSystem
{
    public static class UITheme
    {
        // ── Цвета ──────────────────────────────────────────────────────
        public static readonly Color SidebarBg    = Color.FromArgb(28, 50, 80);     // тёмно-синий
        public static readonly Color SidebarHover = Color.FromArgb(41, 128, 185);   // голубой при наведении
        public static readonly Color SidebarActive= Color.FromArgb(52, 152, 219);   // активная кнопка
        public static readonly Color AccentBlue   = Color.FromArgb(41, 128, 185);
        public static readonly Color AccentGreen  = Color.FromArgb(39, 174, 96);
        public static readonly Color AccentRed    = Color.FromArgb(192, 57, 43);
        public static readonly Color BgLight      = Color.FromArgb(245, 246, 250);
        public static readonly Color HeaderBg     = Color.FromArgb(36, 62, 99);
        public static readonly Color GridHeader   = Color.FromArgb(52, 73, 94);
        public static readonly Color TextLight    = Color.White;
        public static readonly Color TextDark     = Color.FromArgb(44, 62, 80);

        // ── Шрифты ─────────────────────────────────────────────────────
        public static readonly Font FontNormal  = new Font("Segoe UI", 9f);
        public static readonly Font FontBold    = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FontLarge   = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font FontTitle   = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FontSidebar = new Font("Segoe UI", 9.5f);

        // ── Применить стиль к боковой кнопке ───────────────────────────
        public static void StyleSidebarButton(Button btn)
        {
            btn.FlatStyle   = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize       = 0;
            btn.FlatAppearance.MouseOverBackColor  = SidebarHover;
            btn.FlatAppearance.MouseDownBackColor  = SidebarActive;
            btn.BackColor   = SidebarBg;
            btn.ForeColor   = TextLight;
            btn.Font        = FontSidebar;
            btn.TextAlign   = ContentAlignment.MiddleLeft;
            btn.Padding     = new Padding(12, 0, 0, 0);
            btn.Cursor      = Cursors.Hand;
            btn.Height      = 42;
        }

        // ── Применить стиль к обычной кнопке ───────────────────────────
        public static void StyleButton(Button btn, Color bg)
        {
            btn.FlatStyle   = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(bg, 0.2f);
            btn.BackColor   = bg;
            btn.ForeColor   = TextLight;
            btn.Font        = FontBold;
            btn.Cursor      = Cursors.Hand;
        }

        // ── Применить стиль к DataGridView ─────────────────────────────
        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor           = BgLight;
            dgv.GridColor                 = Color.FromArgb(220, 220, 220);
            dgv.BorderStyle               = BorderStyle.None;
            dgv.Font                      = FontNormal;
            dgv.RowTemplate.Height        = 28;
            dgv.ColumnHeadersHeight       = 34;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor  = GridHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.Font       = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(8, 0, 0, 0);
            dgv.DefaultCellStyle.SelectionBackColor      = AccentBlue;
            dgv.DefaultCellStyle.SelectionForeColor      = TextLight;
            dgv.DefaultCellStyle.Padding                 = new Padding(4, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 240, 248);
            dgv.RowHeadersVisible         = false;
        }

        // ── Применить стиль к TextBox ───────────────────────────────────
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font        = FontNormal;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor   = Color.White;
            txt.ForeColor   = TextDark;
        }

        // ── Применить стиль к ComboBox ──────────────────────────────────
        public static void StyleCombo(ComboBox cmb)
        {
            cmb.Font      = FontNormal;
            cmb.FlatStyle = FlatStyle.Flat;
        }
    }
}
