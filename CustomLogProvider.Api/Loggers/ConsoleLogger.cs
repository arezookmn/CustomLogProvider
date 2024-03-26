namespace CustomLogProvider;

public class ConsoleLogger
{
    public static void LogToConsole(LogEntry logEntry)
    {
        var logcolor = GetConsoleColor(logEntry.logLevel);

        Console.ForegroundColor = logcolor;
        Console.Write($"[ {logEntry.eventId}: {logEntry.logLevel} ]");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($" {logEntry.timestamp:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write($"{logEntry.categoryName}");
        Console.ForegroundColor = logcolor;
        Console.WriteLine($" - {logEntry.message}");

        if (logEntry.logLevel == LogLevel.Error || logEntry.logLevel == LogLevel.Critical && logEntry.exception is not null)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" Exception: {(logEntry.exception?.ToString())}");
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    private static ConsoleColor GetConsoleColor(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Information => ConsoleColor.Green,
            LogLevel.Warning => ConsoleColor.Yellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Critical => ConsoleColor.Magenta,
            _ => ConsoleColor.White, // Default color
        };
    }
}
