// WinEI
// https://github.com/MuertoGB/WinEI

// OSUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class OSUtils
    {

        #region Private Members
        private static readonly string _winsatExeName =
            "WinSAT.exe";

        private static readonly string _winsatApiName =
            "WinSATAPI.dll";

        private static readonly string _systemPath =
            Environment.GetFolderPath(Environment.SpecialFolder.System);
        #endregion

        #region Internal Members
        internal static readonly string WinsatExePath =
            Path.Combine(_systemPath, _winsatExeName);

        internal static readonly string WinsatApiPath =
            Path.Combine(_systemPath, _winsatApiName);
        #endregion

        internal static string GetWindowsName =>
            new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName.Replace(
                "Microsoft ", string.Empty);

        internal static string GetBitness(bool shortString = false) =>
            Environment.Is64BitOperatingSystem
            ? (shortString ? "x64" : "64-Bit")
            : (shortString ? "x86" : "32-Bit");

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(
                Path.Combine(
                    Environment.SystemDirectory,
                    "kernel32.dll"));

        internal static bool IsElevated()
        {
            return new WindowsPrincipal(
                WindowsIdentity.GetCurrent()).IsInRole(
                WindowsBuiltInRole.Administrator);
        }

        internal static bool IsWinSatExePresent()
        {
            return File.Exists(WinsatExePath);
        }

        internal static bool IsWinsatApiPresent()
        {
            return File.Exists(WinsatApiPath);
        }

        internal static void RestartElevated()
        {
            var psiInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = WEIPath.CurrentDirectory,
                FileName = WEIPath.FriendlyName,
                Verb = "runas"
            };

            try
            {
                var elevatedInstance = new Process
                {
                    StartInfo = psiInfo
                };

                elevatedInstance.Start();

                // We need to clean any necessary objects as OnExit will not fire
                // when Environment.Exit is called.
                Program.HandleOnExitingCleanup();

                Environment.Exit(ExitCodes.ELEVATED_RESTART);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(
                    $"Could not perform elevated restart.\r\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}