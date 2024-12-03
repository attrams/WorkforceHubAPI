namespace WorkforceHubAPI.Shared.RequestFeatures;

/// <summary>
/// Represents parameters used for filtering, sorting, and pagination of company data.
/// Inherits from <see cref="RequestParameters"/> to include common pagination functionality.
/// </summary>
/// <remarks>
/// This class is used to specify the parameters for retrieving company data, 
/// such as the page number, page size, and any additional filtering or sorting 
/// that may be applied to the query.
/// </remarks>
public class CompanyParameters : RequestParameters
{
    private string? _country;
    public string? Country
    {
        get => _country;
        set => _country = string.IsNullOrWhiteSpace(value) ? "Ghana" : value.Trim();
    }
}