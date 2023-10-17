using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

                builder.AppendLine($"# // WinEI Toolkit Debug Log - {DateTime.Now}\r\n");

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
                builder.AppendLine($"Bitness:  {OSUtils.GetBitness()}");
                builder.AppendLine($"Kernel:   {OSUtils.GetKernelVersion.ProductVersion}\r\n");

                builder.AppendLine("<-- Fonts -->\r\n");
                builder.AppendLine($"Segoe UI Reg: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Regular)}");
                builder.AppendLine($"Segoe UI Bol: {FontResolver.IsFontStyleAvailable("Segoe UI", FontStyle.Bold)}");
                builder.AppendLine($"Segoe UI Sem: {FontResolver.IsFontStyleAvailable("Segoe UI Semibold", FontStyle.Regular)}\r\n");

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