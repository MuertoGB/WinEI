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
using WinEI.Winsat;

namespace WinEI.WinSAT
{

    #region Structs
    internal struct ApiHardwareTypes
    {
        internal string Processor { get; set; }
        internal string Memory { get; set; }
        internal string Graphics { get; set; }
        internal string D3D { get; set; }
        internal string Disk { get; set; }
    }

    internal struct XmlHardwareTypes
    {
        internal string Processor { get; set; }
        internal string Memory { get; set; }
        internal string MemorySizeBytes { get; set; }
        internal string Graphics { get; set; }
        internal string VramSizeMegabytes { get; set; }
        internal string D3D { get; set; }
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

        internal static readonly string CultureSeperator =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        internal static string FORMAL_XML_PATH = null;

        internal static WinsatAssessmentState AssessmentSate;

        internal static ApiHardwareTypes ApiHardware;
        internal static XmlHardwareTypes XmlHardware;
        internal static WinsatScores ScorePool;

        internal static bool XmlHardwareEnabled = false;
        #endregion

        internal static void LoadWinsatData()
        {
            // Get assessment validity
            AssessmentSate = (WinsatAssessmentState)WinsatAPI.QueryAssessmentState();

            // Get WinSPR
            ScorePool = GetWinSPR();

            // Load the latest winsat formal/inital xml path.
            FORMAL_XML_PATH = GetFormalXmlPath(OSUtils.IsWindowsVista());

            // Load any API generated hardware details.
            ApiHardware = GetWinsatApiHardware();

            // Load any XML generated hardware details.
            XmlHardware = GetWinsatXmlHardware(FORMAL_XML_PATH);
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

        #region WinSPR

        internal static WinsatScores GetWinSPR()
        {
            string baseScore =
                $"{WinsatAPI.QueryBaseScore()}";

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
                BaseScore = $"0{CultureSeperator}0",
                ProcessorScore = Strings.UNRATED,
                MemoryScore = Strings.UNRATED,
                GraphicsScore = Strings.UNRATED,
                D3DScore = Strings.UNRATED,
                DiskScore = Strings.UNRATED
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
        internal static ApiHardwareTypes GetWinsatApiHardware()
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

                // Return new ApiHardwarePool object.
                return new ApiHardwareTypes
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
                return DefaultApiHardware();
            }
        }

        internal static ApiHardwareTypes DefaultApiHardware()
        {
            return new ApiHardwareTypes
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
        internal static XmlHardwareTypes GetWinsatXmlHardware(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Logger.WriteToAppLog(
                    "GetWinsatXmlHardware: Bad filepath argument.");

                XmlHardwareEnabled = false;

                return DefaultXmlHardware();
            }

            // Parse processor model.
            string processor =
                ParseXmlData(
                    "WinSAT/SystemConfig/Processor/Instance", "ProcessorName", filePath);

            // Parse memory size.
            string memory =
                ParseXmlData(
                    "WinSAT/SystemConfig/Memory/DIMM", "MemoryType", filePath);

            // Parse memory size.
            string memorySize =
                ParseXmlData(
                    "WinSAT/SystemConfig/Memory/TotalPhysical", "Bytes", filePath);

            // Parse graphics card model.
            string graphics =
                ParseXmlData(
                    "WinSAT/SystemConfig/Graphics", "AdapterDescription", filePath);

            // Parse VRAM size.
            string vramSizeMb =
                ParseXmlData(
                    "WinSAT/SystemConfig/Graphics", "DedicatedVideoMemory", filePath);

            // Parse disk model.
            string disk =
                ParseXmlData(
                    "WinSAT/SystemConfig/Disk/SystemDisk", "Model", filePath);

            XmlHardwareEnabled = true;

            return new XmlHardwareTypes
            {
                Processor = string.IsNullOrEmpty(processor) ? null : processor,
                Memory = string.IsNullOrEmpty(memory) ? null : memory,
                MemorySizeBytes = string.IsNullOrEmpty(memorySize) ? null : memorySize,
                Graphics = string.IsNullOrEmpty(graphics) ? null : graphics,
                VramSizeMegabytes = string.IsNullOrEmpty(vramSizeMb) ? null : vramSizeMb,
                Disk = string.IsNullOrEmpty(disk) ? null : disk,
            };
        }

