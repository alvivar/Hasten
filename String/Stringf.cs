using System.Text.RegularExpressions;

public static class Stringf
{
    public static string MakeSafeForCode(string text)
    {
        text = Regex.Replace(text, "[^a-zA-Z0-9_]", "_", RegexOptions.None);
        if (char.IsDigit(text[0])) text = "_" + text;

        return text;
    }

    public static string CamelCase(string text)
    {
        return $"{char.ToLowerInvariant(text[0])}{text.Substring(1)}";
    }
}