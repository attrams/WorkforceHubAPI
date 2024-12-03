using Microsoft.EntityFrameworkCore;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.RequestFeatures;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Represents the repository implementation for managing <see cref="Company"/> entities.
/// Inherits common repository logic from <see cref="RepositoryBase{Company}"/> and implements
/// the <see cref="ICompanyRepository"/> interface for defining additional model-specific methods.
/// </summary>
public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

    /// <inheritdoc/>
    public async Task<PagedList<Company>> GetAllCompaniesAsync(CompanyParameters companyParameters, bool trackChanges)
    {
        var query = FindAll(trackChanges).OrderBy(company => company.Name);

        if (!string.IsNullOrWhiteSpace(companyParameters.Country))
        {
            query = FindByCondition(company => company.Country!.Equals(companyParameters.Country), trackChanges).OrderBy(company => company.Name);
        }

        var companies = await query.ToListAsync();

        return PagedList<Company>.ToPagedList(companies, companyParameters.PageNumber, companyParameters.PageSize);
    }

    /// <inheritdoc/>
    public async Task<Company?> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        return await FindByCondition(company => company.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges)
    {
        return await FindByCondition(company => companyIds.Contains(company.Id), trackChanges).ToListAsync();
    }

    /// <inheritdoc/>
    public void CreateCompany(Company company)
    {
        Create(company);
    }

    /// <inheritdoc/>
    public void DeleteCompany(Company company)
    {
        Delete(company);
    }
}
