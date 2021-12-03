using System.Globalization;

namespace CasualFun.AtCirclesEdge
{
    public static class Extensions
    {
        public static string WithThousandSeparator(this int value) => value.ToString("#,##0", EnglishCulture);
        static CultureInfo EnglishCulture => CultureInfo.GetCultureInfo("en-US");
    }
}
