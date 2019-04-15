using Microsoft.Extensions.DependencyInjection;
using CarPooling.DataAcces.Repository;
namespace CarPooling.Infrastructure.services
{
    public static class RepositoryServices
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
