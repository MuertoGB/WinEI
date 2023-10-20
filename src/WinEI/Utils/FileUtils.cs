// WinEI
// https://github.com/MuertoGB/WinEI

// FileUtils.cs
// Released under the GNU GLP v3.0

using System;
using System.IO;

namespace WinEI.Utils
{
    internal class FileUtils
    {
        internal static string GetBytesReadableSize(long size)
        {
            // Define a set of suffixes for file sizes.
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };

            if (size == 0)
                return $"{size:N2} {suffixes[0]}";

            // Calculate the appropriate suffix based on size of the file.
            int suffixIndex = (int)(Math.Log(size) / Math.Log(1024));

            // Calculate the size in the chosen suffix and format it.
            double sizeInSuffix = size / Math.Pow(1024, suffixIndex);

            // Return the formatted string.
            return $"{sizeInSuffix:N2} {suffixes[suffixIndex]}";
        }

        public static string ConvertBytesToMB(long bytes) =>
            $"{Math.Ceiling((double)bytes / (1024 * 1024))} MB";


        internal static void RemoveFilesbyExtension(string extension, string path)
        {
            string[] files =
                Directory.GetFileSystemEntries(
                    path,
                    extension);

            foreach (string file in files)
            {
                File.Delete(
                    Path.Combine(
                        path,
                        Path.GetFileName(file)));
            }
        }
    }
}