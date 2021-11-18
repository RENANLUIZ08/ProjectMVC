using Microsoft.Extensions.DependencyInjection;
using ProjectMVC.Repository;
using ProjectMVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Data.Configuration
{
    public static class DependencyInjectConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
