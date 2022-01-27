namespace StringUtils;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static string ToUpper(this string input, int index)
    {
        return ToCase(input, str => str.ToUpper(), index);
    }

    public static string ToLower(this string input, int index)
    {
        return ToCase(input, str => str.ToLower(), index);
    }

    private static string ToCase(string input, Func<string, string> func, int index)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (input == "") return "";

        var len = input.Length;
        if (len <= Math.Abs(index)) return input;

        index = (len + index) % len;

        string? prefix = null, suffix = null;
        var indexed = input[index].ToString();

        if (index < len - 1)
        {
            suffix = input[(index + 1)..];
        }

        if (index > 0)
        {
            prefix = input[..index];
        }

        return $"{prefix}{func.Invoke(indexed)}{suffix}";
    }
}