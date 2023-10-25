// WinEI
// https://github.com/MuertoGB/WinEI

// FontResolver.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinEI.WIN32;

namespace WinEI.Common
{

    #region Enum
    internal enum FontStatus
    {
        Available,
        Missing,
        Unknown
    }
    #endregion

    internal class FontResolver
    {
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();

        internal static FontFamily LoadFontFromResource(byte[] fontData)
        {
            // Allocate unmanaged memory to hold the font data.
            IntPtr pFileView =
                Marshal.AllocCoTaskMem(
                    fontData.Length);

            // Copy the font data from the byte array to the allocated memory.
            Marshal.Copy(
                fontData,
                0,
                pFileView,
                fontData.Length);

            try
            {
                uint pNumFonts = 0;

                // Add the font data from the memory to the system's font collection.
                NativeMethods.AddFontMemResourceEx(
                    pFileView,
                    (uint)fontData.Length,
                    IntPtr.Zero,
                    ref pNumFonts);

                // Add the memory font to a private font collection.
                _privateFontCollection.AddMemoryFont(
                    pFileView,
                    fontData.Length);

                // Return the last font family added to the private font collection.
                return _privateFontCollection.Families.Last();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
            finally
            {
                // Ensure that the allocated memory is freed, even if an exception occurs.
                if (pFileView != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pFileView);
            }
        }

        internal static bool DoesFontExist(string fontName, FontStyle fontStyle)
        {
            try
            {
                using (FontFamily family = new FontFamily(fontName))
                    return family.IsStyleAvailable(fontStyle);
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static bool AreProgramFontsAvailable()
        {
            // Check for Segoe UI
            if (!FontResolver.DoesFontExist("Segoe UI", FontStyle.Regular))
                return false;

            // Check for Segoe UI Semibold
            if (!FontResolver.DoesFontExist("Segoe UI Semibold", FontStyle.Regular))
                return false;

            // Check for Segoe UI Bold
            if (!FontResolver.DoesFontExist("Segoe UI", FontStyle.Bold))
                return false;

            if (!FontResolver.DoesFontExist("Consolas", FontStyle.Regular))
                return false;

            return true;
        }

        internal static void HandleMissingFontExit()
        {
            StringBuilder missingFontsBuilder = new StringBuilder();

            if (!FontResolver.DoesFontExist("Segoe UI", FontStyle.Regular))
                missingFontsBuilder.AppendLine("Segoe UI, Regular");

            if (!FontResolver.DoesFontExist("Segoe UI Semibold", FontStyle.Regular))
                missingFontsBuilder.AppendLine("Segoe UI, Semibold");

            if (!FontResolver.DoesFontExist("Segoe UI", FontStyle.Bold))
                missingFontsBuilder.AppendLine("Segoe UI, Bold");

            if (!FontResolver.DoesFontExist("Consolas", FontStyle.Regular))
                missingFontsBuilder.AppendLine("Consolas, Regular");

            string errorMessage =
                $"{Strings.ERROR_FONTS_MISSING}\r\n\r\n" +
                $"{missingFontsBuilder}\r\n" +
                $"{Strings.QUESTION_VIEW_TROUBLESHOOTING}";

            DialogResult result =
                MessageBox.Show(
                    errorMessage,
                    Strings.ERROR,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
                Process.Start(
                    WEIUrl.GithubTsMissingFonts);

            Environment.Exit(ExitCodes.MISSING_FONT);
        }

        // For debugging
        internal static void WriteAvailableFontsAndStylesToFile(string path)
        {

            using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
            {
                FontFamily[] fontFamilies = fontsCollection.Families;

                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (FontFamily fontFamily in fontFamilies)
                    {
                        writer.WriteLine($"Font Family: {fontFamily.Name}");

                        foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                        {
                            if (fontFamily.IsStyleAvailable(style))
                            {
                                writer.WriteLine($"   - Style: {style}");
                            }
                        }

                        writer.WriteLine();
                    }
                }
            }
        }

    }
}