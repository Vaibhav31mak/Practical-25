namespace Practical25.Infrastructure.Repositories
{
    // A sealed generic repository interface defining common data access methods.
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets an entity by identifier.
        /// </summary>
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets all entities.
        /// </summary>
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        void Update(T entity);
        /// <summary>
        /// Removes an existing entity.
        /// </summary>
        void Remove(T entity);
    }
}
