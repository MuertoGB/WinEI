// WinEI
// https://github.com/MuertoGB/WinEI

// WinsatReader.cs
// Released under the GNU GLP v3.0

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using WinEI.Common;
using WinEI.Utils;

namespace WinEI.Winsat
{

    #region Structs
    internal struct ApiHardwareStrings
    {
        internal string Processor { get; set; }
        internal string Memory { get; set; }
        internal string Graphics { get; set; }
        internal string D3D { get; set; }
        internal string Disk { get; set; }
    }

    internal struct XmlHardwareStrings
    {
        internal string Processor { get; set; }
        internal string Memory { get; set; }
        internal long MemorySizeBytes { get; set; }
        internal string Graphics { get; set; }
        internal long VramSizeMegabytes { get; set; }
        internal string Disk { get; set; }
    }

    internal struct WinsatScores
    {
        internal string BaseScore { get; set; }
        internal string ProcessorScore { get; set; }
        internal string MemoryScore { get; set; }
        internal string GraphicsScore { get; set; }
        internal string D3DScore { get; set; }
        internal string DiskScore { get; set; }

    }
    #endregion

    #region Enums
    internal enum WinsatExitCode
    {
        SUCCESS,
        ERROR_GENERIC,
        ERROR_INTERFERENCE,
        CANCELLED_BY_USER,
        INVALID_COMMAND,
        INVALID_PRIVILAGES,
        INSTANCE_ALREADY_RUNNING,
        CANNOT_RUN_INDIVIDUAL_RDS,
        BATTERY_POWER,
        CANNOT_RUN_RDS,
        NO_MULTIMEDIA_SUPPORT,
        INCOMPATIBLE_OS,
        WATCHDOG_TIMEOUT,
        VIRTUAL_MACHINE
    }

    internal enum WinsatAssessmentState
    {
        UNKNOWN,
        VALID,
        INCOHERENT,
        UNAVAILABLE,
        INVALID
    }
    #endregion

    internal class WinsatReader
    {

        #region Internal Members
        internal static readonly string WinsatFilesPath =
            Path.Combine(OSUtils.WindowsPath, "Performance\\WinSAT");

        internal static readonly string WinsatDataStorePath =
            Path.Combine(WinsatFilesPath, "DataStore");

        internal static readonly string WinsatLog =
            Path.Combine(WinsatFilesPath, "winsat.log");

        internal static readonly string CultureSeperator =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        internal static string FORMAL_XML_PATH = null;

        internal static WinsatAssessmentState ASSESSMENT_STATE;

        internal static ApiHardwareStrings API_HARDWARE;
        internal static XmlHardwareStrings XML_HARDWARE;
        internal static WinsatScores WINSPR;

        internal static bool ApiHardwareEnabled = false;
        internal static bool XmlHardwareEnabled = false;
        #endregion

        #region Load WinSAT data
        internal static void LoadWinsatData()
        {
            // Get assessment validity
            ASSESSMENT_STATE = (WinsatAssessmentState)WinsatAPI.QueryAssessmentState();

            // Get WinSPR
            WINSPR = GetWinSPR();

            // Load the latest winsat formal/inital xml path.
            FORMAL_XML_PATH = GetFormalXmlPath(OSUtils.IsWindowsVista());

            // Load any API generated hardware details.
            API_HARDWARE = GetWinsatApiHardware();

            // Load any XML generated hardware details.
            XML_HARDWARE = GetWinsatXmlHardware(FORMAL_XML_PATH);
        }

        internal static string GetFormalXmlPath(bool isWindowsVista)
        {
            DirectoryInfo dataStore = new DirectoryInfo(WinsatDataStorePath);

            // Determine the search pattern, Vista uses a different naming structure.
            string searchPattern =
                isWindowsVista
                ? "*Initial*.xml"
                : "*Formal*.xml";

            // Get the latest score file.
            FileInfo latestFormal =
                dataStore.EnumerateFiles(
                    searchPattern,
                    SearchOption.TopDirectoryOnly).OrderByDescending(
                    f => f.LastWriteTime).FirstOrDefault();

            // Use the null-conditional operator to safely return the file's FullName.
            return latestFormal?.FullName;
        }

