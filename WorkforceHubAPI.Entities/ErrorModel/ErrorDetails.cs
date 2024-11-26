using System.Text.Json;

namespace WorkforceHubAPI.Entities.ErrorModel;

/// <summary>
/// Represents the details of an error response in a structured format.
/// </summary>
public class ErrorDetails
{
    public int StatusCode { get; set; }

    public string? Message { get; set; }

    /// <summary>
    /// Converts the <see cref="ErrorDetails"/> object to a JSON string representation.
    /// </summary>
    /// <returns>A JSON string representation of the error details.</returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}