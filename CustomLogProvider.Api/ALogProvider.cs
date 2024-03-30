
using ALog.Api.Models;
using Microsoft.Extensions.Options;

namespace CustomLogProvider;

public class ALogProvider(IOptions<ALogOptions> options) : ILoggerProvider
{
    private readonly ALogOptions _options = options.Value;

    public ILogger CreateLogger(string categoryName)
    {
        return new Alog(categoryName, options);
    }

    public void Dispose()
    {
    }
}

public class Alog(string categoryName, IOptions<ALogOptions> options) : ILogger
{
    private readonly ALogOptions _options = options.Value;  
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return default!;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        var optionLogLevel = _options.logLevel;
        return logLevel >= optionLogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var optionLogTo = _options.LogTo;
        var logEntry = new LogEntry(logLevel, categoryName, eventId, formatter.Invoke(state, exception), DateTime.Now, exception);

        if (!IsEnabled(logLevel)) return;
        
                if (optionLogTo.Contains(LogTo.Console))//todo :add more logTo!
                    ConsoleLogger.LogToConsole(logEntry);

    }




}
