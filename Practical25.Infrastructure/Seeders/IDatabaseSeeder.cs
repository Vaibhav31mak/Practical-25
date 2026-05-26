namespace Practical25.Infrastructure.Seeders
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
