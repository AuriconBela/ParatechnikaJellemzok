using UnitsNet;

namespace ParatechnikaJellemzok.Misc;

public class InputReader : IInputReader
{
    public bool ReadPositiveDouble(string prompt, out double value)
    {
        Console.WriteLine(prompt);
        Console.ForegroundColor = Constants.InputTextColor;
        var input = Console.ReadLine() ?? string.Empty;
        try
        {
            value = InputValidator.RequirePositiveDouble(input);
            return true;
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = Constants.ErrorTextColor;
            Console.WriteLine(ex.Message);
            value = 0;
            return false;
        }
        finally
        {
            Console.ResetColor();
        }
    }

    public bool ReadIntInRange(string prompt, int min, int max, out int value)
    {
        Console.WriteLine(prompt);
        Console.ForegroundColor = Constants.InputTextColor;
        var input = Console.ReadLine() ?? string.Empty;
        try
        {
            value = InputValidator.RequireIntInRange(input, min, max);
            return true;
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = Constants.ErrorTextColor;
            Console.WriteLine(ex.Message);
            value = 0;
            return false;
        }        
        finally
        {
            Console.ResetColor();
        }
    }

    public bool ReadLengthInCentimeters(string prompt, out Length length)
    {
        if (ReadPositiveDouble(prompt, out double value))
        {
            length = Length.FromCentimeters(value);
            return true;
        }
        length = Length.Zero;
        return false;
    }

    public bool ReadTemperatureInCelsius(string prompt, out Temperature temp)
    {
        if (ReadPositiveDouble(prompt, out double value))
        {
            temp = Temperature.FromDegreesCelsius(value);
            return true;
        }
        temp = Temperature.Zero;
        return false;
    }
}
