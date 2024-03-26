// WinEI
// https://github.com/MuertoGB/WinEI

// Strings.cs
// Released under the GNU GLP v3.0

using System.Data;
using System.Drawing;
using System.Runtime.Serialization.Formatters;

namespace WinEI
{
    internal class ExceptionStrings
    {
        #region Strings
        internal const string EX_WINSAT_EXE_NF =
            "The WinSAT executable could not be found.";

        internal const string EX_WINSAT_API_NF =
            "The WinSAT API Dynamic Link Library could not be found.";

        internal const string EX_WINSAT_INCOMPATIBLE_OS =
            "Incompatible Operating System.";

        internal const string EX_POWER_ADAPTER =
            "Please connect a power adapter to continue, the assessment cannot run on battery power.";

        internal const string EX_IMGUR_CONNECTION =
            "A connection to Imgur could not be established.";

        internal const string EX_IMGUR_NO_URL_RESPONSE =
            "Imgur did not return a reposnse URL. The upload was unsuccessful.";

        internal const string EX_FILE_EXPORT_NF =
            "File export unsuccessful. The exported file was not found.";

        internal const string EX_FONTS_NF =
            "The following required system fonts are missing, and must be installed to continue:";

        internal const string EX_INVALID_LOG_TYPE =
            "Invalid log type.";

        internal const string EX_ELEVATED_RESTART =
            "Could not perform elevated restart.";

        internal const string EX_XML_DISABLED_BY_WSR =
            "Reading of XML hardware information has been disabled by the WinsatReader.";

        internal const string EX_API_DISABLED_BY_WSR =
            "Reading of API hardware information has been disabled by the WinsatReader.";

        internal const string EXCEPTION_HANDLER =
            "Exception Handler";

        internal const string EXCEPTION_OCCURED =
            "An exception occured.";
        #endregion
    }

    internal class AppStrings
    {
        #region Strings
        internal const string UNKNOWN =
            "Unknown";

        internal const string CLOSE =
            "Close";

        internal const string NA =
            "N/A";

        internal const string YES =
            "Yes";

        internal const string NO =
            "No";

        internal const string ADMIN =
            "Administrator";

        internal const string ERROR =
            "Error";

        internal const string WARNING =
            "Warning";

        internal const string INFORMATION =
            "Information";

        internal const string SECURITY =
            "Security";

        internal const string UNRATED =
            "Unrated";

        internal const string BUILD =
            "Build";

        internal const string NEVER =
            "Never";

        internal const string ASSESSMENT =
            "Assessment";

        internal const string VRAM =
            "VRAM";

        internal const string FEATURES_DISABLED =
            "Some features have been disabled";

        internal const string SEGOE_MDL2_FAILED_TO_LOAD =
            "Segoe MDL2 Assets font data failed to load.";

        internal const string FEATURE_REQUIRES_ELEVATION =
            "This feature requires elevated privilages, would you like to restart as administrator?";

        internal const string APPLICATION_WILL_EXIT =
            "Application will now exit.";

        internal const string APPLICATION_FORCE_QUIT =
            "Force quit application?";

        internal const string LOG_NOT_FOUND =
            "The log file was not found. It may not have been created yet.";

        internal const string EXITED_WITH_CODE =
            "Forced exit with code";

        internal const string SYSTEM_MUST_BE_RATED =
            "The system must be rated to use this feature.";

        internal const string DETAILS_SAVED_TO_LOG =
            "Details were saved to the application log.";

        internal const string DETAILS_SAVED_TO =
            "Details saved to:";

        internal const string IMGUR_LOG_NOT_FOUND =
            "The Imgur links file was not found.";

        internal const string IMGUR_UPLOAD_CONFIRM =
            "This will capture an image of the application, and upload it to Imgur. Are you sure you want to continue?";

        internal const string IMGUR_UPLOAD_COMPLETE =
            "Image uploaded to Imgur:";
        #endregion
    }

    internal class DialogStrings
    {
        #region Strings
        internal const string Q_RATE_SYSTEM =
            "Would you like to perform the initial assessment?";

        internal const string Q_EXPORT_NAVIGATE =
            "Export successful. Navigate to file in explorer?";

        internal const string Q_COPY_URL_TO_CLIPBOARD =
            "Copy URL text to clipboard?";

