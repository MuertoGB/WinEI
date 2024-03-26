// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// assessWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WenEI.Winsat;
using WinEI.Common;
using WinEI.UI;
using WinEI.Utils;
using WinEI.WIN32;
using WinEI.Winsat;

namespace WinEI
{
    internal partial class assessWindow : Form
    {

        #region Private Members
        private System.Timers.Timer _watchdog;
        private Process _winsatProcess;
        private bool _assessmentComplete = false;
        private bool _windowClosedByUser = false;
        private int _warningCount = 0;
        private int _errorCount = 0;
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

        #region Constructor
        internal assessWindow()
        {
            InitializeComponent();

            Load += assessWindow_Load;
            KeyDown += assessWindow_KeyDown;
            FormClosing += assessWindow_FormClosing;

            pbxLogo.MouseMove += assessWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += assessWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;

            _watchdog = new System.Timers.Timer();
            _watchdog.Elapsed += WatchdogElapsed;
            _watchdog.Interval = 5000;
            _watchdog.AutoReset = true;
        }
        #endregion

        #region Window Events
        private void assessWindow_Load(object sender, EventArgs e)
        {
            SetAccentColour();

            GetInitialLogData();

            Encoding encoding =
                OSUtils.IsWindowsVista()
                ? Encoding.Unicode
                : Encoding.GetEncoding(
                    CultureInfo.CurrentUICulture.TextInfo.OEMCodePage);

            ProcessStartInfo startInfo =
                new ProcessStartInfo(
                    "winsat", "formal -v")
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    StandardErrorEncoding = encoding,
                    StandardOutputEncoding = encoding,
                };

            _winsatProcess = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true,
            };

            _winsatProcess.ErrorDataReceived += AsyncDataReceived;
            _winsatProcess.OutputDataReceived += AsyncDataReceived;

