using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model.MongoDB.Interfaces;
using Crud.Core.Model.MongoDB;
using Crud.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Crud.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void InjectDependence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
             serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IDemoRepository, DemoRepository>();
        }
    }
}
