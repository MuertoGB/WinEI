// WinEI
// https://github.com/MuertoGB/WinEI

// PowerUtils.cs
// Released under the GNU GLP v3.0

using System.Windows.Forms;

namespace WinEI.Utils
{
    internal class PowerUtils
    {
        internal static bool IsExternalPowerSourceConnected()
        {
            PowerStatus status =
                SystemInformation.PowerStatus;

            switch (status.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    // Power adapter is not plugged in.
                    return false;
                case PowerLineStatus.Online:
                    // Power adapter is plugged in.
                    return true;
                // Let WinSAT handle it...
                case PowerLineStatus.Unknown:
                    return true;
                default:
                    return true;
            }
        }

        internal static string GetBatteryChargePercentage()
        {
            int batteryPercentage =
                (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);

            return $"{batteryPercentage}%";
        }

    }
}