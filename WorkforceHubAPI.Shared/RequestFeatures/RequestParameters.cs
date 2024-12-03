namespace WorkforceHubAPI.Shared.RequestFeatures;

/// <summary>
/// Represents a base class for handling common request parameters used for pagination.
/// </summary>
public abstract class RequestParameters
{
    /// <summary>
    /// The maximum allowable size for a page.
    /// Prevents client from requesting an excessively large number of items per page.
    /// </summary>
    const int maxPageSize = 50;

    /// <summary>
    /// The current page number for the request.
    /// Defaults to 1 if not specified.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;

    /// <summary>
    /// The number of items to include in a page of results.
    /// Defaults to 10 but is capped at a maximum of <see cref="maxPageSize"/> to ensure performance.
    /// </summary>
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            // If the requested page size exceeds the maximum, it defaults to maxPageSize.
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}