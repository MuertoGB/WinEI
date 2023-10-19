// WinEI
// https://github.com/MuertoGB/WinEI

// AppColours.cs
// Released under the GNU GLP v3.0

using System.Drawing;

namespace WinEI
{
    internal class AppColours
    {
        internal static readonly Color DEACTIVATED_WINDOW_TEXT = Color.FromArgb(100, 100, 100);
        internal static readonly Color ACTIVATED_WINDOW_TEXT = Color.FromArgb(255, 255, 255);
        internal static readonly Color THEME_PASTEL_BLUE = Color.FromArgb(55, 170, 255);
        internal static readonly Color SUBSCORE_MISMATCH_BACKCOLOR = Color.FromArgb(50, 50, 50);
        internal static readonly Color SUBSCORE_MATCH_BACKCOLOR = Color.FromArgb(35, 35, 35);
        internal static readonly Color OUTDATED_VERSION = Color.FromArgb(255, 128, 128);
        internal static readonly Color PANEL_INVALID = Color.Tomato;
        internal static readonly Color PANEL_VALID = Color.FromArgb(0, 200, 30);
    }
}