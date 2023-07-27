using Crud.Core.Services;
using Crud.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Core
{
    public static class CoreConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDemoService, DemoService>();
        }
    }
}
