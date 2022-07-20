using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Infrastructure.Dal;
using TimeSheet.Infrastructure.Services.Proccesing;
using TimeSheet.Infrastructure.Services.View;

namespace TimeSheet.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<TimeSheetContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("TimeSheet.Api"));
            });

            services.AddScoped<IProjectView, ProjectView>();

            services.AddScoped<IActivityProccesing, ActivityProccesing>();
            services.AddScoped<IActivityTypeProccesing, ActivityTypeProccesing>();
            services.AddScoped<IEmployeeProccesing, EmployeeProccesing>();
            services.AddScoped<IRoleProccesing, RoleProccesing>();
            services.AddScoped<IProjectProccesing, ProjectProccesing>();
            services.AddScoped<IActivityView, ActivityView>();

            return services;
        }
    }
}
