namespace WorkforceHubAPI.Shared.RequestFeatures;

/// <summary>
/// Represents parameters used for filtering, sorting, and pagination of employee data.
/// Inherits from <see cref="RequestParameters"/> to include common pagination functionality.
/// </summary>
/// <remarks>
/// This class is used to specify the parameters for retrieving employee data, 
/// such as the page number, page size, and any additional filtering or sorting 
/// that may be applied to the query.
/// </remarks>
public class EmployeeParameters : RequestParameters
{
    public EmployeeParameters() => OrderBy = "name";
    public uint MinAge { get; set; }

    public uint MaxAge { get; set; } = int.MaxValue;

    public bool ValidAgeRange => MaxAge > MinAge;

    public string? SearchTerm { get; set; }
}