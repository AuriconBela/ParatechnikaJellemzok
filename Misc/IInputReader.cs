using UnitsNet;

namespace ParatechnikaJellemzok.Misc
{
    public interface IInputReader
    {
        bool ReadIntInRange(string prompt, int min, int max, out int value);
        bool ReadLengthInCentimeters(string prompt, out Length length);
        bool ReadPositiveDouble(string prompt, out double value);
        bool ReadTemperatureInCelsius(string prompt, out Temperature temp);

        Func<ConsoleColor, IConsoleColorSetter>? ConsoleColorSetter { get; set; }
    }
}