        internal const string Q_RESET_SETTINGS =
            "This will revert all settings to default, are you sure you want to reset settings?";

        internal const string Q_RESET_WINSAT =
            "This will permanently delete all system scores, and the assessment log. Are you sure you want to reset WinSAT?";

        internal const string Q_VIEW_TROUBLESHOOTING =
            "Would you like to view the online troubleshooting information?";

        internal const string Q_CANCEL_ASSESSMENT =
            "The assessment is running, are you sure you want to cancel?";
        #endregion
    }

    internal class AssessmentStrings
    {
        #region Strings
        internal const string A_ALREADY_COMPLETED =
            "Could not cancel the assessment as it has already completed.";

        internal const string A_CANCELLED_BY_USER =
            "Assessment cancelled by the user";

        internal const string A_COMPLETED =
            "Assessment completed.";

        internal const string A_DID_NOT_COMPLETE =
            "The assessment did not complete";

        internal const string A_WD =
            "Watchdog";

        internal const string A_WINSAT_KILLED_OR_QUIT =
            "WinSAT was killed, or unexpectedly quit.";

        internal const string A_WD_SHUTDOWN_START =
            "Shutting down Watchdog...";

        internal const string A_WD_SHUTDOWN_FAIL =
            "Could not stop the Watchdog";

        internal const string A_WD_SHUTDOWN_SUCCESS =
            "Watchdog shutdown successful";

        internal const string A_WS_SHUTDOWN_START =
            "Shutting down the WinSAT process...";

        internal const string A_WS_EXIT_WAIT =
            "Waiting for WinSAT to exit...";

        internal const string A_WS_SHUTDOWN_FAIL =
            "Could not stop the running WinSAT process";

        internal const string A_WS_SHUTDOWN_SUCCESS =
            "WinSAT shutdown successful";

        internal const string A_RAN_WITH_COUNT =
            "The assessment ran with";

        internal const string A_WARNING =
            "warning";

        internal const string A_WARNINGS =
            "warnings";

        internal const string A_ERROR =
            "error";

        internal const string A_ERRORS =
            "errors";

        internal const string A_VALIDITY =
            "Validity";

        internal const string A_EXIT_CODE =
            "Exit Code";

        internal const string A_MESSAGE =
            "Message";

        internal const string A_BUGGED =
            "Bugged";

        internal const string A_API =
            "API";

        internal const string A_EXE =
            "EXE";

        internal const string A_CULTURE =
            "Culture";

        internal const string A_SYSTEM =
            "System";

        internal const string A_CHANNEL =
            "Channel";

        internal const string A_VERSION =
            "Version";

        internal const string A_STARTED =
            "Started";

        // Feature Enum
        internal const string A_RUN_FEATURE_ENUM =
            "Running Feature Enumeration";

        // D3D9
        internal const string A_RUN_ALL_D3D =
            "Running D3D9 Assessments";

        internal const string A_RUN_DX9_DWM =
            "Running the D3D9 Aero Assessment";

        internal const string A_RUN_DX9_BATCH =
            "Running the D3D9 Batch Assessment";

        internal const string A_RUN_DX9_ALPHA =
            "Running the D3D9 Alpha Blend Assessment";

        internal const string A_RUN_DX9_TEX =
            "Running the D3D9 Texture Load Assessment";

        internal const string A_RUN_DX9_ALU =
            "Running the D3D9 ALU Assessment";

        // D3D10
        internal const string A_RUN_DX10_BATCH =
            "Running the D3D10 Batch Assessment";

        internal const string A_RUN_DX10_ALPHA =
            "Running the D3D10 Alpha Blend Assessment";

        internal const string A_RUN_DX10_TEX =
            "Running the D3D10 Texture Load Assessment";

        internal const string A_RUN_DX10_ALU =
            "Running the D3D10 ALU Assessment";

        internal const string A_RUN_DX10_GEOM =
            "Running the Direct3D 10 Geometry Assessment";

        internal const string A_RUN_DX10_CONSTBUFF =
            "Running the D3D10 Constant Buffer Assessment";

        // Windows Media
        internal const string A_RUN_WM_ENCODING_PERF =
            "Assessing Windows Media Encoding Performance";

        internal const string A_RUN_WM_PLAYBACK_PERF =
            "Assessing Windows Media Playback Performance";

