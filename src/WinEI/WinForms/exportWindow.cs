// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// exportWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.WIN32;

namespace WinEI
{
    public partial class exportWindow : Form
    {

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public exportWindow()
        {
            InitializeComponent();

            KeyDown += mainWindow_KeyDown;
            Load += exportWindow_Load;

            pbxLogo.MouseMove += aboutWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += aboutWindow_MouseMove;

            SetButtonProperties();
        }
        #endregion

        #region Window Events

        private void exportWindow_Load(object sender, EventArgs e) =>
            SetAccentColour();

        private void SetAccentColour()
        {
            Color accentColor =
                Settings.GetAccentColour(
                    Settings.ReadInteger(
                        SettingsInteger.AccentColor));

            pnlSplit.BackColor = accentColor;
        }
        #endregion

        #region Mouse Events
        private void aboutWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }
        #endregion

        #region Button Events
        private void cmdExportJpeg_Click(object sender, EventArgs e)
        {
            Program.EXPORT_TYPE = ExportType.JPEG;
            DialogResult = DialogResult.OK;
        }

        private void cmdExportPng_Click(object sender, EventArgs e)
        {
            Program.EXPORT_TYPE = ExportType.PNG;
            DialogResult = DialogResult.OK;
        }

        private void cmdExportBitmap_Click(object sender, EventArgs e)
        {
            Program.EXPORT_TYPE = ExportType.Bitmap;
            DialogResult = DialogResult.OK;
        }

        private void cmdExportText_Click(object sender, EventArgs e)
        {
            Program.EXPORT_TYPE = ExportType.Text;
            DialogResult = DialogResult.OK;
        }

        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

        #region UI Events
        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdClose,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.EXIT_CROSS },
                new { Button = cmdExportJpeg,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FORWARD },
                new { Button = cmdExportPng,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FORWARD },
                new { Button = cmdExportBitmap,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FORWARD },
                new { Button = cmdExportText,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FORWARD }
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }
        #endregion

    }
}