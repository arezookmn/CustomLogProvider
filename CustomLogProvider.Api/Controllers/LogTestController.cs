using Microsoft.AspNetCore.Mvc;

namespace CustomLogProvider.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogTestController: ControllerBase
{
    private readonly ILogger<LogTestController> _logger;

    public LogTestController(ILogger<LogTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // Log messages for different log levels with custom parameters
        _logger.LogTrace(eventId: 1, message: "This is a trace message");
        _logger.LogInformation(eventId: 2, message: "This is an information message");
        _logger.LogWarning(eventId: 3, message: "This is a warning message");
        _logger.LogError(eventId: 4, message: "This is an error message", exception: new Exception("Test error"));
        _logger.LogCritical(eventId: 5, message: "This is a critical message", exception: new Exception("Test critical error"));

        return NoContent();
    }

}
