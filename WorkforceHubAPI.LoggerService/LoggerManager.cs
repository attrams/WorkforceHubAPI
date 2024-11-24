using Serilog;
using WorkforceHubAPI.Contracts;

namespace WorkforceHubAPI.LoggerService;

/// <summary>
/// LoggerManager is responsible for logging messages at different levels using NLog.
/// It implements the <see cref="ILoggerManager"/> interface, which defines logging methods.
/// </summary>
public class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger;

    public LoggerManager()
    {
        _logger = Log.Logger;
    }

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogInfo(string message) => _logger.Information(message);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogWarn(string message) => _logger.Warning(message);

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogDebug(string message) => _logger.Debug(message);

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void LogError(string message) => _logger.Error(message);
}