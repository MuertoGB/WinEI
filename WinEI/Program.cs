// WinEI
// https://github.com/MuertoGB/WinEI

// Program.cs
// Released under the GNU GLP v3.0
// WinEI uses embedded font resource "Segoe MDL2 Assets" which is copyright Microsoft Corp.

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WinEI.Common;
using WinEI.UI;
using WinEI.Utils;

namespace WinEI
{

    #region Struct
    internal readonly struct WEIPath
    {
        internal static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal static readonly string FriendlyName = AppDomain.CurrentDomain.FriendlyName;
        internal static readonly string UnhandledLog = Path.Combine(CurrentDirectory, "unhandled.log");
    }

    internal readonly struct WEIVersion
    {
        internal const string Build = "231015.2315";
        internal const string Channel = "N/A";
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
                    "Segoe MDL2 Assets font failed to load, see ./mefit.log for more details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Create main window instance.
            mWindow = new mainWindow();

            // Run main window instance.
            Application.Run(mWindow);
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

            //File.WriteAllText(
            //    WEIPath.UnhandledLog,
            //    Debug.GenerateDebugReport(e));

            if (File.Exists(WEIPath.UnhandledLog))
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\nDetails were saved to {WEIPath.UnhandledLog.Replace(" ", Chars.NB_SPACE)}" +
                        $"'\r\n\r\nForce quit application?",
                        $"MET Exception Handler",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
            }
            else
            {
                result =
                    MessageBox.Show(
                        $"{e.Message}\r\n\r\n{e}\r\n\r\nForce quit application?",
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

    }
}