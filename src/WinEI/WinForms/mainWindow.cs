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
using WinEI.Common;
using WinEI.UI;
using WinEI.Utils;
using WinEI.WIN32;
using WinEI.Winsat;

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
                $"{Strings.BUILD} {OSUtils.GetWindowsBuild} " +
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
                lblAppVersion.ForeColor = AppColours.OUTDATED_VERSION;
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
                        cmdOptions.PerformClick();
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

            pnlValidityStatus.BackColor =
                WinsatReader.AssessmentSate == WinsatAssessmentState.VALID
                ? AppColours.PANEL_VALID
                : AppColours.PANEL_INVALID;

            Control[] controls =
            {
                cmdShareOnImgur,
                swShowHardware
            };

            foreach (Control control in controls)
                control.Enabled =
                    WinsatReader.AssessmentSate
                    != WinsatAssessmentState.UNAVAILABLE;
        }

        private void UpdateAssessmentDateControls()
        {
            string stateText =
                WinsatReader.GetAssessmentStateButtonString(
                    (int)WinsatReader.AssessmentSate);

            string assessmentDate =
                WinsatAPI.QueryLatestFormalDate().ToString(
                    Strings.WINSAT_DATE_FORMAT);

            lblAssessmentDate.Text =
                assessmentDate.Contains("1999") ? Strings.NEVER : assessmentDate;

            cmdAssessment.Text =
                stateText.ToUpper();

            runAssessmentToolStripMenuItem.Text =
                $"{stateText} {Strings.ASSESSMENT}";
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

        private void cmdOptions_Click(object sender, EventArgs e)
        {
            InterfaceUtils.ShowContextMenuAtControlPoint(
                sender,
                cmsOptions,
                MenuPosition.BottomLeft);
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();

            using (Form formWindow = new aboutWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
        }

        private void cmdAssessment_Click(object sender, EventArgs e)
        {
            // Perform sanity checks.
            if (!PowerUtils.IsExternalPowerSourceConnected())
            {
                WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        Strings.ERROR_POWER_ADAPTER,
                        WEIMessageBoxType.Error,
                        WEIMessageBoxButtons.Okay);

                return;
            }

            if (!OSUtils.IsElevated())
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        Strings.FEATURE_REQUIRES_ELEVATION,
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OSUtils.RestartElevated();
                }

                return;
            }

            // Assess system.

        }

        private void cmdShareOnImgur_Click(object sender, EventArgs e)
        {
            if (WinsatReader.AssessmentSate == WinsatAssessmentState.UNAVAILABLE)
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        $"{Strings.SYSTEM_MUST_BE_RATED} {Strings.QUESTION_RATE_SYSTEM}",
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    cmdAssessment.PerformClick();
                }

                return;
            }

            if (!NetworkUtils.GetIsWebsiteAvailable(WEIUrl.ImgurAddress))
            {
                WEIMessageBox.Show(
                       this,
                       Strings.ERROR,
                       Strings.ERROR_IMGUR_CONNECTION,
                       WEIMessageBoxType.Warning,
                       WEIMessageBoxButtons.YesNo);

                return;
            }

            ImageUtils.CaptureControl(
                WEIPath.ImgurTempFile,
                this);

            string url =
                ImgurApi.UploadToImgur(
                    ImgurApi.API_KEY,
                    WEIPath.ImgurTempFile,
                    true);

            if (!string.IsNullOrEmpty(url))
            {
                Logger.WriteToImgurLog(url);
                Process.Start(url);
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

        private void clearWinSATDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OSUtils.IsElevated())
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        Strings.FEATURE_REQUIRES_ELEVATION,
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OSUtils.RestartElevated();
                }

                return;
            }

            try
            {
                FileUtils.RemoveFilesbyExtension("*.xml", WinsatReader.WinsatDataStorePath);
                FileUtils.RemoveFilesbyExtension("*.log", WinsatReader.WinsatFilesPath);

                ReloadData();
            }
            catch (Exception ex)
            {
                Logger.WriteExceptionToAppLog(ex);

                WEIMessageBox.Show(
                    this,
                    Strings.ERROR,
                    $"{Strings.EXCEPTION_OCCURED} {Strings.DETAILS_SAVED_TO_LOG}",
                    WEIMessageBoxType.Error,
                    WEIMessageBoxButtons.Okay);
            }
        }

        private void runAssessmentToolStripMenuItem_Click(object sender, EventArgs e) =>
            cmdAssessment.PerformClick();

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e) =>
            ReloadData();
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

        internal void ReloadData()
        {
            WinsatReader.LoadWinsatData();
            UpdateUI();
        }
        #endregion

    }
}