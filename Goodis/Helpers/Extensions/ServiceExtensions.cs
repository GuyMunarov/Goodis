using Goodis.Helpers.Mapper;
using Infrastracture.Data;
using Infrastracture.DataAccess;
using Infrastracture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Models.Interfaces;
using System.Text;

namespace Goodis.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(x =>
            x.UseSqlite(config.GetConnectionString("DefaultConnection")
           , x=> x.MigrationsAssembly("Infrastracture")
            ));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidIssuer = config["Token:Issuer"],
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IHashingService, HashingService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddAutoMapper(typeof(MappingProfiles));


        }
    }
}
