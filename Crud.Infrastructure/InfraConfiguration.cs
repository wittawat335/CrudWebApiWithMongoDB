using Crud.Core.Domain.RepositoryContract;
using Crud.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void InjectDependence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDemoRepository, DemoRepository>();
        }
    }
}
