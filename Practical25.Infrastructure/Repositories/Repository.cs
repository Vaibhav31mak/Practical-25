namespace Practical25.Infrastructure.Repositories
{
    // Sealed Generic Repository class Implementation
    public sealed class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        /// <summary>
        /// Gets an entity by identifier.
        /// </summary>
        public async Task<T?> GetByIdAsync
            (int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if(entity is IStatusCheck statusCheckEntity && !statusCheckEntity.Status)
            {
                return null;
            }
            return entity;
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        public async Task<IReadOnlyList<T>> GetAllAsync
            (CancellationToken cancellationToken = default)
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
            entities.RemoveAll(e => e is IStatusCheck statusCheckEntity
                                    && !statusCheckEntity.Status);
            return entities;
        }

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
        /// Soft Deletes an existing entity.
        /// </summary>
        public void Remove(T entity)
        {
            if (entity is IStatusCheck statusCheckEntity)
            {
                statusCheckEntity.Status = false;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
