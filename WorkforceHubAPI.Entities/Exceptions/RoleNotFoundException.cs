namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Exception thrown when a specified role does not exist in the system.
/// </summary>
public class RoleNotFoundException : BadRequestException
{
    public RoleNotFoundException(string role) : base($"The role '{role}' does not exist in the system.")
    {
    }
}