// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// detailsWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WenEI.Winsat;
using WinEI.Utils;
using WinEI.WIN32;

namespace WinEI.WinForms
{
    public partial class detailsWindow : Form
    {

        #region Private Members
        private static readonly object _lockObject = new object();
        private static System.Threading.Timer _uptimeGetter;
        #endregion

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

        #region Contructor
        public detailsWindow()
        {
            InitializeComponent();

            Load += detailsWindow_Load;
            FormClosed += detailsWindow_FormClosed;
            KeyDown += detailsWindow_KeyDown;

            pbxLogo.MouseMove += detailsWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += detailsWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void detailsWindow_Load(object sender, EventArgs e)
        {
            SetAccentColour();
            RefreshUI();

            TimerCallback callback =
                new TimerCallback(RefreshSystemUptime);

            _uptimeGetter =
                new System.Threading.Timer(
                    callback,
                    null,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(1));
        }

        private void detailsWindow_FormClosed(object sender, EventArgs e)
        {
            _uptimeGetter.Dispose();
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
        private void detailsWindow_MouseMove(object sender, MouseEventArgs e)
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
        private void detailsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdSeeDetails_Click(object sender, EventArgs e)
        {
            // do some stuff I guess
        }

        private void cmdClose_Click(object sender, System.EventArgs e) =>
            Close();
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

        #region UI Events
        private void RefreshUI()
        {
            lblOperatingSystem.Text =
                $"{OSUtils.GetWindowsName} " +
                $"{Strings.BUILD} {OSUtils.GetWindowsBuild} " +
                $"{OSUtils.GetSystemArchitecture(false)}";

            lblInstallDate.Text =
                OSUtils.GetSystemInstallDate;

            lblElevated.Text =
                OSUtils.IsElevated()
                ? "Yes"
                : "No - Some features are disabled";

            lblCulture.Text =
                OSUtils.GetSystemCulture;

            lblWinsatExe.Text =
                OSUtils.GetWinsatExePrivateVersion;

            lblWinsatDll.Text =
                OSUtils.GetWinsatApiVersion.ProductVersion;

            bool isBugged =
                WinsatBugChecker.IsBuggedVersion();

            lblBuggedWinsat.Text = isBugged ? "Yes" : "No";
            lblBuggedWinsat.ForeColor = isBugged ? Color.Tomato : Color.White;
            cmdSeeDetails.Enabled = isBugged;
        }

        private void RefreshSystemUptime(object state)
        {
            lock (_lockObject)
            {
                lblUptime.Invoke((Action)(()
                    => lblUptime.Text =
                    OSUtils.GetKernelUptime(NativeMethods.GetTickCount())));
            }
        }
        #endregion

    }
}