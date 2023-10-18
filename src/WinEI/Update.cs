﻿// WinEI
// https://github.com/MuertoGB/WinEI

// Update.cs - Provides a simple version check
// Released under the GNU GLP v3.0

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WinEI.Common;

namespace WinEI
{

    #region Enums
    public enum VersionResult
    {
        UpToDate,
        NewVersionAvailable,
        Error
    }
    #endregion

    class Update
    {
        internal static async Task<VersionResult> CheckForNewVersion(string versionUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response =
                        await client.DownloadDataTaskAsync(
                            versionUrl);

                    using (MemoryStream stream = new MemoryStream(response))
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        XmlDocument doc = new XmlDocument();

                        doc.Load(reader);

                        XmlNode node =
                            doc.SelectSingleNode(
                                "data/WEI/VersionString");

                        if (node == null)
                            return VersionResult.Error;

                        Version remoteVersion =
                            new Version(
                                node.InnerText);

                        Version localVersion =
                            new Version(
                                Application.ProductVersion);

                        return remoteVersion > localVersion
                            ? VersionResult.NewVersionAvailable
                            : VersionResult.UpToDate;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return VersionResult.Error;
            }
        }
    }
}