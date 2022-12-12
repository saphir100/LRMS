using Application.Common.Models.Identity;
using Infrastructure.Identit;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSetting"));

            //services.AddDbContext<LeaveManagementIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString")
            services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
            options.UseSqlServer("Server=.\\;Database=HRMSIdentity;Trusted_Connection=True;TrustServerCertificate=True"
                 , b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = /*configuration[/*"JwtSettings:Issuer"*/"HRLeaveManagement",
                    ValidAudience = /*configuration[/*"JwtSettings:Audience"*/"HRLeaveManagementUser",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(/*configuration["JwtSettings:Key"*/"84322CFB66934ECC86D547C5CF4F2EFC"))
                };
            });

            return services;
                
        }
    }
}
