using Microsoft.EntityFrameworkCore;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the repository implementation for managing <see cref="Employee"/> entities.
/// Inherits common repository logic from <see cref="RepositoryBase{Employee}"/> and implements
/// the <see cref="IEmployeeRepository"/> interface for defining additional model-specific methods.
/// </summary>
public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

    /// <inheritdoc/>
    public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        var employees = await FindByCondition(employee => employee.CompanyId.Equals(companyId), trackChanges)
                        .OrderBy(employee => employee.Name)
                        .ToListAsync();

        return PagedList<Employee>.ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
    }

    /// <inheritdoc/>
    public async Task<Employee?> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges)
    {
        return await FindByCondition(employee => employee.CompanyId.Equals(companyId) && employee.Id.Equals(employeeId), trackChanges)
                        .SingleOrDefaultAsync();
    }

    /// <summary>
    /// Associates a new employee with a specific company and adds the employee to the database.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to which the employee will be associated.</param>
    /// <param name="employee">The employee entity to be added to the database.</param>
    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        // set the companyId property of the employee entity to associate it with the given company.
        employee.CompanyId = companyId;

        // Use the base repository 'Create' method to add the employee entity to the database.
        Create(employee);
    }

    /// <summary>
    /// Deletes the specified employee from the repository.
    /// </summary>
    /// <param name="employee">The employee to delete.</param>
    public void DeleteEmployee(Employee employee)
    {
        // Use the base repository 'Delete' method to remove the employee entity to the database.
        Delete(employee);
    }
}
