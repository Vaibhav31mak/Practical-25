namespace Practical25.Infrastructure.Repositories
{
    // Sealed Generic Repository class Implementation
    public sealed class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        /// <summary>
        /// Gets an entity by identifier.
        /// </summary>
        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(id, cancellationToken);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        public void Update(T entity)
            => _dbSet.Update(entity);

        /// <summary>
        /// Removes an existing entity.
        /// </summary>
        public void Remove(T entity)
            => _dbSet.Remove(entity);
    }
}
