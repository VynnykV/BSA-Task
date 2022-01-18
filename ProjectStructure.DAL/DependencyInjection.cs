using Microsoft.Extensions.DependencyInjection;
using ProjectStructure.DAL.Interfaces;
using ProjectStructure.DAL.Repositories;

namespace ProjectStructure.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}