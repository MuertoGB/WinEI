// WinEI
// https://github.com/MuertoGB/WinEI

// UI Components
// InterfaceUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinEI.UI
{

    #region Enums
    internal enum MenuPosition
    {
        TopRight,
        BottomLeft
    }
    #endregion

    internal class InterfaceUtils
    {
        internal static void ShowContextMenuAtControlPoint(
            object sender, ContextMenuStrip menu, MenuPosition menuPosition)
        {
            Control control = sender as Control;

            if (control == null)
                throw new ArgumentException(
                    "Invalid sender object type. Expected a Control.");

            Point position;

            switch (menuPosition)
            {
                case MenuPosition.TopRight:
                    position = control.PointToScreen(
                        new Point(
                            control.Width + 1,
                            -1));
                    break;
                case MenuPosition.BottomLeft:
                    position = control.PointToScreen(
                        new Point(
                            0,
                            control.Height + 1));
                    break;
                default:
                    throw new ArgumentException(
                        "Invalid MenuPosition value.");
            }

            menu.Show(position);
        }

        internal static void ShowContextMenuAtCursor(
            object sender, EventArgs e, ContextMenuStrip menu, bool showOnLeftClick)
        {
            MouseEventArgs mouseEventArgs =
                e as MouseEventArgs;

            if (mouseEventArgs != null
                && (mouseEventArgs.Button == MouseButtons.Right
                || (showOnLeftClick && mouseEventArgs.Button == MouseButtons.Left)))
                menu.Show(Cursor.Position);
        }
    }
}