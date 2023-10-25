// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// assessWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.WIN32;

namespace WinEI
{
    internal partial class assessWindow : Form
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
        internal assessWindow()
        {
            InitializeComponent();

            Load += assessWindow_Load;
            KeyDown += assessWindow_KeyDown;

            pbxLogo.MouseMove += assessWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += assessWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void assessWindow_Load(object sender, EventArgs e)
        {
            SetAccentColour();
        }

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
        private void assessWindow_MouseMove(object sender, MouseEventArgs e)
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

        #region KeyDown Events
        private void assessWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Location =
                    new Point(
                        Program.mWindow.Left,
                        Program.mWindow.Bottom + 1);
        }
        #endregion
    }
}