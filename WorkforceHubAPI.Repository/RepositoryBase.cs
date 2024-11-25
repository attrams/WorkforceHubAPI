using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkforceHubAPI.Contracts;

namespace WorkforceHubAPI.Repository;

/// <summary>
/// Serves as a base class for repository implementations, providing common logic for CRUD operations across all
/// entity-specific repositories.
/// Inherits from <see cref="IRepositoryBase{T}"/> to ensure consistent repository structure.
/// </summary>
/// <typeparam name="T">The type of entity the repository will handle, constrained to reference types.</typeparam>
public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    /// <summary>
    /// The database context used to interact with the database.
    /// </summary>
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <param name="trackChanges">Determines whether tracking of entity changes is enabled.</param>
    /// <returns>An <see cref="IQueryable{T}"/> containing all entities.</returns>
    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
            ? RepositoryContext.Set<T>().AsNoTracking()
            : RepositoryContext.Set<T>();
    }

    /// <summary>
    /// Retrieves entities of type <typeparamref name="T"/> that match a specified condition.
    /// </summary>
    /// <param name="expression">The condition to filter entities.</param>
    /// <param name="trackChanges">Determines whether tracking of entity is enabled.</param>
    /// <returns>An <see cref="IQueryable{T}"/> containing the filtered entities.</returns>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);
    }

    /// <summary>
    /// Adds a new entity of type <typeparamref name="T"/> to the database context.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the database context.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    /// <summary>
    /// Deletes an entity of type <typeparamref name="T"/> from the database context.
    /// </summary>
    /// <param name="entity">The entity to be deleted.</param>
    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}