        // CPU
        internal const string A_RUN_CPU_PERF =
            "Assessing CPU Performance";

        // MEM
        internal const string A_RUN_MEM_PERF =
            "Assessing Memory Performance";

        // DISK
        internal const string A_RUN_DISK =
            "Assessing Disk Performance";

        internal const string A_RUN_DISK_RR =
            "Ran/Read";

        internal const string A_RUN_DISK_RW =
            "Ran/Write";

        internal const string A_RUN_DISK_SW =
            "Seq/Write";

        internal const string A_RUN_DISK_SR =
            "Seq/Read";
        #endregion
    }

    internal class WinsatStrings
    {
        #region Strings
        internal const string RUN =
            "Run";

        internal const string REPEAT =
            "Repeat";

        internal const string UPDATE =
            "Update";

        internal const string KEY_COMPONENTS =
            "The Experience Index assesses key system components";

        internal const string SCALE_OF_59 =
            "on a scale of 1.0 to 5.9.";

        internal const string SCALE_OF_79 =
            "on a scale of 1.0 to 7.9";

        internal const string SCALE_OF_99 =
            "on a scale of 1.0 to 9.9";

        internal const string WINSAT_LOG_NOT_FOUND =
            "The WinSAT log file was not found.";

        internal const string DEFAULT_PROCESSOR =
            "Calculations per Second";

        internal const string DEFAULT_MEMORY =
            "Memory Operations per Second";

        internal const string DEFAULT_GRAPHICS =
            "Desktop Graphics Performance";

        internal const string DEFAULT_D3D =
            "3D Business and Gaming Graphics Performance";

        internal const string DEFAULT_DISK =
            "Disk Data Transfer Rate";

        // Date format
        internal const string WINSAT_DATE_FORMAT =
            "dddd, MMM d yyyy hh:mm tt";

        // Exit code strings
        internal const string WINSAT_EXIT_SUCCESS =
            "The assesssment completed successfully.";

        internal const string WINSAT_EXIT_UNKNOWN =
            "WinSAT returned an unknown exit code.";

        internal const string WINSAT_EXIT_ERROR_GENERIC =
            "The assessment did not complete due to a generic error.";

        internal const string WINSAT_EXIT_INTERFERENCE =
            "The assessment did not complete due to interference.";

        internal const string WINSAT_EXIT_CANCELLED_BY_USER =
            "The assessment was cancelled by the user.";

        internal const string WINSAT_EXIT_INVALID_COMMAND =
            "The command given to WinSAT was invalid.";

        internal const string WINSAT_EXIT_INVALID_PRIVILAGES =
            "WinSAT requires administrative privilages to run.";

        internal const string WINSAT_EXIT_INSTANCE_ALREADY_RUNNING =
            "Another instance of WinSAT is already running.";

        internal const string WINSAT_EXIT_CANNOT_RUN_INDIVIDUAL_RDS =
            "WinSAT cannot run individual assessments on Remote Desktop Server.";

        internal const string WINSAT_EXIT_BATTERY_POWER =
            "WinSAT cannot run on battery power.";

        internal const string WINSAT_EXIT_CANNOT_RUN_RDS =
            "WinSAT cannot run a formal assessment on Remote Desktop Server.";

        internal const string WINSAT_EXIT_NO_MULTIMEDIA_SUPPORT =
            "The assessment cannot run as no multimedia support was detected.";

        internal const string WINSAT_EXIT_INCOMPATIBLE_OS =
            "WinSAT cannot run on Windows XP.";

        internal const string WINSAT_EXIT_WATCHDOG_TIMEOUT =
            "The WinSAT watchdog timer timed out, indicating something is causing the tests to run unusally slow.";

        internal const string WINSAT_EXIT_VM =
            "WinSAT cannot run the formal assessment on a virtual machine.";

        //  Assessment validity state
        internal const string WINSAT_STATE_UNKNOWN =
            "Unknown assessment validity";

        internal const string WINSAT_STATE_VALID =
            "Experience Index scores are valid";

        internal const string WINSAT_STATE_INCOHERENT =
            "Incoherent with hardware";

        internal const string WINSAT_STATE_UNAVAILABLE =
            "Experience Index has not been established";

        internal const string WINSAT_STATE_INVALID =
            "Experience Index scores are outdated or invalid";
        #endregion
    }
}