namespace CustomLogProvider;

public record LogEntry(LogLevel logLevel, string categoryName, EventId eventId, string message, DateTime timestamp, Exception? exception);

