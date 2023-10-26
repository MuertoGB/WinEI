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
using System.Timers;
using System.Windows.Forms;
using WenEI.Winsat;
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
            FormClosed += assessWindow_FormClosed;

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

            ProcessStartInfo startInfo = new ProcessStartInfo(
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

        private void assessWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_assessmentComplete)
                return;

            // ***TODO***
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
            cmdCancel.PerformClick();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (!_assessmentComplete && !_winsatProcess.HasExited)
            {
                // Write to log, assessment interrupted. Confirm dialog?
                StopWatchdog();
                StopWinsatProcess();
            }

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

        #region Watchdog
        private void WatchdogElapsed(object sender, ElapsedEventArgs elapsed)
        {
            if (_assessmentComplete)
                return;

            if (!_assessmentComplete && _winsatProcess.HasExited)
            {
                StopWatchdog();

                rtbFormatter.Log(
                    "Watchdog: WinSAT was killed, or unexpectedly quit.",
                    rtbLogType.Error,
                    rtbAssessment);
            }
        }

        private void StopWatchdog()
        {
            if (_watchdog.Enabled)
            {
                rtbFormatter.Log(
                    "Shutting down Watchdog...",
                    rtbLogType.Application,
                    rtbAssessment);

                while (_watchdog.Enabled)
                    _watchdog.Stop();

                rtbFormatter.Log(
                    "Watchdog shutdown completed",
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
                rtbFormatter.Log(
                    "Shutting down WinSAT process...",
                    rtbLogType.Application,
                    rtbAssessment);

                while (!_winsatProcess.HasExited)
                {
                    _winsatProcess.Kill();
                }

                rtbFormatter.Log(
                    "WinSAT process stopped successfully",
                    rtbLogType.Okay,
                    rtbAssessment);

                rtbFormatter.Log(
                    "Process completed",
                    rtbLogType.Information,
                    rtbAssessment);
            }
        }
        #endregion

        #region UI Events
        private void GetInitialLogData()
        {
            rtbFormatter.Log(
                $"Started:   {DateTime.Now.ToString(Strings.WINSAT_DATE_FORMAT)}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"Version:   {WEIVersion.Version}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"Channel:   {WEIVersion.Channel}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"System:    {OSUtils.GetWindowsName} " +
                $"{OSUtils.GetWindowsBuild} " +
                $"{OSUtils.GetSystemArchitecture()}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"Culture:   {OSUtils.GetSystemCulture}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"EXE:       {OSUtils.GetWinsatExePrivateVersion}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"API:       {OSUtils.GetWinsatApiVersion.ProductVersion}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"Bugged:    {WinsatBugChecker.IsBuggedVersion()}",
                rtbLogType.Information,
                rtbAssessment);

            rtbFormatter.Log(
                $"Validity:  {WinsatReader.ASSESSMENT_STATE}",
                rtbLogType.Winsat,
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
            rtbFormatter.Log(
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
            {
                UpdateStatusLabelLonghorn(data);
            }
            else
            {
                UpdateStatusLabelOther(data);
            }

            // Assessment is still running. Leave code.
            if (!data.Contains("Composition restarted"))
                return;

            // Asessment is finished.
            _assessmentComplete = true;

            // Stop the WinSAT watchdog.
            StopWatchdog();

            // Warning and error counts (only supports English lang for now).
            if (_warningCount > 0)
                rtbFormatter.Log(
                    $"The assessment ran with " +
                    $"{(_warningCount > 1 ? "warnings." : "warning.")}",
                    rtbLogType.Warning,
                    rtbAssessment);

            if (_errorCount > 0)
                rtbFormatter.Log(
                    $"The assessment ran with " +
                    $"{(_errorCount > 1 ? "errors." : "error.")}",
                    rtbLogType.Error,
                    rtbAssessment);

            rtbFormatter.Log(
                "Assessment completed.",
                rtbLogType.Information,
                rtbAssessment);
        }

        private void UpdateStatusLabelLonghorn(string data)
        {
            // Feature enumeration.
            if (data.Contains("formal -v"))
                lblStatus.Text = "Running Feature Enumeration";

            // Direct3D 9.
            if (data.Contains("-wddm -v"))
                lblStatus.Text = "Running D3D9 Assessments";

            // Media.
            if (data.Contains("winsatencode.wmv -encode"))
                lblStatus.Text = "Assessing Windows Media Encoding Performance";

            if (data.Contains("winsat.wmv -nopmp"))
                lblStatus.Text = "Assessing Windows Media Playback Performance";

            // Processor.
            if (data.Contains("-encryption"))
                lblStatus.Text = "Assessing CPU Performance [1/4]";

            if (data.Contains("-compression"))
                lblStatus.Text = "Assessing CPU Performance [2/4]";

            if (data.Contains("-encryption2"))
                lblStatus.Text = "Assessing CPU Performance [3/4]";

            if (data.Contains("-compression2"))
                lblStatus.Text = "Assessing CPU Performance [4/4]";

            // Memory.
            if (data.Contains("Block size specified as"))
                lblStatus.Text = "Assessing Memory Performance [1/1]";

            // Disk.
            if (data.Contains("-ran") && data.Contains("-read"))
                lblStatus.Text = "Assessing Disk Performance [Ran/Read]";

            if (data.Contains("-ran") && data.Contains("-write"))
                lblStatus.Text = "Assessing Disk Performance [Ran/Write]";

            if (data.Contains("-seq") && data.Contains("-write"))
                lblStatus.Text = "Assessing Disk Performance [Seq/Write]";

            if (data.Contains("-seq") && data.Contains("-read"))
                lblStatus.Text = "Assessing Disk Performance [Seq/Read]";
        }

        private void UpdateStatusLabelOther(string data)
        {
            // Feature enumeration.
            if (data.Contains("formal -v"))
                lblStatus.Text = "Running Feature Enumeration";

            // Direct3D 9 (Does not run on Windows 10+).
            if (data.Contains("-aname DWM"))
                lblStatus.Text = "Running the D3D9 Aero Assessment";

            if (data.Contains("-aname Batch"))
                lblStatus.Text = "Running the D3D9 Batch Assessment";

            if (data.Contains("-aname Alpha"))
                lblStatus.Text = "Running the D3D9 Alpha Blend Assessment";

            if (data.Contains("-aname Tex"))
                lblStatus.Text = "Running the D3D9 Texture Load Assessment";

            if (data.Contains("-aname ALU"))
                lblStatus.Text = "Running the D3D9 ALU Assessment";

            // Direct3D 10 (Does not run on Windows 8.1+).
            if (data.Contains("-dx10  -aname Batch"))
                lblStatus.Text = "Running the D3D10 Batch Assessment";

            if (data.Contains("-dx10  -aname Alpha"))
                lblStatus.Text = "Running the D3D10 Alpha Blend Assessment";

            if (data.Contains("-dx10  -aname Tex"))
                lblStatus.Text = "Running the D3D10 Texture Load Assessment";

            if (data.Contains("-dx10  -aname ALU"))
                lblStatus.Text = "Running the D3D10 ALU Assessment";

            if (data.Contains("-dx10  -aname Geom"))
                lblStatus.Text = "Running the Direct3D 10 Geometry Assessment";

            if (data.Contains("-dx10  -aname CBuffer"))
                lblStatus.Text = "Running the D3D10 Constant Buffer Assessment";

            // Media (Does not run on Windows 10+).
            if (data.Contains("winsat.wmv -nopmp"))
                lblStatus.Text = "Assessing Windows Media Playback Performance";

            // Processor.
            if (data.Contains("'-encryption -up'"))
                lblStatus.Text = "Assessing CPU Performance [1/8]";

            if (data.Contains("'-compression -up'"))
                lblStatus.Text = "Assessing CPU Performance [2/8]";

            if (data.Contains("'-encryption2 -up'"))
                lblStatus.Text = "Assessing CPU Performance [3/8]";

            if (data.Contains("'-compression2 -up'"))
                lblStatus.Text = "Assessing CPU Performance [4/8]";

            if (data.Contains("'-encryption'"))
                lblStatus.Text = "Assessing CPU Performance [5/8]";

            if (data.Contains("'-compression'"))
                lblStatus.Text = "Assessing CPU Performance [6/8]";

            if (data.Contains("'-encryption2'"))
                lblStatus.Text = "Assessing CPU Performance [7/8]";

            if (data.Contains("'-compression2'"))
                lblStatus.Text = "Assessing CPU Performance [8/8]";

            // Memory.
            if (data.Contains("Block size specified as"))
                lblStatus.Text = "Assessing Memory Performance [1/1]";

            // Disk.
            if (data.Contains("-ran") && data.Contains("-read"))
                lblStatus.Text = "Assessing Disk Performance [Ran/Read]";

            if (data.Contains("-ran") && data.Contains("-write"))
                lblStatus.Text = "Assessing Disk Performance [Ran/Write]";

            if (data.Contains("-seq") && data.Contains("-write"))
                lblStatus.Text = "Assessing Disk Performance [Seq/Write]";

            if (data.Contains("-seq") && data.Contains("-read"))
                lblStatus.Text = "Assessing Disk Performance [Seq/Read]";

            if (data.Contains("-scen"))
                lblStatus.Text = "Assessing Disk Performance";
        }
        #endregion

    }
}