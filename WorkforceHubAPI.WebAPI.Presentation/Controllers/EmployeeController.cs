using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;
using WorkforceHubAPI.Shared.RequestFeatures;
using WorkforceHubAPI.WebAPI.Presentation.ActionFilters;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller to handle requests related to employees of a specific company.
/// </summary>
[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _service;

    private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollectionProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeController"/> class.
    /// </summary>
    /// <param name="service">An instance of <see cref="IServiceManager"/> used to manage services related to employee operations.</param>
    /// <param name="apiDescriptionGroupCollectionProvider">
    /// An instance of <see cref="IApiDescriptionGroupCollectionProvider"/> used to dynamically retrieve actions for the OPTIONS method to 
    /// avoid hardcoding them.
    /// </param>
    public EmployeeController(IServiceManager service, IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider)
    {
        _service = service;
        _apiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
    }

    /// <summary>
    /// Handles the HTTP OPTIONS request for the controller by dynamically determining supported HTTP methods.
    /// </summary>
    /// <returns>
    /// A response containing the "Allow" header with the supported HTTP mrthods.
    /// </returns>
    /// 
    [HttpOptions("/api/companies/employees")]
    public IActionResult GetEmployeeControllerOptions()
    {
        // Retrieves the name of the current controller (e.g, "ExampleController" -> "Example").
        var controllerName = ControllerContext.ActionDescriptor.ControllerName;

        // Get all API descriptions for the actions in the application, filtering by the current controller. 
        var apiDescriptions = _apiDescriptionGroupCollectionProvider.ApiDescriptionGroups.Items
            .SelectMany(apiDescriptionGroup => apiDescriptionGroup.Items)
            .Where(apiDescription => apiDescription.ActionDescriptor.RouteValues["controller"] == controllerName);

        // Extract and remove duplicate supported HTTP methods for the current controller.
        var supportedMethods = apiDescriptions
            .Select(description => description.HttpMethod)
            .Distinct()
            .ToArray();

        Response.Headers.Append("Allow", string.Join(", ", supportedMethods));

        return Ok();
    }

    /// <summary>
    /// Retrieves a list of employees for a specific company, with pagination and filtering based on query parameters.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company for which employees are being fetched.</param>
    /// <param name="employeeParameters">
    /// An instance of <see cref="EmployeeParameters"/> that contains pagination and filtering information for the employee query.
    /// This is passed in the query string as part of the request.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is an <see cref="IActionResult"/> that contains an HTTP response
    /// with a status code of 200 OK and the list of employees matching the query parameters.
    /// </returns>
    /// <remarks>
    /// This method makes an asynchronous call to the service layer to retrieve employee data, and returns the result in an HTTP 200 OK response.
    /// The response includes a collection of employee data, paginated and filtered according to the provided <paramref name="employeeParameters"/>.
    /// </remarks>
    [HttpGet]
    [HttpHead]
    public async Task<IActionResult> GetEmployeesForCompany(string companyId, [FromQuery] EmployeeParameters employeeParameters)
    {
        var (employees, metaData) = await _service.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);
        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(employees);
    }

    /// <summary>
    /// Retrieves a specific employee for a specific company
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifier of the employee.</param>
    /// <returns>An <see cref="IActionResult"/> containing the details of the specified employee.</returns>
    [HttpGet("{employeeId}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompany(string companyId, string employeeId)
    {
        var employee = await _service.EmployeeService.GetEmployeeAsync(companyId, employeeId, trackChanges: false);

        return Ok(employee);
    }

    /// <summary>
    /// Handles the POST request to create a new employee for the specified company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company where the employee is being added.</param>
    /// <param name="employee">The data transfer object containing the employee details.</param>
    /// <returns>A response with the created employee data, including a URI to access the newly created employee's details.</returns>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> CreateEmployeeForCompany(string companyId, [FromBody] EmployeeForCreationDto employee)
    {
        var employeeToReturn = await _service.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

        // Return the newly created employee with a route to access it, along with a 201 status code.
        return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeId = employeeToReturn.Id }, employeeToReturn);
    }

    /// <summary>
    /// Handles the HTTP DELETE request to delete an employee for a specific company.
    /// </summary>
    /// <param name="companyId">The ID of the company that employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to delete.</param>
    /// <returns>Returns 204 No Content response if the deletion is successful; otherwise, throws an exception.</returns>
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployeeForCompany(string companyId, string employeeId)
    {
        await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, employeeId, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Updates an existing employee for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee belongs to.</param>
    /// <param name="employeeId">The unique identifier of the employee to update.</param>
    /// <param name="employee">The data transfer object containing updated employee information.</param>
    /// <returns>Returns a 204 No Content response if the employee is successfully updated.</returns>
    [HttpPut("{employeeId}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateEmployeeForCompany(string companyId, string employeeId, [FromBody] EmployeeForUpdateDto employee)
    {
        await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, employeeId, employee, trackCompanyChanges: false, trackEmployeeChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially updates an employee for a specific company using a JSON Patch document.
    /// </summary>
    /// <param name="companyId">The ID of the company the employee belongs to.</param>
    /// <param name="employeeId">The ID of the employee to update.</param>
    /// <param name="patchDocument">The JSON Patch document containing the changes.</param>
    /// <returns>A 204 No Content response if the update is successful or a `BadRequest` response if the patch document is null.</returns>
    [HttpPatch("{employeeId}")]
    [Consumes(MediaTypeNames.Application.JsonPatch)]
    public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(string companyId, string employeeId, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
    {
        if (patchDocument is null)
        {
            return BadRequest("Patch Document sent from client is null.");
        }

        var (employeeToPatch, employeeEntity) = await _service.EmployeeService.GetEmployeeForPatchAsync(companyId, employeeId, trackCompanyChanges: false, trackEmployeeChanges: true);
        patchDocument.ApplyTo(employeeToPatch, ModelState);
        TryValidateModel(employeeToPatch);

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        await _service.EmployeeService.SaveChangesForPatchAsync(employeeToPatch, employeeEntity);

        return NoContent();
    }
}