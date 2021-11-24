public static class Extensions
{
    public static string WithThousandSeparator(this int value) => value.ToString("N0");
}
