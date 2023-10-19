﻿// WinEI
// https://github.com/MuertoGB/WinEI

// IniFile.cs
// Released under the GNU GLP v3.0
// IniFile uses code from pinvoke.net, thank you to whoever wrote it (See GetSectionNames)

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using WinEI.WIN32;

namespace WinEI.Common
{
    internal class IniFile
    {
        private readonly string _strFilePath;
        private const int MAX_BUFFER = 32767;

        internal IniFile(string filePath) =>
            this._strFilePath = filePath;

        internal void Write(string section, string key, string value) =>
            NativeMethods.WritePrivateProfileString(
                section,
                key,
                value,
                _strFilePath);

        internal void WriteSection(string section)
        {
            using (StreamWriter writer = new StreamWriter(_strFilePath, true))
                writer.WriteLine($"[{section}]");
        }

        internal string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder builder = new StringBuilder(255);

            NativeMethods.GetPrivateProfileString(
                section,
                key,
                defaultValue,
                builder,
                255,
                _strFilePath);

            return builder.ToString();
        }

        internal void DeleteSection(string section) =>
            Write(section, null, null);

        internal void DeleteKey(string section, string key) =>
            Write(section, key, null);

        internal bool SectionExists(string section)
        {
            string[] sectionNames = GetSectionNames(_strFilePath);

            if (sectionNames != null)
                foreach (string s in sectionNames)
                    if (s == section)
                        return true;

            return false;
        }

        internal bool KeyExists(string section, string key)
        {
            string[] keyNames =
                GetSectionKeys(
                    section,
                    _strFilePath);

            if (keyNames == null)
                return false;

            foreach (string s in keyNames)
                if (s == key)
                    return true;

            return false;
        }

        // GetSectionNames code found on pinvoke.
        // GetSectionKeys I adapted from GetSectionNames using GetPrivateProfileSection.
        // https://www.pinvoke.net/default.aspx/kernel32/GetPrivateProfileSectionNames.html
        internal static string[] GetSectionNames(string lpFileName)
        {
            IntPtr lpszReturnBuffer = IntPtr.Zero;

            try
            {
                lpszReturnBuffer =
                    Marshal.AllocCoTaskMem(
                        MAX_BUFFER);

                uint data =
                    NativeMethods.GetPrivateProfileSectionNames(
                        lpszReturnBuffer,
                        MAX_BUFFER,
                        lpFileName);

                if (data == 0)
                    return null;

                string ansiString =
                    Marshal.PtrToStringAnsi(
                        lpszReturnBuffer,
                        (int)data).ToString();

                return ansiString.Substring(0, ansiString.Length - 1).Split('\0');
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
            finally
            {
                if (lpszReturnBuffer != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(lpszReturnBuffer);
            }
        }

        internal static string[] GetSectionKeys(string lpAppName, string lpFileName)
        {
            IntPtr lpReturnedString = IntPtr.Zero;

            try
            {
                lpReturnedString =
                    Marshal.AllocCoTaskMem(
                        MAX_BUFFER);

                uint data =
                    NativeMethods.GetPrivateProfileSection(
                        lpAppName,
                        lpReturnedString,
                        MAX_BUFFER,
                        lpFileName);

                if (data == 0)
                    return null;

                string ansiString =
                    Marshal.PtrToStringAnsi(
                        lpReturnedString,
                        (int)data).ToString();

                string[] keys =
                    ansiString.Substring(
                        0, ansiString.Length - 1).Split('\0');

                for (int i = 0; i < keys.Length; i++)
                {
                    int separatorIndex = keys[i].IndexOf('=');

                    if (separatorIndex != -1)
                        keys[i] = keys[i].Substring(0, separatorIndex);
                }

                return keys;
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
            finally
            {
                if (lpReturnedString != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(lpReturnedString);
            }
        }
    }
}