// WinEI
// https://github.com/MuertoGB/WinEI

// ImgurApi.cs
// Released under the GNU GLP v3.0

using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WinEI.Common
{
    internal class ImgurApi
    {

        #region Internal Members
        internal const string API_KEY = "35e23362c1eb67c";
        #endregion

        internal static string UploadBitmapToImgur(string clientId, Bitmap bitmap, bool showInBrowser)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    // Set the API authorization header with the provided client ID.
                    webClient.Headers.Add(
                        "Authorization",
                        $"Client-ID {clientId}");

                    // Convert the Bitmap to a byte array.
                    ImageConverter converter =
                        new ImageConverter();

                    byte[] imageBytes =
                        (byte[])converter.ConvertTo(
                            bitmap,
                            typeof(byte[]));

                    string base64Image =
                        Convert.ToBase64String(
                            imageBytes);

                    // Create a collection of name-value pairs for the HTTP request.
                    NameValueCollection nameValueCollection = new NameValueCollection
                    {
                        { "image", base64Image }
                    };

                    // Upload the image data to Imgur.
                    byte[] responseBytes =
                        webClient.UploadValues(
                            "https://api.imgur.com/3/image",
                            nameValueCollection);

                    // Convert the response bytes to a string.
                    string responseString =
                        Encoding.ASCII.GetString(
                            responseBytes);

                    // Use regular expressions to extract the uploaded image URL from the response.
                    Regex regex =
                        new Regex("link\":\"(.*?)\"");

                    Match match =
                        regex.Match(responseString);

                    if (match.Success)
                    {
                        // Extract and return the URL of the uploaded image.
                        return match.Groups[1].Value.Replace(
                            "link\":\"", "").Replace("\"", "").Replace("\\/", "/");
                    }

                    // Return null if the match was not successful.
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