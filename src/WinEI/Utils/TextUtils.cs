// WinEI
// https://github.com/MuertoGB/WinEI

// TextUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinEI.Common;
using WinEI.UI;
using WinEI.Winsat;

namespace WinEI.Utils
{
    internal class TextUtils
    {
        internal static void SaveAsTextWithDialog(string text, string name, Form owner)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                Filter = "Text File|*.txt",
                FileName = name,
                OverwritePrompt = true
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    File.WriteAllText(fileName, text);

                    if (File.Exists(fileName))
                    {
                        DialogResult result =
                            WEIMessageBox.Show(
                                owner,
                                Strings.INFORMATION,
                                Strings.QUESTION_EXPORT_NAVIGATE,
                                WEIMessageBoxType.Question,
                                WEIMessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            FileUtils.HighlightPathInExplorer(
                                fileName);
                        }

                        return;
                    }

                    WEIMessageBox.Show(
                        owner,
                        Strings.ERROR,
                        Strings.ERROR_EXPORT_NOT_FOUND,
                        WEIMessageBoxType.Error,
                        WEIMessageBoxButtons.Okay);
                }
            }
        }

        internal static string BuildWinsatTextOutput()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("WINSPR");
            builder.AppendLine("-------------------------------------------");
            builder.AppendLine($"State:       {WinsatReader.ASSESSMENT_STATE}\r\n");
            builder.AppendLine($"Base Score:  " +
                $"{WinsatReader.WINSPR.BaseScore}");
            builder.AppendLine($" Processor:  " +
                $"{WinsatReader.WINSPR.ProcessorScore}{GetLowestIfMatchesBase(WinsatReader.WINSPR.ProcessorScore)}");
            builder.AppendLine($" Memory:     " +
                $"{WinsatReader.WINSPR.MemoryScore}{GetLowestIfMatchesBase(WinsatReader.WINSPR.MemoryScore)}");
            builder.AppendLine($" Graphics:   " +
                $"{WinsatReader.WINSPR.GraphicsScore}{GetLowestIfMatchesBase(WinsatReader.WINSPR.GraphicsScore)}");
            builder.AppendLine($" D3D:        " +
                $"{WinsatReader.WINSPR.D3DScore}{GetLowestIfMatchesBase(WinsatReader.WINSPR.D3DScore)}");
            builder.AppendLine($" Disk:       " +
                $"{WinsatReader.WINSPR.DiskScore}{GetLowestIfMatchesBase(WinsatReader.WINSPR.DiskScore)}\r\n");
            builder.AppendLine("API HARDWARE");
            builder.AppendLine("-------------------------------------------");
            builder.AppendLine($"{WinsatReader.API_HARDWARE.Processor}");
            builder.AppendLine($"{WinsatReader.API_HARDWARE.Memory}");
            builder.AppendLine($"{WinsatReader.API_HARDWARE.Graphics}");
            builder.AppendLine($"{WinsatReader.API_HARDWARE.D3D}");
            builder.AppendLine($"{WinsatReader.API_HARDWARE.Disk}\r\n");
            builder.AppendLine("XML HARDWARE");
            builder.AppendLine("-------------------------------------------");
            builder.AppendLine($"{WinsatReader.XML_HARDWARE.Processor}");
            builder.AppendLine(
                $"{MemoryType.Convert(WinsatReader.XML_HARDWARE.Memory)} " +
                $"{FileUtils.GetBytesReadableSize(WinsatReader.XML_HARDWARE.MemorySizeBytes)}");
            builder.AppendLine($"{WinsatReader.XML_HARDWARE.Graphics}");
            builder.AppendLine($"{FileUtils.ConvertBytesToMB(WinsatReader.XML_HARDWARE.VramSizeMegabytes)} VRAM");
            builder.AppendLine($"{WinsatReader.XML_HARDWARE.Disk}");

            return builder.ToString();
        }

        private static string GetLowestIfMatchesBase(string score)
        {
            return score == WinsatReader.WINSPR.BaseScore
                ? " (Lowest Subscore)"
                : string.Empty;
        }

    }
}