            _watchdog.Start();
            _winsatProcess.Start();
            _winsatProcess.BeginErrorReadLine();
            _winsatProcess.BeginOutputReadLine();
        }

        private void assessWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4 || ModifierKeys == Keys.Escape)
            {
                e.Cancel = true;

                HandleFormClosed();
            }
        }

        private void HandleFormClosed()
        {
            if (!_assessmentComplete && !_winsatProcess.HasExited)
            {
                DialogResult result =
                    WEIMessageBox.Show(
                        this,
                        AppStrings.WARNING,
                        DialogStrings.Q_CANCEL_ASSESSMENT,
                        WEIMessageBoxType.Warning,
                        WEIMessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (_assessmentComplete && _winsatProcess.HasExited)
                    {
                        // The asessment completed whilst the warning prompt was open.
                        rtbLogger.Log(
                            AssessmentStrings.A_ALREADY_COMPLETED,
                            rtbLogType.Warning,
                            rtbAssessment);

                        return;
                    }

                    Logger.WriteToAssessmentLog(
                        $"{AssessmentStrings.A_CANCELLED_BY_USER}\r\n");

                    _windowClosedByUser = true;

                    StopWatchdog();
                    StopWinsatProcess();
                    Close();

                    return;
                }
            }
            else
            {
                Close();
            }
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
                HandleFormClosed();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            HandleFormClosed();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            HandleFormClosed();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            TextUtils.SaveAsTextWithDialog(
                string.Join("\r\n", rtbAssessment.Lines),
                "assessment-log",
                this);
        }
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

        #region Watchdog
        private void WatchdogElapsed(object sender, ElapsedEventArgs elapsed)
        {
            if (_assessmentComplete)
                return;

            if (!_assessmentComplete && _winsatProcess.HasExited)
            {
                rtbLogger.Log(
                    $"{AssessmentStrings.A_WD}: {AssessmentStrings.A_WINSAT_KILLED_OR_QUIT}",
                    rtbLogType.Error,
                    rtbAssessment);

                StopWatchdog();

                cmdCancel.Text = AppStrings.CLOSE.ToUpper();

                lblStatus.Text = AssessmentStrings.A_DID_NOT_COMPLETE;
            }
        }

        private void StopWatchdog()
        {
            if (_watchdog.Enabled)
            {
                rtbLogger.Log(
                    AssessmentStrings.A_WD_SHUTDOWN_START,
                    rtbLogType.Application,
                    rtbAssessment);

                while (_watchdog.Enabled)
                {
                    try
                    {
                        _watchdog.Stop();
                    }
                    catch
                    {
                        rtbLogger.Log(
                            AssessmentStrings.A_WD_SHUTDOWN_FAIL,
                            rtbLogType.Error,
                            rtbAssessment);
                    }

                }

                rtbLogger.Log(
                    AssessmentStrings.A_WD_SHUTDOWN_SUCCESS,
                    rtbLogType.Okay,
                    rtbAssessment);
            }
        }
        #endregion

        #region Winsat
        private void StopWinsatProcess()
        {
            if (_winsatProcess != null && !_winsatProcess.HasExited)
            {
                rtbLogger.Log(
                    AssessmentStrings.A_WS_SHUTDOWN_START,
                    rtbLogType.Application,
                    rtbAssessment);

                while (!_winsatProcess.HasExited)
                {
                    try
                    {
                        _winsatProcess.Kill();
                    }
                    catch
                    {
                        rtbLogger.Log(
                            AssessmentStrings.A_WS_SHUTDOWN_FAIL,
                            rtbLogType.Error,
                            rtbAssessment);
                    }
                }

                rtbLogger.Log(
                    AssessmentStrings.A_WS_SHUTDOWN_SUCCESS,
                    rtbLogType.Okay,
                    rtbAssessment);
            }
        }
        #endregion

        #region UI Events
        private void GetInitialLogData()
        {
            rtbLogger.Log(
                $"{AssessmentStrings.A_STARTED}:   {DateTime.Now.ToString(WinsatStrings.WINSAT_DATE_FORMAT)}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_VERSION}:   {WEIVersion.Version}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_CHANNEL}:   {WEIVersion.Channel}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_SYSTEM}:    {OSUtils.GetWindowsName} " +
                $"{OSUtils.GetWindowsBuild} " +
                $"{OSUtils.GetSystemArchitecture()}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_CULTURE}:   {OSUtils.GetSystemCulture}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_EXE}:       {OSUtils.GetWinsatExePrivateVersion}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_API}:       {OSUtils.GetWinsatApiVersion.ProductVersion}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_BUGGED}:    {WinsatBugChecker.IsBuggedVersion()}",
                rtbLogType.Information,
                rtbAssessment);

            rtbLogger.Log(
                $"{AssessmentStrings.A_VALIDITY}:  {WinsatReader.ASSESSMENT_STATE}",
                rtbLogType.Information,
                rtbAssessment);
        }

        private void AsyncDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null || _windowClosedByUser)
                return;

            if (InvokeRequired)
                Invoke(new Action(() => AyncDataOut(e.Data)));
            else
                AyncDataOut(e.Data);
        }

        private void AyncDataOut(string data)
        {
            rtbLogger.Log(
                data,
                rtbLogType.Winsat,
                rtbAssessment);

            // ++ on any warnings.
            if (data.Contains("Warning:"))
                _warningCount++;

            // ++ on any errors.
            if (data.Contains("Error:"))
                _errorCount++;

            // Update the status label.
            if (OSUtils.IsWindowsVista())
                UpdateStatusLabelLonghorn(data);
            else
                UpdateStatusLabelOther(data);

            // Assessment is still running. Leave code.
            if (!data.Contains("Composition restarted"))
                return;

            // Asessment is finished.
            _assessmentComplete = true;

            // Stop the WinSAT watchdog.
            StopWatchdog();

            // Warning and error counts (only supports English lang for now).
            if (_warningCount > 0)
                rtbLogger.Log(
                    $"{AssessmentStrings.A_RAN_WITH_COUNT} {_warningCount} " +
                    $"{(_warningCount > 1 ? AssessmentStrings.A_WARNINGS : AssessmentStrings.A_WARNING)}",
                    rtbLogType.Warning,
                    rtbAssessment);

            if (_errorCount > 0)
                rtbLogger.Log(
                    $"{AssessmentStrings.A_RAN_WITH_COUNT} {_errorCount} " +
                    $"{(_errorCount > 1 ? AssessmentStrings.A_ERRORS : AssessmentStrings.A_ERROR)}",
                    rtbLogType.Error,
                    rtbAssessment);

            GetAssessmentCompletedData();
        }

        private void GetAssessmentCompletedData()
        {
            if (!_windowClosedByUser)
            {
                lblStatus.Text = AssessmentStrings.A_COMPLETED;
                cmdCancel.Text = AppStrings.CLOSE.ToUpper();
                cmdExport.Enabled = true;

                rtbLogger.Log(
                    AssessmentStrings.A_WS_EXIT_WAIT,
                    rtbLogType.Application,
                    rtbAssessment);


                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // We need WinSAT to exit before attempting to get the
                // exit code. Not sure of the best way to achieve this.
                while (!_winsatProcess.HasExited)
                {
                    if (stopwatch.ElapsedMilliseconds > 5000)
                    {
                        break;
                    }

                    Thread.Sleep(500);
                }

                stopwatch.Stop();

                int exitCode =
                    WinsatReader.GetWinsatExitCodeFromLog();

                WinsatAssessmentState assessmentState =
                    (WinsatAssessmentState)WinsatAPI.QueryAssessmentState();

                rtbLogger.Log(
                    $"{AssessmentStrings.A_VALIDITY}:   {assessmentState}",
                    rtbLogType.Information,
                    rtbAssessment);

                rtbLogger.Log(
                    $"{AssessmentStrings.A_EXIT_CODE}:  {exitCode}",
                    rtbLogType.Application,
                    rtbAssessment);

                rtbLogger.Log(
                    $"{AssessmentStrings.A_MESSAGE}:    {WinsatReader.GetWinsatExitCodeString(exitCode)}",
                    rtbLogType.Application,
                    rtbAssessment);
            }
        }

        private void UpdateStatusLabelLonghorn(string data)
        {
            // Feature enumeration.
            if (data.Contains("formal -v"))
                lblStatus.Text = AssessmentStrings.A_RUN_FEATURE_ENUM;

            // Direct3D 9.
            if (data.Contains("-wddm -v"))
                lblStatus.Text = AssessmentStrings.A_RUN_ALL_D3D;

            // Media.
            if (data.Contains("winsatencode.wmv -encode"))
                lblStatus.Text = AssessmentStrings.A_RUN_WM_ENCODING_PERF;

            if (data.Contains("winsat.wmv -nopmp"))
                lblStatus.Text = AssessmentStrings.A_RUN_WM_PLAYBACK_PERF;

            // Processor.
            if (data.Contains("-encryption"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [1/4]";

            if (data.Contains("-compression"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [2/4]";

            if (data.Contains("-encryption2"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [3/4]";

            if (data.Contains("-compression2"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [4/4]";

            // Memory.
            if (data.Contains("Block size specified as"))
                lblStatus.Text = AssessmentStrings.A_RUN_MEM_PERF;

            // Disk.
            if (data.Contains("-ran") && data.Contains("-read"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_RR}]";

            if (data.Contains("-ran") && data.Contains("-write"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_RW}]";

            if (data.Contains("-seq") && data.Contains("-write"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_SR}]";

            if (data.Contains("-seq") && data.Contains("-read"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_SR}]";
        }

        private void UpdateStatusLabelOther(string data)
        {
            // Feature enumeration.
            if (data.Contains("formal -v"))
                lblStatus.Text = AssessmentStrings.A_RUN_FEATURE_ENUM;

            // Direct3D 9 (Does not run on Windows 10+).
            if (data.Contains("-aname DWM"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX9_DWM;

            if (data.Contains("-aname Batch"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX9_BATCH;

            if (data.Contains("-aname Alpha"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX9_ALPHA;

            if (data.Contains("-aname Tex"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX9_TEX;

            if (data.Contains("-aname ALU"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX9_ALU;

            // Direct3D 10 (Does not run on Windows 8.1+).
            if (data.Contains("-dx10  -aname Batch"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_BATCH;

            if (data.Contains("-dx10  -aname Alpha"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_ALPHA;

            if (data.Contains("-dx10  -aname Tex"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_TEX;

            if (data.Contains("-dx10  -aname ALU"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_ALU;

            if (data.Contains("-dx10  -aname Geom"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_GEOM;

            if (data.Contains("-dx10  -aname CBuffer"))
                lblStatus.Text = AssessmentStrings.A_RUN_DX10_CONSTBUFF;

            // Media (Does not run on Windows 10+).
            if (data.Contains("winsat.wmv -nopmp"))
                lblStatus.Text = AssessmentStrings.A_RUN_WM_PLAYBACK_PERF;

            // Processor.
            if (data.Contains("'-encryption -up'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [1/8]";

            if (data.Contains("'-compression -up'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [2/8]";

            if (data.Contains("'-encryption2 -up'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [3/8]";

            if (data.Contains("'-compression2 -up'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [4/8]";

            if (data.Contains("'-encryption'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [5/8]";

            if (data.Contains("'-compression'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [6/8]";

            if (data.Contains("'-encryption2'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [7/8]";

            if (data.Contains("'-compression2'"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_CPU_PERF} [8/8]";

            // Memory.
            if (data.Contains("Block size specified as"))
                lblStatus.Text = AssessmentStrings.A_RUN_MEM_PERF;

            // Disk.
            if (data.Contains("-ran") && data.Contains("-read"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_RR}]";

            if (data.Contains("-ran") && data.Contains("-write"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_RW}]";

            if (data.Contains("-seq") && data.Contains("-write"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_SR}]";

            if (data.Contains("-seq") && data.Contains("-read"))
                lblStatus.Text = $"{AssessmentStrings.A_RUN_DISK} [{AssessmentStrings.A_RUN_DISK_SR}]";

            if (data.Contains("-scen"))
                lblStatus.Text = AssessmentStrings.A_RUN_DISK;
        }
        #endregion

    }
}