namespace ParatechnikaJellemzok.Misc;

public class ConsoleColorSetter : IConsoleColorSetter
{
    private bool _disposed;
    private readonly ConsoleColor _formerColor;

    public ConsoleColorSetter(ConsoleColor consoleColor)
    {
        _formerColor = Console.ForegroundColor;
        Console.ForegroundColor = consoleColor;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Console.ForegroundColor = _formerColor;
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ConsoleColorSetter()
    {
        Dispose(false);
    }
}
