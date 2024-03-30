using CustomLogProvider;

namespace ALog.Api.Models;

public class ALogOptions
{
    public const string ALog = "ALog";
    public List<LogTo> LogTo { get; set; }
    public LogLevel logLevel { get; set; }
}
