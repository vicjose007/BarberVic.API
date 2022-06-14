using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Services;
using BarberVic.Domain.Models;
using BarberVic.Infrastructure.Generic.Services;
using BarberVic.Infrastructure.Repositories;

namespace BarberVic.API.IoC
{
    public static class ApiRegistry
    {
        public static void AddApiRegistry(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBarberService, BarberService>();
            services.AddScoped<IBarberRepository, BarberRepository>();
            services.AddScoped<IHaircutService, HaircutService>();
            services.AddScoped<IHaircutRepository, HaircutRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IImageService, ImageServices>();
            services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
        }

        public static void GetConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
