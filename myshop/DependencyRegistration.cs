using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models;
using System.Net;
using System.Text;

namespace MyShop.Web
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddWebDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = BadRequestResponseFactory;
                });
            services.AddHttpContextAccessor();

            services
                .AddAuthDependencties(configuration)
                .AddSwaggerDependencies();


            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "wwwroot";
            });

            return services;
        }

        private static IServiceCollection AddAuthDependencties(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["X-Access-Token"];
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }

        private static IServiceCollection AddSwaggerDependencies(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sixt-Platform", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Cookie,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {

                    {
                        new OpenApiSecurityScheme
                        {
                             Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                             }
                        },
                        new List<string> ()
                    }
                });
            });

            return services;
        }


        private static IActionResult BadRequestResponseFactory(ActionContext context)
        {
            var exception = new ValidationException();
            foreach (var key in context.ModelState.Keys)
            {
                exception.Errors.Add(key, context.ModelState[key].Errors.Where(e => e != null).Select(e => e.ErrorMessage).ToArray());
            }
            throw exception;
        }
    }
}
