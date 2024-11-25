using System.Linq.Expressions;

namespace WorkforceHubAPI.Contracts;

/// <summary>
/// Represents the base interface for a generic repository using the repository pattern.
/// Provides CRUD operations and query methods for entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public interface IRepositoryBase<T>
{
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="trackChanges">Indicates whether the returned entities should be tracked by the context.</param>
    /// <returns>An <see cref="IQueryable{T}"/> containing all entities.</returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// Retrieves entities of type <typeparamref name="T"/> that satisfy the specified condition.
    /// </summary>
    /// <param name="expression">The condition to filter the entities.</param>
    /// <param name="trackChanges">Indicates whether the returned entities should be tracked by the context.</param>
    /// <returns>An <see cref="IQueryable{T}"/> containing the filtered entities.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// Adds a new entity of type <typeparamref name="T"/> to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Create(T entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an existing entity of type <typeparamref name="T"/> from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);
}
