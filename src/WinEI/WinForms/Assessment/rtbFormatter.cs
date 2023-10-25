// WinEI
// https://github.com/MuertoGB/WinEI

// rtbFormatter.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;

namespace WinEI
{
    internal static class rtbFormatter
    {
        internal static void Log(string inString, rtbLogType type, RichTextBox control)
        {
            string logType = string.Empty;
            Color logColour = Color.White;

            switch (type)
            {
                case rtbLogType.Application:
                    logType = "[WEI]: ";
                    logColour = LogColor.Application;
                    break;
                case rtbLogType.Winsat:
                    logType = "[WST]: ";
                    logColour = LogColor.Winsat;
                    break;
                case rtbLogType.Information:
                    logType = "[INF]: ";
                    logColour = LogColor.Information;
                    break;
                case rtbLogType.Okay:
                    logType = "[OKY]: ";
                    logColour = LogColor.Okay;
                    break;
                case rtbLogType.Warning:
                    logType = "[WRN]: ";
                    logColour = LogColor.Warning;
                    break;
                case rtbLogType.Error:
                    logType = "[ERR]: ";
                    logColour = LogColor.Error;
                    break;
            }

            if (control != null)
            {
                control.SelectionColor = logColour;
                control.AppendText(logType);
                control.SelectionColor = Color.White;
                control.AppendText($"{inString}\r\n");
                control.ScrollToCaret();
            }
        }
    }

    internal enum rtbLogType
    {
        Application,
        Winsat,
        Okay,
        Information,
        Warning,
        Error
    }

    internal static class LogColor
    {
        public static Color Application => Color.FromArgb(255, 51, 255);
        public static Color Winsat => Color.FromArgb(252, 209, 40);
        public static Color Information => Color.FromArgb(26, 209, 255);
        public static Color Okay => Color.FromArgb(0, 255, 0);
        public static Color Warning => Color.FromArgb(255, 133, 50);
        public static Color Error => Color.FromArgb(255, 20, 50);
    }
}