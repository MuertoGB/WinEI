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
        ImgurLinksFile
    }

    internal class Logger
    {

        internal static void WriteToLog(string message, LogType logType)
        {
            string path = GetLogPath(logType);
            string parent = Path.GetDirectoryName(path);

            if (Directory.Exists(parent))
                Directory.CreateDirectory(parent);

            using (StreamWriter writer = new StreamWriter(path, true))
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

        internal static void WriteToAssessmentLog(string data)
        {
            string path = WEIPath.AssessmentLog;
            string parent = Path.GetDirectoryName(path);

            if (Directory.Exists(parent))
                Directory.CreateDirectory(parent);

            using (FileStream stream = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(data);
            }
        }

        internal static string GetLogPath(LogType logType)
        {
            switch (logType)
            {
                case LogType.ApplicationLog:
                    return WEIPath.ApplicationLog;
                case LogType.ImgurLinksFile:
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