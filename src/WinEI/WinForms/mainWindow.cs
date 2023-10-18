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
using WinEI.Winsat;
using WinEI.WinSAT;

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
            KeyDown += mainWindow_KeyDown;
            tlpTitleVersion.Click += tlpTitleVersion_Click;
            lblAppVersion.MouseClick += lblAppVersion_MouseClick;

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
                $"{OSUtils.GetSystemArchitecture(false)}";

            UpdateUI();

            CheckForNewVersion();
        }

        internal async void CheckForNewVersion()
        {
            // Check for a new version using the specified URL.
            VersionResult result =
                await AppUpdate.CheckForNewVersion(
                    WEIUrl.VersionManifest);

            // If a new version is available and update the UI.
            if (result == VersionResult.NewVersionAvailable)
            {
                lblAppVersion.ForeColor = Color.FromArgb(255, 128, 128);
                lblAppVersion.Text += " (OUTDATED)";
            }
        }

        private void mainWindow_Activated(object sender, EventArgs e) =>
            SetActivatedStatusControlForeColor(
                tlpTitle, AppColours.ACTIVATED_WINDOW_TEXT);

        private void mainWindow_Deactivate(object sender, EventArgs e) =>
            SetActivatedStatusControlForeColor(
                tlpTitle, AppColours.DEACTIVATED_WINDOW_TEXT);
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        cmdExport.PerformClick();
                        break;
                    case Keys.T:
                        cmdTools.PerformClick();
                        break;
                    case Keys.S:
                        cmdSettings.PerformClick();
                        break;
                    case Keys.A:
                        cmdAbout.PerformClick();
                        break;
                }
            }
            else if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        cmdAssessment.PerformClick();
                        break;
                    case Keys.I:
                        cmdShareOnImgur.PerformClick();
                        break;
                    case Keys.H:
                        swShowHardware.Checked = !swShowHardware.Checked;
                        break;
                }
            }
        }
        #endregion

        #region Update UI
        private void UpdateUI()
        {
            UpdateBaseScoreControls();
            UpdateProcessorScoreControls();
            UpdateMemoryScoreControls();
            UpdateGraphicsScoreControls();
            UpdateD3dScoreControls();
            UpdateDiskScoreControls();

            UpdateValidityControls();
            UpdateAssessmentDateControls();
            UpdateRatingScaleControls();
        }

        private void UpdateBaseScoreControls()
        {
            lblBaseScore.Text =
                WinsatReader.ScorePool.BaseScore;
        }

        private void UpdateProcessorScoreControls()
        {
            Control label =
                (Control)lblSubscoreProcessor;

            label.Text =
                WinsatReader.ScorePool.ProcessorScore;

            label.BackColor =
                string.Equals(
                    WinsatReader.ScorePool.ProcessorScore, WinsatReader.ScorePool.BaseScore)
                    ? AppColours.SUBSCORE_MATCH_BACKCOLOR
                    : AppColours.SUBSCORE_MISMATCH_BACKCOLOR;
        }

        private void UpdateMemoryScoreControls()
        {
            Control label =
                (Control)lblSubscoreMemory;

            label.Text =
                WinsatReader.ScorePool.MemoryScore;

            label.BackColor =
                string.Equals(
                    WinsatReader.ScorePool.MemoryScore, WinsatReader.ScorePool.BaseScore)
                    ? AppColours.SUBSCORE_MATCH_BACKCOLOR
                    : AppColours.SUBSCORE_MISMATCH_BACKCOLOR;
        }

        private void UpdateGraphicsScoreControls()
        {
            Control label =
                (Control)lblSubscoreGraphics;

            label.Text =
                WinsatReader.ScorePool.GraphicsScore;

            label.BackColor =
                string.Equals(
                    WinsatReader.ScorePool.GraphicsScore, WinsatReader.ScorePool.BaseScore)
                    ? AppColours.SUBSCORE_MATCH_BACKCOLOR
                    : AppColours.SUBSCORE_MISMATCH_BACKCOLOR;
        }

        private void UpdateD3dScoreControls()
        {
            Control label =
                (Control)lblSubscoreD3d;

            label.Text =
                WinsatReader.ScorePool.D3DScore;

            label.BackColor =
                string.Equals(
                    WinsatReader.ScorePool.D3DScore, WinsatReader.ScorePool.BaseScore)
                    ? AppColours.SUBSCORE_MATCH_BACKCOLOR
                    : AppColours.SUBSCORE_MISMATCH_BACKCOLOR;
        }

        private void UpdateDiskScoreControls()
        {
            Control label =
                (Control)lblSubscoreDisk;

            label.Text =
                WinsatReader.ScorePool.DiskScore;

            label.BackColor =
                string.Equals(
                    WinsatReader.ScorePool.DiskScore, WinsatReader.ScorePool.BaseScore)
                    ? AppColours.SUBSCORE_MATCH_BACKCOLOR
                    : AppColours.SUBSCORE_MISMATCH_BACKCOLOR;
        }

        private void UpdateValidityControls()
        {
            lblScoreValidity.Text =
                WinsatReader.GetAssessmentStateString(
                    (int)WinsatReader.AssessmentSate);

            cmdAssessment.Text =
                WinsatReader.GetAssessmentStateButtonString(
                    (int)WinsatReader.AssessmentSate);
        }

        private void UpdateAssessmentDateControls()
        {
            lblLastAssessment.Text =
                WinsatAPI.QueryLatestFormalDate().ToString(
                    "dddd, MMM d yyyy hh:mm tt");
        }

        private void UpdateRatingScaleControls()
        {
            lblRatingScale.Text =
                WinsatReader.GetRatingScaleString();
        }
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
            Program.Exit();

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();

            using (Form formWindow = new aboutWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void SetButtonProperties()
        {
            var buttons = new[]
            {
                new { Button = cmdClose,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.EXIT_CROSS },
                new { Button = cmdShareOnImgur,
                    Font = Program.FONT_MDL2_REG_10,
                    Text = Chars.FORWARD },
                new { Button = cmdMore,
                    Font = Program.FONT_MDL2_REG_12,
                    Text = Chars.MORE }
            };

            foreach (var buttonData in buttons)
            {
                buttonData.Button.Font = buttonData.Font;
                buttonData.Button.Text = buttonData.Text;
            }
        }
        #endregion

        #region Label Events
        private void lblTitle_Click(object sender, EventArgs e) =>
            InterfaceUtils.ShowContextMenuAtCursor(sender, e, cmsApplication, false);

        private void lblAppVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(
                    WEIUrl.LatestRelease);
        }
        #endregion

        #region ToolStrip Events
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e) =>
            CenterToScreen();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>
            Program.Exit();
        #endregion

        #region PictureBox Events
        private void pbxLogo_Click(object sender, EventArgs e) =>
            InterfaceUtils.ShowContextMenuAtControlPoint(
                sender,
                cmsApplication,
                MenuPosition.BottomLeft);
        #endregion

        #region TableLayoutPanel Events
        private void tlpTitleVersion_Click(object sender, EventArgs e) =>
            InterfaceUtils.ShowContextMenuAtCursor(sender, e, cmsApplication, false);
        #endregion

        #region UI Events
        private void SetActivatedStatusControlForeColor(Control parentControl, Color foreColor)
        {
            foreach (Control ctrl in parentControl.Controls)
                ctrl.ForeColor = foreColor;
        }

        internal void SetHalfOpacity() =>
            Opacity = 0.5;

        private void ChildWindowClosed(object sender, EventArgs e) =>
            Opacity = 1.0;
        #endregion

    }
}