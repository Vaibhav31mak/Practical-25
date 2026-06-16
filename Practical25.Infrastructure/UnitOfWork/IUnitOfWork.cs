namespace Practical25.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employees { get; }
        /// <summary>
        /// Saves all pending changes to the database.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
