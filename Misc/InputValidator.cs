namespace ParatechnikaJellemzok.Misc;

public static class InputValidator
{
    public static double RequirePositiveDouble(string input)
    {
        if (!double.TryParse(input, out double value) || value <= 0)
            throw new ArgumentException(Strings.HibasErtekCsakPozitiv);
        return value;
    }

    public static int RequireIntInRange(string input, int min, int max)
    {
        if (!int.TryParse(input, out int value) || value < min || value > max)
            throw new ArgumentException(Strings.CsakMinEsMaxKoztiErtekLehet.Formatted(min, max));
        return value;
    }

    public static string RequireNonEmpty(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException(Strings.NemLehetUres);
        return input;
    }
}
