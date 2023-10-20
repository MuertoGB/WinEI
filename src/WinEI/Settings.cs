// WinEI
// https://github.com/MuertoGB/WinEI

// Settings.cs
// Released under the GNU GLP v3.0

using System;
using System.Drawing;
using System.IO;
using WinEI.Common;

namespace WinEI
{

    #region Enums
    internal enum SettingsBool
    {
        ApiHardwareMode,
        BypassPowerAdapter,
        DisableFlashing,
        DisableSounds,
        DisableVersionCheck,
        LogImgurUrls,
        OpenImgurUrls,
        ShowHardware
    }

    internal enum SettingsString
    {
        ImgurApiKey
    }

    internal enum SettingsInteger
    {
        AccentColor,
        ResumeState
    }
    #endregion

    internal class Settings
    {

        #region Private Members
        private const string SECT_STARTUP = "Startup";
        private const string KEY_DISABLE_VERSION_CHECK = "DisableVersionCheck";
        private const string KEY_RESUME_STATE = "ResumeState";
        private const string KEY_SHOW_HARDWARE = "ShowHardware";

        private const string SECT_APPLICATION = "Application";
        private const string KEY_ACCENT_COLOR = "AccentColour";
        private const string KEY_API_HARDWARE_MODE = "ApiHardwareMode";
        private const string KEY_DISABLE_FLASHING = "DisableFlashing";
        private const string KEY_DISABLE_SOUNDS = "DisableSounds";
        private const string KEY_IMGUR_API_KEY = "ImgurApiKey";
        private const string KEY_LOG_IMGUR_URLS = "LogImgurUrls";
        private const string KEY_OPEN_IMGUR_URLS = "OpenImgurUrls";

        private const string SECT_OVERRIDES = "Overrides";
        private const string KEY_BYPASS_POWER_ADAPTER = "BypassPowerAdapter";
        #endregion

        #region Initialize
        internal static void Initialize()
        {
            IniFile ini = new IniFile(WEIPath.SettingsIni);

            // Write sections if they don't exist.
            WriteSections(ini);

            // Write startup keys.
            WriteStartupKeys(ini);

            // Write application keys.
            WriteApplicationKeys(ini);

            // Write overrides keys.
            WriteOverridesKeys(ini);
        }

        internal static void Reset()
        {
            WriteBool(SettingsBool.DisableVersionCheck, false);
            WriteBool(SettingsBool.ShowHardware, false);
            WriteInteger(SettingsInteger.AccentColor, 0);
            WriteBool(SettingsBool.ApiHardwareMode, false);
            WriteString(SettingsString.ImgurApiKey, string.Empty);
            WriteBool(SettingsBool.DisableFlashing, false);
            WriteBool(SettingsBool.DisableSounds, false);
            WriteBool(SettingsBool.LogImgurUrls, true);
            WriteBool(SettingsBool.OpenImgurUrls, true);
            WriteBool(SettingsBool.BypassPowerAdapter, false);
        }
        #endregion

        #region Write Sections
        private static void WriteSections(IniFile ini)
        {
            if (!ini.SectionExists(SECT_STARTUP))
                ini.WriteSection(SECT_STARTUP);

            if (!ini.SectionExists(SECT_APPLICATION))
                ini.WriteSection(SECT_APPLICATION);

            if (!ini.SectionExists(SECT_OVERRIDES))
                ini.WriteSection(SECT_OVERRIDES);
        }
        #endregion

        #region Write Keys
        private static void WriteStartupKeys(IniFile ini)
        {
            if (!ini.KeyExists(SECT_STARTUP, KEY_DISABLE_VERSION_CHECK))
                ini.Write(SECT_STARTUP, KEY_DISABLE_VERSION_CHECK, "False");

            if (!ini.KeyExists(SECT_STARTUP, KEY_RESUME_STATE))
                ini.Write(SECT_STARTUP, KEY_RESUME_STATE, "0");

            if (!ini.KeyExists(SECT_STARTUP, KEY_SHOW_HARDWARE))
                ini.Write(SECT_STARTUP, KEY_SHOW_HARDWARE, "False");
        }

