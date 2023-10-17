// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// mainWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.UI;
using WinEI.Utils;
using WinEI.WIN32;

namespace WinEI
{
    public partial class mainWindow : Form
    {

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.Style |= Program.WS_MINIMIZEBOX;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public mainWindow()
        {
            InitializeComponent();

            // Attach event handlers.
            Load += mainWindow_Load;
            Deactivate += mainWindow_Deactivate;
            Activated += mainWindow_Activated;

            // Set mouse move event handlers.
            SetMouseMoveEventHandlers();

            // Set button properties.
            SetButtonProperties();
        }
        #endregion

        #region Window Events
        private void mainWindow_Load(object sender, EventArgs e)
        {
            lblAppVersion.Text =
                Application.ProductVersion;

            lblOperatingSystem.Text =
                $"{OSUtils.GetWindowsName} " +
                $"{OSUtils.GetBitness(false)}";
        }

        private void mainWindow_Activated(object sender, EventArgs e) =>
            SetActivatedStatusControlForeColor(
                tlpTitle, AppColours.ACTIVATED_WINDOW_TEXT);

        private void mainWindow_Deactivate(object sender, EventArgs e) =>
            SetActivatedStatusControlForeColor(
                tlpTitle, AppColours.DEACTIVATED_WINDOW_TEXT);
        #endregion

        #region Mouse Events
        private void mainWindow_MouseMove(object sender, MouseEventArgs e)
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

        private void SetMouseMoveEventHandlers()
        {
            Control[] controls = {
                tlpTitle,
                lblTitle,
                tlpMenu };

            foreach (Control control in controls)
                control.MouseMove += mainWindow_MouseMove;
        }
        #endregion

        #region Button Events
        private void cmdMinimize_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdClose,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.EXIT_CROSS },
                new { Button = cmdShareOnImgur,
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

        #region UI Events
        private void SetActivatedStatusControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control ctrl in parentControl.Controls)
                ctrl.ForeColor = foreColor;
        }
        #endregion

    }
}