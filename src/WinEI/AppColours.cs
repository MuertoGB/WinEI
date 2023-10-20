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
        internal static readonly Color SUBSCORE_MISMATCH_BACKCOLOR = Color.FromArgb(50, 50, 50);
        internal static readonly Color SUBSCORE_MATCH_BACKCOLOR = Color.FromArgb(35, 35, 35);
        internal static readonly Color OUTDATED_VERSION = Color.FromArgb(255, 128, 128);
        internal static readonly Color PANEL_INVALID = Color.Tomato;
        internal static readonly Color PANEL_VALID = Color.FromArgb(0, 200, 30);

        internal static readonly Color ACCENT_0_DEFAULT = Color.FromArgb(55, 170, 255);
        internal static readonly Color ACCENT_1_MINT = Color.FromArgb(0, 255, 181);
        internal static readonly Color ACCENT_2_GREEN = Color.FromArgb(46, 220, 110);
        internal static readonly Color ACCENT_3_PINK = Color.FromArgb(240, 100, 240);
        internal static readonly Color ACCENT_4_GOLD = Color.FromArgb(230, 230, 75);
        internal static readonly Color ACCENT_5_RED = Color.FromArgb(255, 77, 77);
        internal static readonly Color ACCENT_6_ORANGE = Color.FromArgb(255, 160, 77);
    }
}