        private static void WriteApplicationKeys(IniFile ini)
        {
            if (!ini.KeyExists(SECT_APPLICATION, KEY_ACCENT_COLOR))
                ini.Write(SECT_APPLICATION, KEY_ACCENT_COLOR, "0");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_API_HARDWARE_MODE))
                ini.Write(SECT_APPLICATION, KEY_API_HARDWARE_MODE, "False");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_DISABLE_FLASHING))
                ini.Write(SECT_APPLICATION, KEY_DISABLE_FLASHING, "False");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_DISABLE_SOUNDS))
                ini.Write(SECT_APPLICATION, KEY_DISABLE_SOUNDS, "False");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_IMGUR_API_KEY))
                ini.Write(SECT_APPLICATION, KEY_IMGUR_API_KEY, string.Empty);

            if (!ini.KeyExists(SECT_APPLICATION, KEY_LOG_IMGUR_URLS))
                ini.Write(SECT_APPLICATION, KEY_LOG_IMGUR_URLS, "True");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_OPEN_IMGUR_URLS))
                ini.Write(SECT_APPLICATION, KEY_OPEN_IMGUR_URLS, "True");
        }

        private static void WriteOverridesKeys(IniFile ini)
        {
            if (!ini.KeyExists(SECT_OVERRIDES, KEY_BYPASS_POWER_ADAPTER))
                ini.Write(SECT_OVERRIDES, KEY_BYPASS_POWER_ADAPTER, "False");
        }
        #endregion

        #region Read Values
        internal static bool ReadBool(SettingsBool settingsBool)
        {
            if (!SettingsFileExists())
                return false;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsBool)
            {
                case SettingsBool.ApiHardwareMode:
                    section = SECT_APPLICATION; key = KEY_API_HARDWARE_MODE;
                    break;
                case SettingsBool.BypassPowerAdapter:
                    section = SECT_OVERRIDES; key = KEY_BYPASS_POWER_ADAPTER;
                    break;
                case SettingsBool.DisableFlashing:
                    section = SECT_APPLICATION; key = KEY_DISABLE_FLASHING;
                    break;
                case SettingsBool.DisableSounds:
                    section = SECT_APPLICATION; key = KEY_DISABLE_SOUNDS;
                    break;
                case SettingsBool.DisableVersionCheck:
                    section = SECT_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBool.LogImgurUrls:
                    section = SECT_APPLICATION; key = KEY_LOG_IMGUR_URLS;
                    break;
                case SettingsBool.OpenImgurUrls:
                    section = SECT_APPLICATION; key = KEY_OPEN_IMGUR_URLS;
                    break;
                case SettingsBool.ShowHardware:
                    section = SECT_STARTUP; key = KEY_SHOW_HARDWARE;
                    break;
                default:
                    return false;
            }

            if (!ini.SectionExists(section))
                return false;

            if (!ini.KeyExists(section, key))
                return false;

            return bool.Parse(ini.Read(section, key));
        }

        internal static string ReadString(SettingsString settingsString)
        {
            if (!SettingsFileExists())
                return string.Empty;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsString)
            {
                case SettingsString.ImgurApiKey:
                    section = SECT_APPLICATION; key = KEY_IMGUR_API_KEY;
                    break;
                default:
                    return string.Empty;
            }

            if (!ini.SectionExists(section))
                return string.Empty;

            if (!ini.KeyExists(section, key))
                return string.Empty;

            return ini.Read(section, key);
        }

        internal static int ReadInteger(SettingsInteger settingsInteger)
        {
            if (!SettingsFileExists())
                return 0;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsInteger)
            {
                case SettingsInteger.AccentColor:
                    section = SECT_APPLICATION; key = KEY_ACCENT_COLOR;
                    break;
                case SettingsInteger.ResumeState:
                    section = SECT_STARTUP; key = KEY_RESUME_STATE;
                    break;
                default:
                    return 0;
            }

            if (!ini.SectionExists(section))
                return 0;

            if (!ini.KeyExists(section, key))
                return 0;

            int value;

            if (int.TryParse(ini.Read(section, key), out value))
                return value;

            Logger.WriteToLog(
                $"Failed to parse INI value {key} as integer value.",
                LogType.ApplicationLog);

            return 0;
        }
        #endregion

        #region Write Values
        internal static void WriteBool(SettingsBool settingsBool, bool value)
        {
            if (!SettingsFileExists())
                return;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsBool)
            {
                case SettingsBool.ApiHardwareMode:
                    section = SECT_APPLICATION; key = KEY_API_HARDWARE_MODE;
                    break;
                case SettingsBool.BypassPowerAdapter:
                    section = SECT_OVERRIDES; key = KEY_BYPASS_POWER_ADAPTER;
                    break;
                case SettingsBool.DisableFlashing:
                    section = SECT_APPLICATION; key = KEY_DISABLE_FLASHING;
                    break;
                case SettingsBool.DisableSounds:
                    section = SECT_APPLICATION; key = KEY_DISABLE_SOUNDS;
                    break;
                case SettingsBool.DisableVersionCheck:
                    section = SECT_STARTUP; key = KEY_DISABLE_VERSION_CHECK;
                    break;
                case SettingsBool.LogImgurUrls:
                    section = SECT_APPLICATION; key = KEY_LOG_IMGUR_URLS;
                    break;
                case SettingsBool.OpenImgurUrls:
                    section = SECT_APPLICATION; key = KEY_OPEN_IMGUR_URLS;
                    break;
                case SettingsBool.ShowHardware:
                    section = SECT_STARTUP; key = KEY_SHOW_HARDWARE;
                    break;
                default:
                    return;
            }

            if (!ini.SectionExists(section))
                ini.WriteSection(section);

            ini.Write(section, key, $"{value}");
        }

        internal static void WriteString(SettingsString settingsString, string value)
        {
            if (!SettingsFileExists())
                return;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsString)
            {
                case SettingsString.ImgurApiKey:
                    section = SECT_APPLICATION; key = KEY_IMGUR_API_KEY;
                    break;
                default:
                    return; ;
            }

            if (!ini.SectionExists(section))
                ini.WriteSection(section);

            ini.Write(section, key, $"{value}");
        }

        internal static void WriteInteger(SettingsInteger settingsInteger, int value)
        {
            if (!SettingsFileExists())
                return;

            IniFile ini =
                new IniFile(
                    WEIPath.SettingsIni);

            string section, key;

            switch (settingsInteger)
            {
                case SettingsInteger.AccentColor:
                    section = SECT_APPLICATION; key = KEY_ACCENT_COLOR;
                    break;
                case SettingsInteger.ResumeState:
                    section = SECT_STARTUP; key = KEY_RESUME_STATE;
                    break;
                default:
                    return;
            }

            if (!ini.SectionExists(section))
                ini.WriteSection(section);

            ini.Write(section, key, $"{value}");
        }
        #endregion

        #region Bools
        private static bool SettingsFileExists()
        {
            return File.Exists(WEIPath.SettingsIni);
        }

        internal static bool Delete()
        {
            try
            {
                File.Delete(
                    WEIPath.SettingsIni);

                return SettingsFileExists();
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);

                return false;
            }
        }
        #endregion

        #region Colours
        internal static Color GetAccentColour(int value)
        {
            switch (value)
            {
                case 0: return AppColours.ACCENT_0_DEFAULT;
                case 1: return AppColours.ACCENT_1_MINT;
                case 2: return AppColours.ACCENT_2_GREEN;
                case 3: return AppColours.ACCENT_3_PINK;
                case 4: return AppColours.ACCENT_4_GOLD;
                case 5: return AppColours.ACCENT_5_RED;
                case 6: return AppColours.ACCENT_6_ORANGE;
                default: return AppColours.ACCENT_0_DEFAULT;
            }
        }
        #endregion

    }
}