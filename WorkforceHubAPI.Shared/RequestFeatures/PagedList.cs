namespace WorkforceHubAPI.Shared.RequestFeatures;

/// <summary>
/// Represents a paginated list of items, extending from <see cref="List{T}"/>.
/// Includes metadata information about the pagination and provides methods to create paginated lists.
/// </summary>
/// <typeparam name="T">The type of items in the paginated list.</typeparam>
/// <remarks>
/// This class is used to return a collection of items for a specific page along with metadata 
/// such as the total number of items, current page, total pages, and page size.
/// </remarks>
public class PagedList<T> : List<T>
{
    /// <summary>
    /// Gets or sets the metadata associated with the paginated list, 
    /// such as total count, total pages, and page size.
    /// </summary>
    public MetaData MetaData { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}"/> class with the specified list of items and pagination details.
    /// </summary>
    /// <param name="items">The list of items for the current page.</param>
    /// <param name="count">The total number of items across all pages.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        // Initialize metadata based on pagination details.
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        // Add the items for the current page to the list.
        AddRange(items);
    }

    /// <summary>
    /// Converts a source collection into a paginated list with the specified page number and page size.
    /// </summary>
    /// <param name="source">The source collection of items to paginate.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A <see cref="PagedList{T}"/> containing the items for the specified page and metadata.</returns>
    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count(); // Get the total number of items in the source collection.
        var items = source.Skip((pageNumber - 1) * pageSize) // Skip items for the previous pages.
                          .Take(pageSize) // Take the required number of items for the current page.
                          .ToList();

        // Return a new PagedList instance with the paginated items and metadata.
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
