using System.Globalization;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Utilities
{
    public static class Extensions
    {
        static CultureInfo EnglishCulture => CultureInfo.GetCultureInfo("en-US");
        
        public static string WithThousandSeparator(this int value) =>
            value.ToString("#,##0", EnglishCulture);

        public static void MoveToRandomPositionInCircle(this Transform value) =>
            value.eulerAngles = new Vector3(0, 0, Random.Range(-360, 360));
    }
}
