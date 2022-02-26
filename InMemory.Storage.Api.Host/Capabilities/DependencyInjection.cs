using InMemory.Storage.Api.Host.Interfaces;
using InMemory.Storage.Api.Host.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InMemory.Storage.Api.Host.Capabilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddSingleton<IProductRepository, InMemoryProductRepository>(); 
                // "AddSingleton" makes sure that InMemoryProductRepository class would be created only once during the lifetime of the API (you can add debugger to constructor and perform multiple API calls and constructor will be called only once)
                // If we would use "AddScoped" instead then "InMemoryProductRepository" class would be instantiated every time you perform new API call
        }
    }
}
