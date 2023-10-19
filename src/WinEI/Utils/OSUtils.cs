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

        private static readonly string _kernelName =
            "kernel32.dll";
        #endregion

        #region Internal Members
        internal static readonly string SystemPath =
            Environment.SystemDirectory;

        internal static readonly string WindowsPath =
            Environment.GetFolderPath(Environment.SpecialFolder.Windows);

        internal static readonly string WinsatExePath =
            Path.Combine(SystemPath, _winsatExeName);

        internal static readonly string WinsatApiPath =
            Path.Combine(SystemPath, _winsatApiName);

        internal static readonly string KernelPath =
            Path.Combine(SystemPath, _kernelName);
        #endregion

        #region Strings
        internal static string GetWindowsName =>
            new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName.Replace(
                "Microsoft ", string.Empty);

        internal static string GetSystemArchitecture(bool shortString = false) =>
            Environment.Is64BitOperatingSystem
            ? (shortString ? "x64" : "64-Bit")
            : (shortString ? "x86" : "32-Bit");
        #endregion

        #region Integers
        internal static int GetWindowsBuild =>
            Environment.OSVersion.Version.Build;
        #endregion

        #region Bools
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

        internal static bool IsWindowsVista()
        {
            if (GetWinsatExeVersion.ProductMajorPart == 6
                && GetWinsatExeVersion.ProductMinorPart == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsSeven()
        {
            if (GetWinsatExeVersion.ProductMajorPart == 6
                && GetWinsatExeVersion.ProductMinorPart == 1)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsEight()
        {
            if (GetWinsatExeVersion.ProductMajorPart == 6
                && GetWinsatExeVersion.ProductMinorPart > 1)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsTenPlus()
        {
            if (GetWinsatExeVersion.ProductMajorPart == 10)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region File Version
        internal static FileVersionInfo GetWinsatExeVersion =>
            FileVersionInfo.GetVersionInfo(
                Path.Combine(WinsatExePath));

        internal static FileVersionInfo GetWinsatApiVersion =>
            FileVersionInfo.GetVersionInfo(
                Path.Combine(WinsatApiPath));

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(
                Path.Combine(KernelPath));
        #endregion

        #region Elevation
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
        #endregion

    }
}