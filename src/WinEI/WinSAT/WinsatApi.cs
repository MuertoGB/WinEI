// WinEI
// https://github.com/MuertoGB/WinEI

// WinsatApi.cs
// Released under the GNU GLP v3.0

using System;
using System.Windows.Forms;
using WINSATLib;

namespace WinEI.Winsat
{

    #region Enums
    internal enum INFO_TYPE
    {
        Description,
        Score,
        Title
    }
    #endregion

    internal class WinsatAPI
    {
        internal static int GetAssessmentValidityInteger()
        {
            CQueryWinSAT cQuery = new CQueryWinSAT();

            try
            {
                return (int)cQuery.Info.AssessmentState;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "WinsatApi.GetAssessmentValidityInteger()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return 0;
            }
        }

        internal static string GetApiHardwareInfo(WINSAT_ASSESSMENT_TYPE WinType, INFO_TYPE InfType)
        {
            CQueryWinSAT query =
                new CQueryWinSAT();

            IProvideWinSATAssessmentInfo queryInformation =
                query.Info.GetAssessmentInfo(WinType);

            string result = null;

            try
            {
                if (InfType == INFO_TYPE.Description)
                {
                    result = queryInformation.Description;
                }
                else if (InfType == INFO_TYPE.Score)
                {
                    result = $"{queryInformation.Score}";
                }
                else if (InfType == INFO_TYPE.Title)
                {
                    result = queryInformation.Title;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "WinsatApi.GetApiHardwareInfo()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return result;
        }

        internal static float GetBaseScore()
        {
            CQueryWinSAT query =
                new CQueryWinSAT();

            try
            {
                return query.Info.SystemRating;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "WinsatApi.GetBaseScore()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return 0.0f;
            }
        }

        internal static DateTime GetLatestFormalDate()
        {
            CQueryWinSAT query =
                new CQueryWinSAT();

            try
            {
                return DateTime.Parse(
                    query.Info.AssessmentDateTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "WinsatApi.GetLatestFormalDate()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return DateTime.MinValue;
            }
        }

    }
}