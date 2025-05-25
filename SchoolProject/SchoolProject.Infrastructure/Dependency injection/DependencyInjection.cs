using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Infrastructure.Dependency_injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            return Services.AddEntityFrameworkCoreServices(Configuration);
        }
        static IServiceCollection AddEntityFrameworkCoreServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("defaultConnection");

            Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString)).AddRepositories();

            return Services;
        }
        static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        }

    }
}
