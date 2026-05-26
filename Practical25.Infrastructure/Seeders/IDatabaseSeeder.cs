namespace Practical25.Infrastructure.Seeders
{
    public interface IDatabaseSeeder
    {
        /// <summary>
        /// Seeds initial data into the database.
        /// </summary>
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
