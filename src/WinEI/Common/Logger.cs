// WinEI
// https://github.com/MuertoGB/WinEI

// Logger.cs - Handles logging of data and text
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WinEI.Common
{
    internal class Logger
    {
        internal static void WriteToAppLog(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(
                WEIPath.ApplicationLog, true))
            {
                writer.WriteLine(
                    $"{DateTime.Now} : {logMessage}");
            }
        }

        internal static void WriteExceptionToAppLog(Exception e)
        {
            WriteToAppLog(
                $"{e.GetType().Name}:- {e.Message}\r\n\r\n{e}\r\n\r\n -------------------");
        }

        internal static void ViewAppLog()
        {
            if (File.Exists(WEIPath.ApplicationLog))
            {
                Process.Start(WEIPath.ApplicationLog);
                return;
            }

            MessageBox.Show(
                $"{Strings.LOG_NOT_FOUND}",
                Strings.ERROR,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}