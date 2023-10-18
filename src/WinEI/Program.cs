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
using WinEI.WinSAT;

namespace WinEI
{

    #region Struct
    internal readonly struct WEIPath
    {
        internal static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string UnhandledLog = Path.Combine(CurrentDirectory, "unhandled.log");
        internal static readonly string ErrorLog = Path.Combine(CurrentDirectory, "error.log");
        internal static readonly string ApplicationLog = Path.Combine(CurrentDirectory, "application.log");
    }

    internal readonly struct WEIUrl
    {
        internal const string VersionManifest = "https://raw.githubusercontent.com/MuertoGB/WinEI/main/stream/manifests/version.xml";
        internal const string LatestRelease = "https://github.com/MuertoGB/WinEI/releases/latest";
    }

    internal readonly struct WEIVersion
    {
        internal const string Build = "231018.2120";
        internal const string Channel = "Pre-Alpha";
    }
    #endregion

    internal static class Program
    {

        #region Internal Members
        internal static mainWindow mWindow;
        internal static bool IsElevated;

        internal static Font FONT_MDL2_REG_10;
        internal static Font FONT_MDL2_REG_12;
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
            // Check winsat capability.
            if (!OSUtils.IsWinSatExePresent())
            {
                Logger.WriteToAppLog(
                    $"{Strings.FILE_NOT_FOUND}: {OSUtils.WinsatExePath}");

                HandleWinsatIncapableExit(
                    Strings.WINSAT_INCAPABLE_EXE,
                    ExitCodes.NOT_WINSAT_CAPABLE_EXE);
            }

            if (!OSUtils.IsWinsatApiPresent())
            {
                Logger.WriteToAppLog(
                    $"{Strings.FILE_NOT_FOUND}: {OSUtils.WinsatApiPath}");

                HandleWinsatIncapableExit(
                    Strings.WINSAT_INCAPABLE_API,
                    ExitCodes.NOT_WINSAT_CAPABLE_API);
            }

            // Register exception handler events early.
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Default framework settings.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if the program is running with elevated privilages
            IsElevated = OSUtils.IsElevated();

            // Set Web Security Protocol.
            ServicePointManager.SecurityProtocol =
                (SecurityProtocolType)3072;

            // Register application exit event.
            Application.ApplicationExit += OnExiting;

            // Register low level keyboard hook that disables Win+Up.
            KeyboardHookManager.Hook();

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
            }
            else
            {
                MessageBox.Show(
                    $"{Strings.SEGOE_MDL2} {Strings.FAILED_TO_LOAD}",
                    Strings.ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            WinsatReader.LoadWinsatData();

            // Create main window instance.
            mWindow = new mainWindow();

            // Run main window instance.
            Application.Run(mWindow);
        }

        private static void mWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private static void HandleWinsatIncapableExit(string message, int exitCode)
        {
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
                WEIPath.UnhandledLog,
                Debug.GenerateDebugReport(e));

            if (File.Exists(WEIPath.UnhandledLog))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{Strings.ERROR_SAVED_TO_LOG} {WEIPath.UnhandledLog.Replace(" ", Chars.NB_SPACE)}" +
                        $"'\r\n\r\n{Strings.APPLICATION_FORCE_QUIT}",
                        $"{e.GetType()}",
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

            // Fix for mainWindow opacity getting stuck at 0.5.
            if (mWindow.Opacity != 1.0)
                mWindow.Opacity = 1.0;
        }
        #endregion

        #region Exit Actions
        internal static void Exit() =>
            Application.Exit();

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