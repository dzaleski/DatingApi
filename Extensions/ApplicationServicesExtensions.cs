using DatingApi.Data;
using DatingApi.Interfaces;
using DatingApi.Repositories;
using DatingApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DatingApi.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("sqlServer")));

            services.AddScoped<IUserRepository, SqlUserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();

            return services;
        }
    }
}
