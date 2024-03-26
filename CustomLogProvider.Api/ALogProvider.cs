
namespace CustomLogProvider;

public class ALogProvider(IConfiguration configuration) : ILoggerProvider
{
    private readonly IConfiguration _configuration = configuration;

    public ILogger CreateLogger(string categoryName)
    {
        return new Alog(categoryName, _configuration);
    }

    public void Dispose()
    {
    }
}

public class Alog(string categoryName, IConfiguration configuration) : ILogger
{
    private readonly IConfiguration _configuration = configuration;
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return default!;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        var configLogLevel = _configuration["ALog:LogLevel"];

        if (Enum.TryParse(configLogLevel, out LogLevel configLogLevelEnum))
        {
            return logLevel >= configLogLevelEnum;
        }
        // If log level couldn't be parsed from configuration, log all levels by default
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var configLogPlace = _configuration["ALog:LogTo"];
        var logEntry = new LogEntry(logLevel, categoryName, eventId, formatter.Invoke(state, exception), DateTime.Now, exception);

        if (!IsEnabled(logLevel)) return;
        
            if (Enum.TryParse(configLogPlace, out LogTo configLogPlaceEnum))
            {
                if (configLogPlaceEnum == LogTo.Console)//todo :add more logTo!
                    ConsoleLogger.LogToConsole(logEntry);
            }

    }




}
