// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// mainWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.Common;
using WinEI.UI;
using WinEI.Utils;
using WinEI.WIN32;
using WinEI.WinForms;
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
            // Get the application version.
            lblAppVersion.Text =
                Application.ProductVersion;

            // Display some Operating System details.
            // Why the fuck does GetWindowsName report as Windows 10 when using Windows 11?
            // ***Need to look into this and fix.***
            lblOperatingSystem.Text =
                $"{OSUtils.GetWindowsName} " +
                $"{Strings.BUILD} {OSUtils.GetWindowsBuild} " +
                $"{OSUtils.GetSystemArchitecture(false)}";

            // If the system has not been rated, we should not toggle the show hardware switch.
            if (WinsatReader.AssessmentSate != WinsatAssessmentState.UNAVAILABLE)
                // Check whether to show rated hardware.
                if (Settings.ReadBool(SettingsBool.ShowHardware))
                    swShowHardware.Checked = true;

            // If we're elevated, remove menu item to an perform elevated restart.
            if (OSUtils.IsElevated())
                cmsMore.Items.Remove(
                    elevatedRestartToolStripMenuItem);

            // Update User Interface
            SetAccentColour();
            UpdateUI();

            // Do we need to check for an update?
            if (!Settings.ReadBool(SettingsBool.DisableVersionCheck))
                CheckForNewVersion();

            // Check for a bugged WinSAT version, and show button.
            // ***TODO***
        }

        internal async void CheckForNewVersion()
        {
            // Check for a new version using the specified URL.
            VersionResult result =
                await AppUpdate.CheckForNewVersion(
                    WEIUrl.GithubVersionManifest);

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

        internal void SetAccentColour()
        {
            Color accentColor =
                Settings.GetAccentColour(
                    Settings.ReadInteger(
                        SettingsInteger.AccentColor));

            Label[] labels =
            {
                lblSubscoreProcessor,
                lblSubscoreMemory,
                lblSubscoreGraphics,
                lblSubscoreD3d,
                lblSubscoreDisk,
                lblBaseScore
            };

            foreach (Label label in labels)
                label.ForeColor = accentColor;

            tlpSplit.BackColor = accentColor;
            swShowHardware.CheckedColor = accentColor;
        }
        #endregion

        #region KeyDown Events
        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                reloadDataToolStripMenuItem.PerformClick();
            }

            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        cmdExport.PerformClick();
                        break;
                    case Keys.O:
                        cmdOptions.PerformClick();
                        break;
                    case Keys.S:
                        cmdSettings.PerformClick();
                        break;
                    case Keys.A:
                        cmdAbout.PerformClick();
                        break;
                    case Keys.M:
                        cmdMore.PerformClick();
                        break;
                }
            }
            else if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        deleteWinSATDataToolStripMenuItem.PerformClick();
                        break;
                    case Keys.S:
                        systemDetailsToolStripMenuItem.PerformClick();
                        break;
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
            Control[] controls =
            {
                tlpTitle,
                lblTitle,
                tlpMenu
            };

            foreach (Control control in controls)
                control.MouseMove += mainWindow_MouseMove;
        }
        #endregion

        #region Button Events
        private void cmdMinimize_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void cmdExport_Click(object sender, EventArgs e) =>
            MessageBox.Show("Export menu not implemented yet.");

        private void cmdOptions_Click(object sender, EventArgs e)
        {
            InterfaceUtils.ShowContextMenuAtControlPoint(
                sender,
                cmsOptions,
                MenuPosition.BottomLeft);
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            SetHalfOpacity();

            using (Form formWindow = new settingsWindow())
            {
                formWindow.FormClosed += ChildWindowClosed;
                formWindow.ShowDialog();
            }
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

        private void cmdMore_Click(object sender, EventArgs e)
        {
            InterfaceUtils.ShowContextMenuAtControlPoint(
                sender,
                cmsMore,
                MenuPosition.BottomLeft);
        }

        private void cmdAssessment_Click(object sender, EventArgs e)
        {
            // Check whether we have appropriate privilages to run an assessment.
            if (!OSUtils.IsElevated())
            {
                // We need to elevate privilages.
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        Strings.FEATURE_REQUIRES_ELEVATION,
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                // User chose to elevate privilages.
                // *** TODO ***
                // We need to set special restart settings integer here to automatically pick
                // up the assessment after elevation.
                if (result == DialogResult.Yes)
                    OSUtils.RestartElevated();

                // User chose not to elevate, exit here as we cannot continue.
                return;
            }

            // Check to see if power adapter enforcement has been overriden
            if (!Settings.ReadBool(SettingsBool.BypassPowerAdapter))
                // Otherwise check the adapter is plugged in, WinSAT cannot run on battery power.
                if (!PowerUtils.IsExternalPowerSourceConnected())
                {
                    WEIMessageBox.Show(
                            this,
                            Strings.WARNING,
                            Strings.ERROR_POWER_ADAPTER,
                            WEIMessageBoxType.Error,
                            WEIMessageBoxButtons.Okay);

                    // Exit here as we need external power first.
                    return;
                }

            // Assess system.
            // ***TODO***
        }

        private void cmdShareOnImgur_Click(object sender, EventArgs e)
        {
            // Check if the system is rated.
            if (WinsatReader.AssessmentSate == WinsatAssessmentState.UNAVAILABLE)
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        $"{Strings.SYSTEM_MUST_BE_RATED} {Strings.QUESTION_RATE_SYSTEM}",
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                // User chose to run the assessment.
                if (result == DialogResult.Yes)
                    cmdAssessment.PerformClick();

                // User chose not to run an assessment, exit here as we cannot continue.
                return;
            }

            // If we got here, confirm the upload.
            DialogResult uploadResult =
                WEIMessageBox.Show(
                       this,
                       Strings.INFORMATION,
                       Strings.IMGUR_UPLOAD_CONFIRM,
                       WEIMessageBoxType.Question,
                       WEIMessageBoxButtons.YesNo);

            if (uploadResult == DialogResult.Yes)
            {
                // Check Imgur website is available.
                if (!NetworkUtils.GetIsWebsiteAvailable(WEIUrl.ImgurAddress))
                {
                    // Network is not available, or Imgur could not be reached.
                    WEIMessageBox.Show(
                           this,
                           Strings.ERROR,
                           Strings.ERROR_IMGUR_CONNECTION,
                           WEIMessageBoxType.Error,
                           WEIMessageBoxButtons.YesNo);

                    // Exit here as we require network first.
                    return;
                }

                // Capture window bitmap.
                ImageUtils.CaptureControl(
                    WEIPath.ImgurTempFile,
                    this);

                // Attempt Imgur upload.
                string url =
                    ImgurApi.UploadToImgur(
                        ImgurApi.API_KEY,
                        WEIPath.ImgurTempFile,
                        true);

                // Imgur upload returned a URL.
                if (!string.IsNullOrEmpty(url))
                {
                    // Check whether we should log the URL.
                    if (Settings.ReadBool(SettingsBool.LogImgurUrls))
                        Logger.WriteToLog(url, LogType.ImgurLog);

                    // Check whether we should open a browser window, or show a message.
                    if (Settings.ReadBool(SettingsBool.OpenImgurUrls))
                    {
                        Process.Start(url);
                    }
                    else
                    {
                        // Open browser setting is disabled, show messagebox and ask if
                        // user wants to copy the returned URL to the clipboard.
                        DialogResult copyResult =
                            WEIMessageBox.Show(
                                this,
                                Strings.INFORMATION,
                                $"{Strings.IMGUR_UPLOAD_COMPLETE} {url}\r\n{Strings.QUESTION_COPY_URL_TO_CLIPBOARD}",
                                WEIMessageBoxType.Question,
                                WEIMessageBoxButtons.YesNo);

                        // Copy URL to clipboard.
                        if (copyResult == DialogResult.Yes)
                            Clipboard.SetText(url);

                    }

                    // Exit here, nothing else to do.
                    return;
                }

                // Imgur upload returned an empty or null URL.
                WEIMessageBox.Show(
                           this,
                           Strings.ERROR,
                           Strings.ERROR_IMGUR_RESPONSE,
                           WEIMessageBoxType.Error,
                           WEIMessageBoxButtons.Okay);
            }
        }
        #endregion

        #region Switch Events
        private void swShowHardware_CheckedChanged(object sender, EventArgs e)
        {
            WEISwitch control =
                (WEISwitch)sender;

            RefreshHardwareStrings(
                control.Checked);
        }
        #endregion

        #region Label Events
        private void lblTitle_Click(object sender, EventArgs e) =>
            InterfaceUtils.ShowContextMenuAtCursor(sender, e, cmsApplication, false);

        private void lblAppVersion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(
                    WEIUrl.GithubLatestRelease);
        }
        #endregion

        #region ToolStrip Events
        // Application Menu
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void resetPositionToolStripMenuItem_Click(object sender, EventArgs e) =>
            CenterToScreen();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>
            Close();

        // Options Menu
        private void deleteWinSATDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // We need elevated privilages to delete anything in the Performance folder.
            if (!OSUtils.IsElevated())
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        Strings.FEATURE_REQUIRES_ELEVATION,
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                // User chose to elevate.
                if (result == DialogResult.Yes)
                    OSUtils.RestartElevated();

                return;
            }

            try
            {
                // Confirm deletion of files.
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        Strings.WARNING,
                        "This will permanently delete all system scores, and the WinSAT log. Are you sure you want to reset WinSAT?",
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                // User confirmed deletion.
                if (result == DialogResult.Yes)
                {
                    // Delete WinSAT XML assessment data, and the WinSAT log.
                    FileUtils.RemoveFilesbyExtension("*.xml", WinsatReader.WinsatDataStorePath);
                    FileUtils.RemoveFilesbyExtension("*.log", WinsatReader.WinsatFilesPath);

                    // Since we esentially 'reset' WinSAT, a reloading of data and
                    // UI is necessary.
                    ReloadData();
                }
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

        private void systemDetailsToolStripMenuItem_Click(object sender, EventArgs e) =>
            MessageBox.Show("System details not imlemented yet.");

        private void toggleShowHardwareToolStripMenuItem_Click(object sender, EventArgs e) =>
            swShowHardware.Checked = !swShowHardware.Checked;

        private void viewImgurLinksFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(WEIPath.ImgurLinksFile))
            {
                WEIMessageBox.Show(
                    this,
                    Strings.INFORMATION,
                    Strings.IMGUR_LOG_NOT_FOUND,
                    WEIMessageBoxType.Information,
                    WEIMessageBoxButtons.Okay);

                return;
            }

            Process.Start(WEIPath.ImgurLinksFile);
        }

        private void viewWinSATLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(WinsatReader.WinsatLog))
            {
                WEIMessageBox.Show(
                    this,
                    Strings.INFORMATION,
                    Strings.WINSAT_LOG_NOT_FOUND,
                    WEIMessageBoxType.Information,
                    WEIMessageBoxButtons.Okay);

                return;
            }

            Process.Start(WinsatReader.WinsatLog);
        }

        // More Menu
        private void workingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(WEIPath.CurrentDirectory);

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(WEIUrl.GithubChangelog);

        private void homepageToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(WEIUrl.GithubHomepage);

        private void reportAnIssueToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(WEIUrl.GithubIssues);

        private void mediaFeaturePackToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(WEIUrl.MediaFeaturePackAddress);

        private void viewApplicationLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(WEIPath.ApplicationLog))
            {
                WEIMessageBox.Show(
                    this,
                    Strings.INFORMATION,
                    "The application log has not been created yet.",
                    WEIMessageBoxType.Information,
                    WEIMessageBoxButtons.Okay);

                return;
            }

            Process.Start(WEIPath.ApplicationLog);
        }

        private void restartApplicationToolStripMenuItem_Click(object sender, EventArgs e) =>
            Program.Restart();

        private void elevatedRestartToolStripMenuItem_Click(object sender, EventArgs e) =>
            OSUtils.RestartElevated();
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

        internal void ReloadData()
        {
            // Reload all WinSAT data.
            WinsatReader.LoadWinsatData();

            // If the system rating is now unavailable, and the show hardware switch is toggled
            // on, we need to switch off 'show hardware'.
            if (WinsatReader.AssessmentSate == WinsatAssessmentState.UNAVAILABLE && swShowHardware.Checked)
            {
                // Simply toggling the switch will disable 'show hardware' and load default strings.
                swShowHardware.Checked = false;
            }
            else
            {
                if (swShowHardware.Checked)
                {
                    // The switch was toggled on so we need to refresh hardware data.
                    RefreshHardwareStrings(true);
                }
                // We don't need to worry about settings startup bool 'ShowHardware' as this should
                // only be called when the application is opened; not after a data reload.
                //else if (Settings.ReadBool(SettingsBool.ShowHardware))
                //{
                //    RefreshHardwareStrings(true);
                //}
            }

            // Refresh all window data.
            UpdateUI();
        }

        private void RefreshHardwareStrings(bool showHardware)
        {
            // Show default strings and exit.
            if (!showHardware)
            {
                SetDefaultHardwareStrings();
                return;
            }

            // Check whether use API hardware mode is enabled.
            if (!Settings.ReadBool(SettingsBool.ApiHardwareMode))
            {
                // XML hardware mode is set, check if the WinsatReader allows reading.
                if (WinsatReader.XmlHardwareEnabled)
                {
                    lblProcessor.Text =
                        WinsatReader.XmlHardware.Processor;

                    lblMemory.Text =
                        $"{MemoryType.Convert(WinsatReader.XmlHardware.Memory)} " +
                        $"{FileUtils.GetBytesReadableSize(WinsatReader.XmlHardware.MemorySizeBytes)}";

                    lblGraphics.Text =
                        WinsatReader.XmlHardware.Graphics;

                    lblD3d.Text =
                        $"{FileUtils.ConvertBytesToMB(WinsatReader.XmlHardware.VramSizeMegabytes)} VRAM";

                    lblDisk.Text =
                        WinsatReader.XmlHardware.Disk;

                    // Exit here, no need to continue.
                    return;
                }
                else
                {
                    WEIMessageBox.Show(
                        this,
                        Strings.ERROR,
                        "Reading of XML hardware information has been disabled by the WinsatReader.",
                        WEIMessageBoxType.Error,
                        WEIMessageBoxButtons.Okay);

                    swShowHardware.Checked = false;

                    return;
                }
            }

            // API hardware mode is set, check if the WinsatReader allows reading.
            if (WinsatReader.ApiHardwareEnabled)
            {
                lblProcessor.Text =
                    WinsatReader.ApiHardware.Processor;

                lblMemory.Text =
                    WinsatReader.ApiHardware.Memory;

                lblGraphics.Text =
                    WinsatReader.ApiHardware.Graphics;

                lblD3d.Text =
                    WinsatReader.ApiHardware.D3D;

                lblDisk.Text =
                    WinsatReader.ApiHardware.Disk;
            }
            else
            {
                WEIMessageBox.Show(
                    this,
                    Strings.ERROR,
                    "Reading of API hardware information has been disabled by the WinsatReader.",
                    WEIMessageBoxType.Error,
                    WEIMessageBoxButtons.Okay);

                swShowHardware.Checked = false;
            }
        }

        private void SetDefaultHardwareStrings()
        {
            lblProcessor.Text = Strings.DEFAULT_PROCESSOR;
            lblMemory.Text = Strings.DEFAULT_MEMORY;
            lblGraphics.Text = Strings.DEFAULT_GRAPHICS;
            lblD3d.Text = Strings.DEFAULT_D3D;
            lblDisk.Text = Strings.DEFAULT_DISK;
        }
        #endregion

    }
}