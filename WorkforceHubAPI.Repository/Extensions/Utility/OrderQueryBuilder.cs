using System.Reflection;
using System.Text;

namespace WorkforceHubAPI.Repository.Extensions.Utility;

/// <summary>
/// A utility class to dynamically construct an order-by query string based on the provided sorting paramters.
/// </summary>
public static class OrderQueryBuilder
{

    /// <summary>
    /// Creates an order-by query string for the specified type based on the provided sorting parameters.
    /// </summary>
    /// <typeparam name="T">The type of the entity for which the query is being built.</typeparam>
    /// <param name="orderByQueryString">A comma-separated string specifying the properties and sort directions (e.g., "Name asc, Age desc").</param>
    /// <returns>
    /// A formatted order-by query string (e.g., "Name ascending, Age descending"), or an empty string if no valid properties are provided.
    /// </returns>
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                continue;
            }

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(propertyInfo =>
                propertyInfo.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)
            );

            if (objectProperty is null)
            {
                continue;
            }

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}