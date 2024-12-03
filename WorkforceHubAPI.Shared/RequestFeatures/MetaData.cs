namespace WorkforceHubAPI.Shared.RequestFeatures;

/// <summary>
/// Represents metadata for a paginated list, including information about the current page, total pages, 
/// page size, and total count of items.
/// </summary>
/// <remarks>
/// This class is used to provide information about the pagination of a list of items, including whether 
/// there are previous or next pages, and the total number of items across all pages.
/// </remarks>
public class MetaData
{
    /// <summary>
    /// Gets or sets the current page number in the pagination.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages available based on the page size and total count.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the number of items per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the total number of items across all pages.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Determines if there are previous pages available (i.e., current page > 1).
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>
    /// Determines if there are next pages available (i.e., current page < total pages).
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}
