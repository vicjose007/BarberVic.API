using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.UnitOfWorks;

namespace BarberVic.Infrastructure.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<IBarberVicDbContext, BarberVicDbContext>();
            services.AddScoped<IUnitOfWork<IBarberVicDbContext>, BarberVicUnitOfWork>();
        }
    }
}