        internal static XmlHardwareTypes DefaultXmlHardware()
        {
            return new XmlHardwareTypes
            {
                Processor = null,
                Memory = null,
                MemorySizeBytes = null,
                Graphics = null,
                VramSizeMegabytes = null,
                D3D = null,
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
                    return "The assesssment completed successfully.";
                case WinsatExitCode.ERROR_GENERIC:
                    return "The assessment did not complete due to a generic error.";
                case WinsatExitCode.ERROR_INTERFERENCE:
                    return "The assessment did not complete due to interference.";
                case WinsatExitCode.CANCELLED_BY_USER:
                    return "The assessment was cancelled by the user.";
                case WinsatExitCode.INVALID_COMMAND:
                    return "The command given to WinSAT was invalid.";
                case WinsatExitCode.INVALID_PRIVILAGES:
                    return "WinSAT was not run with administrative privilages.";
                case WinsatExitCode.INSTANCE_ALREADY_RUNNING:
                    return "Another instance of WinSAT is already running.";
                case WinsatExitCode.CANNOT_RUN_INDIVIDUAL_RDS:
                    return "WinSAT cannot run individual assessments on Remote Desktop Server.";
                case WinsatExitCode.BATTERY_POWER:
                    return "WinSAT cannot run on battery power.";
                case WinsatExitCode.CANNOT_RUN_RDS:
                    return "WinSAT cannot run a formal assessment on Remote Desktop Server.";
                case WinsatExitCode.NO_MULTIMEDIA_SUPPORT:
                    return "The assessment cannot run as no multimedia support was detected.";
                case WinsatExitCode.INCOMPATIBLE_OS:
                    return "WinSAT cannot run on Windows XP.";
                case WinsatExitCode.WATCHDOG_TIMEOUT:
                    return "The WinSAT watchdog timer timed out, indicating something is causing the tests to run unuusally slow.";
                case WinsatExitCode.VIRTUAL_MACHINE:
                    return "WinSAT cannot run the formal assessment on a virtual machine.";
                default:
                    return "An unknown WinSAT exit code was returned.";
            }
        }

        internal static string GetAssessmentStateString(int state)
        {
            switch ((WinsatAssessmentState)state)
            {
                case WinsatAssessmentState.UNKNOWN:
                    return "Could not retrieve assessment validity";
                case WinsatAssessmentState.VALID:
                    return "Experience Index scores are valid";
                case WinsatAssessmentState.INCOHERENT:
                    return "Incoherent with hardware";
                case WinsatAssessmentState.UNAVAILABLE:
                    return "Experience Index has not yet been established";
                case WinsatAssessmentState.INVALID:
                    return "Experience Index scores are outdated or invalid";
                default:
                    return "Could not retrieve assessment validity";
            }
        }

        internal static string GetAssessmentStateButtonString(int state)
        {
            switch ((WinsatAssessmentState)state)
            {
                case WinsatAssessmentState.UNKNOWN:
                    return "RUN";
                case WinsatAssessmentState.VALID:
                    return "REPEAT";
                case WinsatAssessmentState.INCOHERENT:
                    return "UPDATE";
                case WinsatAssessmentState.UNAVAILABLE:
                    return "RUN";
                case WinsatAssessmentState.INVALID:
                    return "UPDATE";
                default:
                    return "RUN";
            }
        }

        internal static string GetRatingScaleString()
        {
            string defaultString =
                "The Experience Index assesses key system components";

            if (OSUtils.IsWindowsVista())
                return $"{defaultString} on a scale of 1.0 to 5.9.";

            if (OSUtils.IsWindowsSeven())
                return $"{defaultString} on a scale of 1.0 to 7.9.";

            if (OSUtils.IsWindowsEight())
                return $"{defaultString} on a scale of 1.0 to 9.9.";

            if (OSUtils.IsWindowsTenPlus())
                return $"{defaultString} on a scale of 1.0 to 9.9.";

            return $"{defaultString}.";
        }
        #endregion

    }
}