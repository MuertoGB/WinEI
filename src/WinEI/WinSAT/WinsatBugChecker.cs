// WinEI
// https://github.com/MuertoGB/WinEI

// WinsatBugChecker.cs
// Released under the GNU GLP v3.0
// MS released a bugged version of the WinSAT executable back on WIndows 7,
// this code looks for the bugged versions.

using System.Linq;
using WinEI.Utils;

namespace WenEI.Winsat
{
    public class WinsatBugChecker
    {
        // List of affected WinSAT versions (Failed to properly assess the disk. The parameter is incorrect.)
        internal static string[] WinsatBuggedVersions =
        {
            "6.1.7600.16976",
            "6.1.7600.21167",
            "6.1.7601.17793",
            "6.1.7601.21940"
        };

        internal static bool IsBuggedVersion()
        {
            // We only need to check on Windows 7.
            if (OSUtils.IsWindowsSeven())
            {
                // Get the current winsat executable version.
                string winsatVersion = $"{OSUtils.GetWinsatExeVersion.ProductVersion}";

                // Check the list of affected versions against the current executable.
                if (WinsatBuggedVersions.Contains(winsatVersion))
                {
                    // A bugged winsat executable was found.
                    return true;
                }
            }

            // A bugged version was not found.
            return false;
        }
    }
}
