using Microsoft.Extensions.DependencyInjection;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.BLL.MappingProfiles;
using ProjectStructure.BLL.Services;

namespace ProjectStructure.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddAutoMapper(typeof(UserProfile), typeof(ProjectProfile), typeof(TaskProfile), typeof(TeamProfile));
            return services;
        }
    }
}