        internal static string ParseXmlData(string nodeName, string innerNodeName, string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode node;

                xmlDoc.Load(filePath);

                node = xmlDoc.SelectSingleNode(nodeName);

                if (node != null)
                {
                    XmlNode innerNode =
                        node.SelectSingleNode(
                            innerNodeName);

                    return innerNode != null
                        ? innerNode.InnerText
                        : null;
                }

                return null;
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return null;
            }
        }
        #endregion

        #region WinSPR
        internal static WinsatScores GetWinSPR()
        {
            // Get the WInSPR base score.
            string baseScore =
                $"{WinsatAPI.QueryBaseScore()}";

            // System is not rated.
            if (baseScore == "0")
                return DefaultWinSatScores();

            string processorScore =
                WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_CPU,
                    INFO_TYPE.Score);

            string memoryScore =
                WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_MEMORY,
                    INFO_TYPE.Score);

            string graphicsScore =
                WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_GRAPHICS,
                    INFO_TYPE.Score);

            string d3dScore =
                WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_D3D,
                    INFO_TYPE.Score);

            string diskScore =
                WinsatAPI.QueryApiInfo
                (WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_DISK,
                INFO_TYPE.Score);

            return new WinsatScores
            {
                BaseScore = string.IsNullOrEmpty(baseScore) ? null : GetFormattedScore(baseScore),
                ProcessorScore = string.IsNullOrEmpty(processorScore) ? null : GetFormattedScore(processorScore),
                MemoryScore = string.IsNullOrEmpty(memoryScore) ? null : GetFormattedScore(memoryScore),
                GraphicsScore = string.IsNullOrEmpty(graphicsScore) ? null : GetFormattedScore(graphicsScore),
                D3DScore = string.IsNullOrEmpty(d3dScore) ? null : GetFormattedScore(d3dScore),
                DiskScore = string.IsNullOrEmpty(diskScore) ? null : GetFormattedScore(diskScore)
            };
        }

        internal static WinsatScores DefaultWinSatScores()
        {
            return new WinsatScores
            {
                BaseScore = AppStrings.NA,
                ProcessorScore = AppStrings.UNRATED,
                MemoryScore = AppStrings.UNRATED,
                GraphicsScore = AppStrings.UNRATED,
                D3DScore = AppStrings.UNRATED,
                DiskScore = AppStrings.UNRATED
            };
        }

        internal static string GetFormattedScore(string score)
        {
            if (score.Length == 1)
            {
                return $"{score}{CultureSeperator}0";
            }
            else if (score.Length > 3)
            {
                return score.Substring(0, score.Length - 1);
            }

            return score;
        }
        #endregion

        #region API Hardware
        internal static ApiHardwareStrings GetWinsatApiHardware()
        {
            try
            {
                // Get the processor string.
                string processor = WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_CPU,
                    INFO_TYPE.Description);

                // Get the memory string.
                string memory = WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_MEMORY,
                    INFO_TYPE.Description);

                // Get the graphics string.
                string graphics = WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_GRAPHICS,
                    INFO_TYPE.Description);

                // Get the D3D string.
                string d3d = WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_D3D,
                    INFO_TYPE.Description);

                // Get the primary disk string.
                string disk = WinsatAPI.QueryApiInfo(
                    WINSATLib.WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_DISK,
                    INFO_TYPE.Description);

                ApiHardwareEnabled = true;

                // Return new ApiHardwarePool object.
                return new ApiHardwareStrings
                {
                    Processor = string.IsNullOrEmpty(processor) ? null : processor,
                    Memory = string.IsNullOrEmpty(memory) ? null : memory,
                    Graphics = string.IsNullOrEmpty(graphics) ? null : graphics,
                    D3D = string.IsNullOrEmpty(d3d) ? null : d3d,
                    Disk = string.IsNullOrEmpty(disk) ? null : disk
                };
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                ApiHardwareEnabled = false;
                return DefaultApiHardware();
            }
        }

        internal static ApiHardwareStrings DefaultApiHardware()
        {
            return new ApiHardwareStrings
            {
                Processor = null,
                Memory = null,
                Graphics = null,
                D3D = null,
                Disk = null
            };
        }
        #endregion

        #region XML Hardware
        internal static XmlHardwareStrings GetWinsatXmlHardware(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                XmlHardwareEnabled = false;
                return DefaultXmlHardware();
            }

            // Parse processor model.
            string processor =
                ParseXmlData(
                    "WinSAT/SystemConfig/Processor/Instance",
                    "ProcessorName",
                    filePath);

            // Parse memory size.
            string memory =
                ParseXmlData(
                    "WinSAT/SystemConfig/Memory/DIMM",
                    "MemoryType",
                    filePath);

            // Parse memory size.
            string memorySizeString =
                ParseXmlData(
                    "WinSAT/SystemConfig/Memory/TotalPhysical",
                    "Bytes",
                    filePath);

            long memorySize;

            if (!long.TryParse(memorySizeString, out memorySize))
                memorySize = 0;

            // Parse graphics card model.
            string graphics =
                ParseXmlData(
                    "WinSAT/SystemConfig/Graphics",
                    "AdapterDescription",
                    filePath);

            // Parse VRAM size.
            string vramSizeMegaBytes =
                ParseXmlData(
                    "WinSAT/SystemConfig/Graphics",
                    "DedicatedVideoMemory",
                    filePath);

            long vramSize;

            if (!long.TryParse(vramSizeMegaBytes, out vramSize))
                vramSize = 0;

            // Parse disk model.
            string disk =
                ParseXmlData(
                    "WinSAT/SystemConfig/Disk/SystemDisk",
                    "Model",
                    filePath);

            XmlHardwareEnabled = true;

            return new XmlHardwareStrings
            {
                Processor = string.IsNullOrEmpty(processor) ? null : processor,
                Memory = string.IsNullOrEmpty(memory) ? null : memory,
                MemorySizeBytes = memorySize,
                Graphics = string.IsNullOrEmpty(graphics) ? null : graphics,
                VramSizeMegabytes = vramSize,
                Disk = string.IsNullOrEmpty(disk) ? null : disk,
            };
        }

        internal static XmlHardwareStrings DefaultXmlHardware()
        {
            return new XmlHardwareStrings
            {
                Processor = null,
                Memory = null,
                MemorySizeBytes = 0,
                Graphics = null,
                VramSizeMegabytes = 0,
                Disk = null
            };
        }
        #endregion

        #region Strings
        internal static string GetWinsatExitCodeString(int code)
        {
            switch ((WinsatExitCode)code)
            {
                case WinsatExitCode.SUCCESS:
                    return WinsatStrings.WINSAT_EXIT_SUCCESS;
                case WinsatExitCode.ERROR_GENERIC:
                    return WinsatStrings.WINSAT_EXIT_ERROR_GENERIC;
                case WinsatExitCode.ERROR_INTERFERENCE:
                    return WinsatStrings.WINSAT_EXIT_INTERFERENCE;
                case WinsatExitCode.CANCELLED_BY_USER:
                    return WinsatStrings.WINSAT_EXIT_CANCELLED_BY_USER;
                case WinsatExitCode.INVALID_COMMAND:
                    return WinsatStrings.WINSAT_EXIT_INVALID_COMMAND;
                case WinsatExitCode.INVALID_PRIVILAGES:
                    return WinsatStrings.WINSAT_EXIT_INVALID_PRIVILAGES;
                case WinsatExitCode.INSTANCE_ALREADY_RUNNING:
                    return WinsatStrings.WINSAT_EXIT_INSTANCE_ALREADY_RUNNING;
                case WinsatExitCode.CANNOT_RUN_INDIVIDUAL_RDS:
                    return WinsatStrings.WINSAT_EXIT_CANNOT_RUN_INDIVIDUAL_RDS;
                case WinsatExitCode.BATTERY_POWER:
                    return WinsatStrings.WINSAT_EXIT_BATTERY_POWER;
                case WinsatExitCode.CANNOT_RUN_RDS:
                    return WinsatStrings.WINSAT_EXIT_CANNOT_RUN_RDS;
                case WinsatExitCode.NO_MULTIMEDIA_SUPPORT:
                    return WinsatStrings.WINSAT_EXIT_NO_MULTIMEDIA_SUPPORT;
                case WinsatExitCode.INCOMPATIBLE_OS:
                    return WinsatStrings.WINSAT_EXIT_INCOMPATIBLE_OS;
                case WinsatExitCode.WATCHDOG_TIMEOUT:
                    return WinsatStrings.WINSAT_EXIT_WATCHDOG_TIMEOUT;
                case WinsatExitCode.VIRTUAL_MACHINE:
                    return WinsatStrings.WINSAT_EXIT_VM;
                default:
                    return WinsatStrings.WINSAT_EXIT_UNKNOWN;
            }
        }

        internal static string GetAssessmentStateString(int state)
        {
            switch ((WinsatAssessmentState)state)
            {
                case WinsatAssessmentState.UNKNOWN:
                    return WinsatStrings.WINSAT_STATE_UNKNOWN;
                case WinsatAssessmentState.VALID:
                    return WinsatStrings.WINSAT_STATE_VALID;
                case WinsatAssessmentState.INCOHERENT:
                    return WinsatStrings.WINSAT_STATE_INCOHERENT;
                case WinsatAssessmentState.UNAVAILABLE:
                    return WinsatStrings.WINSAT_STATE_UNAVAILABLE;
                case WinsatAssessmentState.INVALID:
                    return WinsatStrings.WINSAT_STATE_INVALID;
                default:
                    return WinsatStrings.WINSAT_STATE_UNKNOWN;
            }
        }

        internal static string GetAssessmentStateButtonString(int state)
        {
            switch ((WinsatAssessmentState)state)
            {
                case WinsatAssessmentState.UNKNOWN:
                    return WinsatStrings.RUN;
                case WinsatAssessmentState.VALID:
                    return WinsatStrings.REPEAT;
                case WinsatAssessmentState.INCOHERENT:
                    return WinsatStrings.UPDATE;
                case WinsatAssessmentState.UNAVAILABLE:
                    return WinsatStrings.RUN;
                case WinsatAssessmentState.INVALID:
                    return WinsatStrings.UPDATE;
                default:
                    return WinsatStrings.RUN;
            }
        }

        internal static string GetRatingScaleString()
        {
            string defaultString =
                WinsatStrings.KEY_COMPONENTS;

            if (OSUtils.IsWindowsVista())
                return $"{defaultString} {WinsatStrings.SCALE_OF_59}";

            if (OSUtils.IsWindowsSeven())
                return $"{defaultString} {WinsatStrings.SCALE_OF_79}";

            if (OSUtils.IsWindowsEight() || OSUtils.IsWindowsTenPlus())
                return $"{defaultString} {WinsatStrings.SCALE_OF_99}";

            return $"{defaultString}.";
        }
        #endregion

        #region Integers
        internal static int GetWinsatExitCodeFromLog()
        {
            try
            {
                string[] list = File.ReadAllLines(WinsatLog);
                string code = list.Last();

                if (code.Contains("exit value ="))
                    return Convert.ToInt32(code.Substring(code.Length - 2, 1));

                return -1;
            }
            catch (Exception e)
            {
                Logger.WriteExceptionToAppLog(e);
                return -1;
            }
        }
        #endregion

    }
}