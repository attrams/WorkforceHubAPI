using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.WebAPI;

/// <summary>
/// Custom output formatter for CSV responses.
/// </summary>
public class CsvOutputFormatter : TextOutputFormatter
{

    /// <summary>
    /// Initializes a new instance of the <see cref="CsvOutputFormatter"/> class.
    /// Configures supported media types and encoding for the formatter.
    /// </summary>
    public CsvOutputFormatter()
    {
        // Add supported media type for CSV.
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));

        // Add supported encodings.
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    /// <summary>
    /// Determines whether the given type can be written by the formatter.
    /// </summary>
    /// <param name="type">The type to check for compatibility.</param>
    /// <returns>True if the type is supported; otherwise, false.</returns>
    protected override bool CanWriteType(Type? type)
    {
        // Check if the type is assignable from CompanyDto, EmployeeDto or their collections.
        if (
            typeof(CompanyDto).IsAssignableFrom(type) || typeof(IEnumerable<CompanyDto>).IsAssignableFrom(type) ||
            typeof(EmployeeDto).IsAssignableFrom(type) || typeof(IEnumerable<EmployeeDto>).IsAssignableFrom(type)
        )
        {
            return base.CanWriteType(type);
        }

        return false;
    }

    /// <summary>
    /// Writes the response body as a CSV string.
    /// </summary>
    /// <param name="context">The context containing the object to format.</param>
    /// <param name="selectedEncoding">The encoding to use for the response.</param>
    /// <returns>A task representing the asynchronous write operation.</returns>
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        // // Generate headers and data for collections and single objects for CompanyDto and EmployeeDto.
        if (context.Object is IEnumerable<CompanyDto>)
        {
            AddHeaders(buffer, typeof(CompanyDto));

            foreach (var company in (IEnumerable<CompanyDto>)context.Object)
            {
                FormatCsv(buffer, company);
            }
        }
        else if (context.Object is IEnumerable<EmployeeDto>)
        {
            AddHeaders(buffer, typeof(EmployeeDto));

            foreach (var employee in (IEnumerable<EmployeeDto>)context.Object)
            {
                FormatCsv(buffer, employee);
            }
        }
        else if (context.Object is CompanyDto)
        {
            AddHeaders(buffer, typeof(CompanyDto));
            FormatCsv(buffer, (CompanyDto)context.Object);
        }
        else if (context.Object is EmployeeDto)
        {
            AddHeaders(buffer, typeof(EmployeeDto));
            FormatCsv(buffer, (EmployeeDto)context.Object);
        }

        // Write the CSV data to the response body.
        await response.WriteAsync(buffer.ToString());
    }

    /// <summary>
    /// Adds the header row to the CSV buffer using the property names of the specified DTO type.
    /// </summary>
    /// <param name="buffer">The StringBuilder buffer to append the DTO's headers.</param>
    /// <param name="dtoType">The DTO whose properties are used as headers.</param>
    private static void AddHeaders(StringBuilder buffer, Type dtoType)
    {
        var properties = dtoType.GetProperties();
        var headerLine = string.Join(',', properties.Select(property => property.Name));

        buffer.AppendLine(headerLine);
    }

    /// <summary>
    /// Formats a single CompanyDto as a CSV row and appends it to the buffer.
    /// </summary>
    /// <param name="buffer">The StringBuilder buffer to append the CSV data.</param>
    /// <param name="company">The CompanyDto to format.</param>
    private static void FormatCsv(StringBuilder buffer, CompanyDto company)
    {
        buffer.AppendLine($"{company.Id},\"{company.Name}\",\"{company.FullAddress}\"");
    }

    /// <summary>
    /// Formats a single EmployeeDto as a CSV row and appends it to the buffer.
    /// </summary>
    /// <param name="buffer">The StringBuilder buffer to append the CSV data.</param>
    /// <param name="employee">The EmployeeDto to format.</param>
    private static void FormatCsv(StringBuilder buffer, EmployeeDto employee)
    {
        buffer.AppendLine($"{employee.Id},\"{employee.Name}\",{employee.Age},\"{employee.Position}\"");
    }
}