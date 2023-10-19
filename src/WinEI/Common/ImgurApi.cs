// WinEI
// https://github.com/MuertoGB/WinEI

// ImgurApi.cs
// Released under the GNU GLP v3.0

using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WinEI.Utils;

namespace WinEI.Common
{
    internal class ImgurApi
    {

        #region Internal Members
        internal const string API_KEY = "35e23362c1eb67c";
        #endregion

        internal static string UploadToImgur(string clientId, string imagePath, bool showInBrowser)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Authorization", $"Client-ID {clientId}");

                    if (!ImageUtils.WaitForImageCreation(imagePath))
                        return null;

                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string base64Image = Convert.ToBase64String(imageBytes);

                    NameValueCollection nameValueCollection = new NameValueCollection
                    {
                        { "image", base64Image }
                    };

                    byte[] responseBytes =
                        webClient.UploadValues(
                            "https://api.imgur.com/3/image",
                            nameValueCollection);

                    string responseString =
                        Encoding.ASCII.GetString(
                            responseBytes);

                    Regex regex = new Regex("link\":\"(.*?)\"");
                    Match match = regex.Match(responseString);

                    // Delete the temporary file.
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                    if (match.Success)
                    {
                        return match.Groups[1].Value.Replace(
                            "link\":\"", "").Replace("\"", "").Replace("\\/", "/");
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }
    }
}