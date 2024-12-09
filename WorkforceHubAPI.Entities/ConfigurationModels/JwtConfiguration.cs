namespace WorkforceHubAPI.Entities.ConfigurationModels;

/// <summary>
/// Represents the configuration settings for JWT (Json Web Token) used in the application.
/// This class is used to bind JWT settings from the configuration file (appsettings.json) to the application.
/// </summary>
public class JwtConfiguration
{
    public string Section { get; set; } = "JwtSettings";
    public string? SecretKey { get; set; }
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public string? Expires { get; set; }
}