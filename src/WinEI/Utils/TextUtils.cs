// WinEI
// https://github.com/MuertoGB/WinEI

// TextUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Windows.Forms;
using WinEI.UI;

namespace WinEI.Utils
{
    internal class TextUtils
    {
        internal static void SaveAsTextWithDialog(string text, Form owner)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                Filter = "Text File|*.txt",
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
                                "Export successful. Navigate to file in explorer?",
                                WEIMessageBoxType.Question,
                                WEIMessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            FileUtils.HighlightPathInExplorer(
                                fileName);
                        }

                        return;
                    }
                }

                // ***TODO***
                // The output file was not found.
            }
        }
    }
}