using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Extenstions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                // we are okay with current configurations
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseMySql(
                                            configuration.GetConnectionString("sqlConnection"),
                                            ServerVersion.AutoDetect(configuration.GetConnectionString("sqlConnection"))
                                            ));
        }
    }
}
