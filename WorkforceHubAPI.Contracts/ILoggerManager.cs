namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Defines methods for logging messages at various severity levels.
/// </summary>
public interface ILoggerManager
{
    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LogInfo(string message);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LogWarn(string message);

    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LogDebug(string message);

    /// <summary>
    /// Logs an error message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void LogError(string message);
}