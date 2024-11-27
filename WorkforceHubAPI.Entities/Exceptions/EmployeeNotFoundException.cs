namespace WorkforceHubAPI.Entities.Exceptions;

/// <summary>
/// Exception thrown when an employee is not found in the database.
/// </summary>
/// <remarks>
/// This exception is specifically used to indicate that an employee with the given identifier does not
/// exist in the database.
/// </remarks>
public sealed class EmployeeNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of <see cref="EmployeeNotFoundException"/> class with the employee ID.
    /// </summary>
    /// <param name="employeeId">The unique identifier of the employee that was not found.</param>
    public EmployeeNotFoundException(Guid employeeId) : base($"Employee with id: {employeeId} doesn't exist in the database.")
    {
    }
}