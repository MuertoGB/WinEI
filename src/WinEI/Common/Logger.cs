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

    internal enum LogType
    {
        ApplicationLog,
        ImgurLog
    }

    internal class Logger
    {

        internal static void WriteToLog(string message, LogType logType)
        {
            string logPath = GetLogPath(logType);

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        internal static void WriteExceptionToAppLog(Exception e)
        {
            WriteToLog(
                $"{e.GetType().Name}:- {e.Message}\r\n\r\n{e}\r\n\r\n -------------------",
                LogType.ApplicationLog);
        }

        internal static string GetLogPath(LogType logType)
        {
            switch (logType)
            {
                case LogType.ApplicationLog:
                    return WEIPath.ApplicationLog;
                case LogType.ImgurLog:
                    return WEIPath.ImgurLinksFile;
                default:
                    throw new ArgumentException("Invalid log type");
            }
        }

        internal static void ViewAppLog(LogType logType)
        {
            string logPath = GetLogPath(logType);

            if (File.Exists(logPath))
            {
                Process.Start(logPath);
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