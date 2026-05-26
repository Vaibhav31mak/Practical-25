using Practical25.Infrastructure.Repositories;

namespace Practical25.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
