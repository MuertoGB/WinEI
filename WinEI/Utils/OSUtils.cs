// WinEI
// https://github.com/MuertoGB/WinEI

// OSUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class OSUtils
    {
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
            catch (System.ComponentModel.Win32Exception ex)
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