using WorkforceHubAPI.Entities.Models;

namespace WorkforceHubAPI.Repository.Extensions;

/// <summary>
/// Provides extension methods for filtering and searching employees in an IQueryable<employee>
/// </summary>
public static class RepositoryEmployeeExtensions
{
    /// <summary>
    /// Filters employees based on a specified age range.
    /// </summary>
    /// <param name="employees">The collection of employees to filter.</param>
    /// <param name="minAge">The minimum age to include in the filter.</param>
    /// <param name="maxAge">The maximum age to include in the filter.</param>
    /// <returns>
    /// An <see cref="IQueryable{T}"/> containing employees whose age is within the specified range.
    /// </returns>
    public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge)
    {
        return employees.Where(employee => employee.Age >= minAge && employee.Age <= maxAge);
    }

    /// <summary>
    /// Searches employees based on the specified search term.
    /// </summary>
    /// <param name="employees">The collection of employees to search.</param>
    /// <param name="searchTerm">The term to search for in employee names. Case-insensitive.</param>
    /// <returns>
    /// An <see cref="IQueryable{T}"/> containing employees whose names contain the specified search term.
    /// If the search term is null, empty, or whitespace, the original collection is returned.
    /// </returns>
    public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return employees;
        }
        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return employees.Where(employee => employee.Name!.ToLower().Contains(lowerCaseTerm));
    }
}