// https://github.com/MuertoGB/WinEI

// ImageUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class ImageUtils
    {
        internal static void CaptureControl(string filePath, Control control)
        {
            using (Bitmap bitmap = new Bitmap(control.Width, control.Height))
            {
                control.DrawToBitmap(
                    bitmap,
                    new Rectangle(
                        0, 0, control.Width, control.Height));

                bitmap.Save(
                    filePath,
                    ImageFormat.Png);
            }
        }

        internal static bool WaitForImageCreation(string imagePath)
        {
            TimeSpan timeout =
                new TimeSpan(0, 0, 2);

            Stopwatch stopwatch =
                Stopwatch.StartNew();

            while (true)
            {
                if (File.Exists(imagePath))
                {
                    break;
                }

                if (stopwatch.Elapsed >= timeout)
                {
                    MessageBox.Show(
                        "Image wait timeout.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            return true;
        }
    }
}