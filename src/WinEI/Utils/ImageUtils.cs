// WinEI
// https://github.com/MuertoGB/WinEI

// ImageUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WinEI.UI;

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
                    0,
                    0,
                    control.Width,
                    control.Height));

            return bitmap;
        }

        internal static void SaveImageWithDialog(Bitmap bitmap, Form owner)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyPictures),
                Filter = "PNG Image|*.png|Bitmap Image|*.bmp",
                FileName = "winei-screenshot",
                OverwritePrompt = true
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    ImageFormat format =
                        ImageFormat.Png;

                    if (saveFileDialog.FilterIndex == 1)
                    {
                        format = ImageFormat.Png;
                    }
                    else if (saveFileDialog.FilterIndex == 2)
                    {
                        format = ImageFormat.Bmp;
                    }

                    bitmap.Save(path, format);

                    if (File.Exists(path))
                    {
                        DialogResult result =
                            WEIMessageBox.Show(
                                owner,
                                AppStrings.INFORMATION,
                                DialogStrings.Q_EXPORT_NAVIGATE,
                                WEIMessageBoxType.Question,
                                WEIMessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            FileUtils.HighlightPathInExplorer(
                                path);
                        }

                        return;
                    }

                    WEIMessageBox.Show(
                        owner,
                        AppStrings.ERROR,
                        ExceptionStrings.EX_FILE_EXPORT_NF,
                        WEIMessageBoxType.Error,
                        WEIMessageBoxButtons.Okay);
                }
            }
        }
    }
}