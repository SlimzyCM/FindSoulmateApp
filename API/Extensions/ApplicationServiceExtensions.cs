using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //add the Token services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Add Database connection
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}