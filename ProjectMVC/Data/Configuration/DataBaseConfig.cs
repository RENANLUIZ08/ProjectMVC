using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectMVC.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Data.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var strCon = configuration.GetConnectionString("strconexao");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(strCon));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
