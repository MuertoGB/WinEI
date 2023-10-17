// WinEI
// https://github.com/MuertoGB/WinEI

// Hotfix.cs
// Released under the GNU GLP v3.0
// MS released a bugged version of the WinSAT executable.
// This code looks for those bugged versions.

using System.Linq;
using WinEI.Utils;

public class WinsatBugChecker
{
    // List of affected WinSAT versions (Failed to properly assess the disk. The parameter is incorrect.)
    internal static string[] strListOfAffectedWinsat =
    {
        "6.1.7600.16976",
        "6.1.7600.21167",
        "6.1.7601.17793",
        "6.1.7601.21940"
    };

    internal static bool IsBuggedVersion()
    {
        // We only need to check on Windows 7 (6.1).
        if (OSUtils.IsWindowsSeven())
        {
            // Get the current winsat executable version.
            string fviWinsatExecutable = $"{OSUtils.GetWinsatExeVersion.ProductVersion}";

            // Check the list of affected versions against the current executable.
            if (strListOfAffectedWinsat.Contains(fviWinsatExecutable))
            {
                // A bugged winsat executable was found.
                return true;
            }
        }

        // A bugged version was not found.
        return false;
    }
}