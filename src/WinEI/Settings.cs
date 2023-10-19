// WinEI
// https://github.com/MuertoGB/WinEI

// Settings.cs
// Released under the GNU GLP v3.0

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

        private static bool SettingsFileExists()
        {
            return File.Exists(WEIPath.SettingsIni);
        }

        #region Initialize Settings
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
            if (!ini.KeyExists(SECT_APPLICATION, KEY_API_HARDWARE_MODE))
                ini.Write(SECT_APPLICATION, KEY_API_HARDWARE_MODE, "False");

            if (!ini.KeyExists(SECT_APPLICATION, KEY_ACCENT_COLOR))
                ini.Write(SECT_APPLICATION, KEY_ACCENT_COLOR, "0");

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

    }
}