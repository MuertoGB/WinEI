// https://github.com/MuertoGB/WinEI

// ImageUtils.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class ImageUtils
    {
        internal static Bitmap GetBitmapOfControl(Control control)
        {
            Bitmap bitmap =
                new Bitmap(
                    control.Width,
                    control.Height);

            control.DrawToBitmap(
                bitmap,
                new Rectangle(
                    0, 0, control.Width, control.Height));

            return bitmap;
        }
    }
}