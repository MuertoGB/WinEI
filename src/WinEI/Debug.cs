// WinEI
// https://github.com/MuertoGB/WinEI

// Debug.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WenEI.Winsat;
using WinEI.Common;
using WinEI.Utils;

namespace WinEI
{
    internal class Debug
    {

        #region Functions
        internal static bool GetIsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        internal static string GetBitnessMode()
        {
            return IntPtr.Size == 8
                ? "x64"
                : "x86";
        }
        #endregion

        internal static string GenerateDebugReport(Exception e)
        {
            StringBuilder builder = new StringBuilder();

            string exePath =
                Path.Combine(
                    WEIPath.CurrentDirectory,
                    WEIPath.FriendlyName);

            try
            {
                byte[] appBytes =
                    File.ReadAllBytes(
                        exePath);

                builder.AppendLine($"WinEI Debug Log - {DateTime.Now}");
                builder.AppendLine("------------------------------------------------------\r\n");

                builder.AppendLine("<-- Application -->\r\n");
                builder.AppendLine($"Name:     {Application.ProductName}");
                builder.AppendLine($"Version:  {Application.ProductVersion}.{WEIVersion.Build}");
                builder.AppendLine($"Channel:  {WEIVersion.Channel}");
                builder.AppendLine($"Mode:     {GetBitnessMode()}");
                builder.AppendLine($"Debug:    {GetIsDebugMode()}");
                builder.AppendLine($"Elevated: {OSUtils.IsElevated()}");
                builder.AppendLine($"SHA256:   {CryptoUtils.GetSha256Digest(appBytes)}\r\n");

                builder.AppendLine("<-- Operating System -->\r\n");
                builder.AppendLine($"Name:     {OSUtils.GetWindowsName}");
                builder.AppendLine($"Bitness:  {OSUtils.GetSystemArchitecture()}");
                builder.AppendLine($"Kernel:   {OSUtils.GetKernelVersion.ProductVersion}");
                builder.AppendLine($"WinSAT:   {OSUtils.GetWinsatExeVersion.ProductVersion}");
                builder.AppendLine($"API:      {OSUtils.GetWinsatApiVersion.ProductVersion}");
                builder.AppendLine($"Bugged:   {WinsatBugChecker.IsBuggedVersion()}\r\n");

                builder.AppendLine("<-- Font Availability -->\r\n");
                builder.AppendLine($"Segoe UI Regular:  {FontResolver.DoesFontExist("Segoe UI", FontStyle.Regular)}");
                builder.AppendLine($"Segoe UI Semibold: {FontResolver.DoesFontExist("Segoe UI Semibold", FontStyle.Regular)}");
                builder.AppendLine($"Segoe UI Bold:     {FontResolver.DoesFontExist("Segoe UI", FontStyle.Bold)}\r\n");

                builder.AppendLine("<-- Exception Data -->\r\n");
                builder.AppendLine(GetExceptionData(e));

                builder.AppendLine("<-- Modules -->\r\n");
                builder.AppendLine(GetProcessModules());
                builder.AppendLine("# // End of file");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteExceptionToAppLog(ex);
                return null;
            }
        }

        private static string GetExceptionData(Exception e)
        {
            if (e == null)
                return $"Exception data was null.\r\n";

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"  Message ->\r\n");
            builder.AppendLine($"{e.Message}\r\n");
            builder.AppendLine($"  Exception ->\r\n");
            builder.AppendLine($"{e}");

            return builder.ToString();
        }

        private static string GetProcessModules()
        {
            int moduleNumber = 0;
            StringBuilder builder = new StringBuilder();

            try
            {
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
                {
                    moduleNumber++;

                    builder.AppendLine($"  Module #{moduleNumber} -> '{module.ModuleName}'\r\n");
                    builder.AppendLine($"Path:         {module.FileName}");
                    builder.AppendLine($"Version:      {module.FileVersionInfo.FileVersion}");
                    builder.AppendLine($"Description:  {module.FileVersionInfo.FileDescription}");
                    builder.AppendLine($"Size (Bytes): {module.ModuleMemorySize}");
                    builder.AppendLine($"Base Address: {module.BaseAddress}");
                    builder.AppendLine($"Entry Point:  {module.EntryPointAddress}\r\n");
                }

                return builder.ToString();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }

    }
}