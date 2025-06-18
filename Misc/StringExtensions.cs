namespace ParatechnikaJellemzok.Misc;

public static class StringExtensions
{
    public static string? WithHungarianDefiniteArticle(this string? word, bool isLowerCase)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return word;
        }
        var first = char.ToLower(word[0]);

        const string vowels = "aáeéiíoóöőuúüű";
        
        if (isLowerCase)
        {
            var article = vowels.Contains(first) ? "az" : "a";
            return $"{article} {word}";
        } else
        {
            var article = vowels.Contains(first) ? "Az" : "A";
            return $"{article} {word}";
        }
        
    }

    public static string? Formatted(this string? formatString, params object[] args)
    {
        return string.Format(formatString, args);
    }
}
