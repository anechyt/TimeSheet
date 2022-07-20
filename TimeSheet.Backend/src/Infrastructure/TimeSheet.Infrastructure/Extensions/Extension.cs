using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Infrastructure.Dal;

namespace TimeSheet.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString:DefaultConnection"];

            services.AddDbContext<TimeSheetContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("TimeSheet.Api"));
            });

            return services;
        }
    }
}
