using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.ErrorModel;
using WorkforceHubAPI.Entities.Exceptions;

namespace WorkforceHubAPI.WebAPI;

/// <summary>
/// Handles global exceptions by implementing the <see cref="IExceptionHandler"/> interface.
/// This provides a mechanism to log exception details and return a structured error response to clients.
/// </summary>
public class GlobalExceptionHandler : IExceptionHandler
{
    public readonly ILoggerManager _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance used to log exception details.</param>
    public GlobalExceptionHandler(ILoggerManager logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Attempts to handle exceptions globally. Captures exception details, logs them, and sends a structured
    /// error response.
    /// </summary>
    /// <param name="httpContext">The current HTTP context.</param>
    /// <param name="exception">The exception that occured.</param>
    /// <param name="cancellationToken">A token to signal cancellation.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> containing a boolean indicating whether the exception was handled.
    /// Returns <c>true</c> after handling exception.
    /// </returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // Set the content type. 
        httpContext.Response.ContentType = "application/json";

        // Retrieve the exception details from the context.
        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            // Dynamically set the HTTP response status code based on the type of exception encountered.
            // If the exception inherits the NotFoundException, it responds with a 404 Not Found status.
            // For any other exception types, respond with a 500 Internal Server Error status.
            httpContext.Response.StatusCode = contextFeature.Error switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,

                _ => StatusCodes.Status500InternalServerError
            };

            _logger.LogError($"Something went wrong: {contextFeature.Error}");

            // Create and return a structured error response.
            await httpContext.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = contextFeature.Error.Message
                }.ToString()
            );
        }

        // Indicates that the exception was successfully handled.
        return true;
    }
}