// WinEI
// https://github.com/MuertoGB/WinEI

// Program.cs
// Released under the GNU GLP v3.0
// WinEI uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WinEI.Common;
using WinEI.Utils;
using WinEI.Winsat;

namespace WinEI
{

    #region Struct
    internal readonly struct WEIPath
    {
        internal static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string SettingsIni = Path.Combine(CurrentDirectory, "settings.ini");
        internal static readonly string DebugLog = Path.Combine(CurrentDirectory, "debug.log");
        internal static readonly string ApplicationLog = Path.Combine(CurrentDirectory, "application.log");
        internal static readonly string ImgurLinksFile = Path.Combine(CurrentDirectory, "imgur.log");
    }

    internal readonly struct WEIUrl
    {
        internal const string Donate = "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ";
        internal const string Email = "mailto:muertogb@proton.me";
        internal const string GithubChangelog = "https://github.com/MuertoGB/WinEI/blob/main/CHANGELOG.md";
        internal const string GithubHomepage = "https://github.com/MuertoGB/WinEI";
        internal const string GithubIssues = "https://github.com/MuertoGB/WinEI/issues";
        internal const string GithubLatestRelease = "https://github.com/MuertoGB/WinEI/releases/latest";
        internal const string GithubSource = "https://github.com/MuertoGB/WinEI/tree/main/src";
        internal const string GithubVersionManifest = "https://raw.githubusercontent.com/MuertoGB/WinEI/main/stream/manifests/version.xml";
        internal const string ImgurAddress = "https://www.imgur.com";
        internal const string MediaFeaturePackAddress = "http://windows.microsoft.com/en-gb/windows/download-windows-media-player";
    }

    internal readonly struct WEIVersion
    {
        internal const string Build = "231023.2350";
        internal static readonly string Version = $"{Application.ProductVersion}.{Build}";
        internal const string Channel = "PRE-ALPHA";
    }
    #endregion

    #region Enums
    internal enum ExportType
    {
        None,
        Image,
        Text
    }
    #endregion

    internal static class Program
    {

        #region Internal Members
        internal static mainWindow mWindow;
        internal static ExportType EXPORT_TYPE =
            ExportType.None;

        internal static Font FONT_MDL2_REG_10;
        internal static Font FONT_MDL2_REG_12;
        internal static Font FONT_MDL2_REG_20;
        #endregion

        #region Const Members
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        internal const int WS_MINIMIZEBOX = 0x20000;
        internal const int CS_DBLCLKS = 0x8;
        internal const int CS_DROP = 0x20000;
        #endregion

        #region Main Entry Point
        [STAThread]
        static void Main()
        {
            // Check Operating System is not < Vista.
            if (OSUtils.GetKernelVersion.ProductMajorPart < 5)
            {
                HandleCodeExit(
                    Strings.ERROR_WINSAT_OS,
                    ExitCodes.INCOMPATIBLE_OS);
            }

            // Check winsat capability by looking for the executable and API.
            if (!OSUtils.IsWinSatExePresent())
            {
                HandleCodeExit(
                    Strings.ERROR_WINSAT_EXE,
                    ExitCodes.NOT_WINSAT_CAPABLE_EXE);
            }

            if (!OSUtils.IsWinsatApiPresent())
            {
                HandleCodeExit(
                    Strings.ERROR_WINSAT_API,
                    ExitCodes.NOT_WINSAT_CAPABLE_API);
            }

            // Register exception handler events.
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Default framework settings.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set Web Security Protocol.
            ServicePointManager.SecurityProtocol =
                (SecurityProtocolType)3072;

            // Wire application exit event.
            Application.ApplicationExit += OnExiting;

            // Create any memory font instances.
            byte[] fontData = Properties.Resources.segmdl2;

            if (fontData != null)
            {
                FONT_MDL2_REG_10 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        10.0F,
                        FontStyle.Regular);
                FONT_MDL2_REG_12 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        12.0F,
                        FontStyle.Regular);
                FONT_MDL2_REG_20 =
                    new Font(
                        FontResolver.LoadFontFromResource(fontData),
                        20.0F,
                        FontStyle.Regular);
            }
            else
            {
                MessageBox.Show(
                    Strings.SEGOE_MDL2_FAILED_TO_LOAD,
                    Strings.ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Initialize settings ini.
            Settings.Initialize();

            // Load WinSAT data.
            WinsatReader.LoadWinsatData();

            // Register low level keyboard hook that disables Win+Up.
            KeyboardHookManager.Hook();

            // Create main window instance.
            mWindow = new mainWindow();

            // Run main window instance.
            Application.Run(mWindow);
        }

        private static void mWindow_FormClosed(object sender, FormClosedEventArgs e) =>
            Application.Exit();

        private static void HandleCodeExit(string message, int exitCode)
        {
            Logger.WriteToLog(
                $"{Strings.EXITED_WITH_CODE} ({exitCode}). {message}",
                LogType.ApplicationLog);

            MessageBox.Show(
                message + $"\r\n\r\n{Strings.APPLICATION_WILL_EXIT}",
                Strings.ERROR,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            // No need to clean up. Fonts, etc, have not been loaded yet.
            Environment.Exit(exitCode);
        }
        #endregion

        #region OnExit
        private static void OnExiting(object sender, EventArgs e) =>
            HandleOnExitingCleanup();

        internal static void HandleOnExitingCleanup()
        {
            // Dispose of memory fonts.
            FONT_MDL2_REG_10?.Dispose();
            FONT_MDL2_REG_12?.Dispose();
            FONT_MDL2_REG_20?.Dispose();

            // Unhook the low level keyboard hook.
            KeyboardHookManager.Unhook();
        }
        #endregion

        #region Exception Handler
        internal static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e != null)
                ExceptionHandler(e.Exception);
        }

        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            if (ex != null)
                ExceptionHandler(ex);
        }

        internal static void ExceptionHandler(Exception e)
        {
            DialogResult result;

            File.WriteAllText(
                WEIPath.DebugLog,
                Debug.GenerateDebugReport(e));

            if (File.Exists(WEIPath.DebugLog))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{Strings.DETAILS_SAVED_TO} {WEIPath.DebugLog.Replace(" ", Chars.NB_SPACE)}" +
                        $"\r\n\r\n{Strings.APPLICATION_FORCE_QUIT}",
                        Strings.EXCEPTION_HANDLER,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }
            else
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{e}\r\n\r\n{Strings.APPLICATION_FORCE_QUIT}",
                        $"{e.GetType()}",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }

            if (result == DialogResult.Yes)
            {
                // We need to clean any necessary objects as OnExit will not fire
                // when Environment.Exit is called.
                HandleOnExitingCleanup();

                Environment.Exit(-1);
            }

            // Fix for mainWindow opacity getting stuck.
            if (mWindow.Opacity != 1.0)
                mWindow.Opacity = 1.0;
        }
        #endregion

        #region Exit Actions
        internal static void Restart()
        {
            try
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            catch (Win32Exception) { return; }
        }
        #endregion

    }
}