// WinEI
// https://github.com/MuertoGB/WinEI

// OSUtils.cs
// Released under the GNU GLP v3.0

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class OSUtils
    {

        #region Internal Members
        internal static readonly string SystemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        internal static readonly string WindowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        internal static readonly string WinsatExePath = Path.Combine(SystemPath, "WinSAT.exe");
        internal static readonly string WinsatApiPath = Path.Combine(SystemPath, "winsatapi.dll");
        internal static readonly string KernelPath = Path.Combine(SystemPath, "kernel32.dll");
        #endregion

        #region Strings
        internal static string GetWindowsName
        {
            get
            {
                string productName = GetWindowsProductName();
                string cleanName = CleanProductName(productName);

                if (GetWindowsBuild >= 22000 && cleanName.Contains("10"))
                    cleanName = cleanName.Replace("10", "11");

                return cleanName;
            }
        }

        private static string GetWindowsProductName()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                return key?.GetValue("ProductName") as string ?? string.Empty;
            }
        }

        private static string CleanProductName(string productName)
        {
            return productName.Replace(" (TM)", string.Empty);
        }

        internal static string GetSystemArchitecture(bool shortString = false) =>
            Environment.Is64BitOperatingSystem
            ? (shortString ? "x64" : "64-Bit")
            : (shortString ? "x86" : "32-Bit");

        internal static string GetSystemCulture =>
            CultureInfo.CurrentCulture.Name;

        internal static string GetSystemInstallDate
        {
            get
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null && key.GetValue("InstallDate") is int intValue)
                    {
                        DateTime installDateTime =
                            new DateTime(
                                1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(intValue).ToLocalTime();

                        return installDateTime.ToString();
                    }
                }

                return AppStrings.UNKNOWN;
            }
        }

        internal static string GetKernelUptime(uint kernelValue)
        {
            uint tickCount =
                kernelValue / 1000;

            int days =
                (int)(tickCount / 3600 / 24);

            int hours =
                (int)((tickCount / 3600) % 24);

            int minutes =
                (int)((tickCount % 3600) / 60);

            int seconds =
                (int)(tickCount % 60);

            return $"{days}d, {hours:D2}h, {minutes:D2}m, {seconds:D2}s";
        }

        internal static string GetWinsatExePrivateVersion
        {
            get
            {
                // Get the current winsat executable version.
                FileVersionInfo fvi = GetWinsatExeVersion;

                // Build version string with the private part, we cannot
                // do it with ProductVersion alone.
                return $"{fvi.FileMajorPart}." +
                       $"{fvi.FileMinorPart}." +
                       $"{fvi.FileBuildPart}." +
                       $"{fvi.FilePrivatePart}";
            }
        }
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
            if (GetKernelVersion.ProductMajorPart == 6
                && GetKernelVersion.ProductMinorPart == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsSeven()
        {
            if (GetKernelVersion.ProductMajorPart == 6
                && GetKernelVersion.ProductMinorPart == 1)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsEight()
        {
            if (GetKernelVersion.ProductMajorPart == 6
                && GetKernelVersion.ProductMinorPart > 1)
            {
                return true;
            }

            return false;
        }

        internal static bool IsWindowsTenPlus()
        {
            if (GetKernelVersion.ProductMajorPart == 10)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region File Version
        internal static FileVersionInfo GetWinsatExeVersion =>
            FileVersionInfo.GetVersionInfo(WinsatExePath);

        internal static FileVersionInfo GetWinsatApiVersion =>
            FileVersionInfo.GetVersionInfo(WinsatApiPath);

        internal static FileVersionInfo GetKernelVersion =>
            FileVersionInfo.GetVersionInfo(KernelPath);
        #endregion

        #region Elevation
        internal static void RestartElevated()
        {
            ProcessStartInfo startInfo =
                new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = WEIPath.CurrentDirectory,
                    FileName = WEIPath.FriendlyName,
                    Verb = "runas"
                };

            try
            {
                Process elevatedProcess =
                    new Process
                    {
                        StartInfo = startInfo
                    };

                elevatedProcess.Start();

                // We need to clean any necessary objects as OnExit will not fire
                // when Environment.Exit is called.
                Program.HandleOnExitingCleanup();

                Environment.Exit(
                    ExitCodes.ELEVATED_RESTART);
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(
                    $"{ExceptionStrings.EX_ELEVATED_RESTART}\r\n{e.Message}",
                    AppStrings.ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}