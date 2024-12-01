using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WorkforceHubAPI.Service.Contracts;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.WebAPI.Presentation.Controllers;

/// <summary>
/// Controller to handle requests related to employees of a specific company.
/// </summary>
[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeeController(IServiceManager service) => _service = service;

    /// <summary>
    /// Retrieves all employees for a specific company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>An <see cref="IActionResult"/> containing a list of employees for the specific company.</returns>
    [HttpGet]
    public IActionResult GetEmployeesForCompany(string companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);

        return Ok(employees);
    }

    /// <summary>
    /// Retrieves a specific employee for a specific company
    /// </summary>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <param name="employeeId">The unique identifier of the employee.</param>
    /// <returns>An <see cref="IActionResult"/> containing the details of the specified employee.</returns>
    [HttpGet("{employeeId}", Name = "GetEmployeeForCompany")]
    public IActionResult GetEmployeeForCompany(string companyId, string employeeId)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, employeeId, trackChanges: false);

        return Ok(employee);
    }

    /// <summary>
    /// Handles the POST request to create a new employee for the specified company.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company where the employee is being added.</param>
    /// <param name="employee">The data transfer object containing the employee details.</param>
    /// <returns>A response with the created employee data, including a URI to access the newly created employee's details.</returns>
    [HttpPost]
    public IActionResult CreateEmployeeForCompany(string companyId, [FromBody] EmployeeForCreationDto employee)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

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
    public IActionResult DeleteEmployeeForCompany(string companyId, string employeeId)
    {
        _service.EmployeeService.DeleteEmployeeForCompany(companyId, employeeId, trackChanges: false);

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
    public IActionResult UpdateEmployeeForCompany(string companyId, string employeeId, [FromBody] EmployeeForUpdateDto employee)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        _service.EmployeeService.UpdateEmployeeForCompany(companyId, employeeId, employee, trackCompanyChanges: false, trackEmployeeChanges: true);

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
    public IActionResult PartiallyUpdateEmployeeForCompany(string companyId, string employeeId, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
    {
        if (patchDocument is null)
        {
            return BadRequest("Patch Document sent from client is null.");
        }

        var result = _service.EmployeeService.GetEmployeeForPatch(companyId, employeeId, trackCompanyChanges: false, trackEmployeeChanges: true);
        patchDocument.ApplyTo(result.employeeToPatch, ModelState);
        TryValidateModel(result.employeeToPatch);

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        _service.EmployeeService.SaveChangesForPatch(result.employeeToPatch, result.employeeEntity);

        return NoContent();
    }
}