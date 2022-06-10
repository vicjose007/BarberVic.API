﻿using BarberVic.Application.Services;
using BarberVic.Domain.Models;
using BarberVic.Infrastructure.Repositories;

namespace BarberVic.API.IoC
{
    public static class ApiRegistry
    {
        public static void AddApiRegistry(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
        }

        public static void GetConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
