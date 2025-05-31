using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace CompanyEmployees.ContextFactory
{
    /// <summary>
    /// RepositoryContextFactory is only used during design-time tooling operations (like migrations or scaffolding), not at runtime.
    /// </summary>
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var connectionString = configuration.GetConnectionString("sqlConnection");


            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            // We add MigrationsAssembly to specify the location of the migrations, as the DbContext is in another project
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                                .UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("CompanyEmployees"));

            return new RepositoryContext(builder.Options);
        }
    }
}
