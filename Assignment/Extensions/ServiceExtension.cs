using Assignment.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.Data.Models;
using Movies.Repository.Interface;
using Movies.Repository.Repository;
using Movies.Repository.UnitOfWork;
using Movies.Services.Interfaces;
using Movies.Services.Services;

namespace Assignment.Extensions
{
    internal static class ServiceExtension
    {
        internal static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration[AppSettingKeys.DbConnectionStringKey];
            services.AddDbContext<moviesEntities>(options =>

            options
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true)
                .UseMySql(dbConnectionString,
                    ServerVersion.AutoDetect(dbConnectionString),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                        )
                    )
            );
        }
        internal static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMovieService, MovieService>();
        }

        internal static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies APIs", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = @"Put **ONLY** your JWT Bearer token on textbox below!",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "Bearer"
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //  {
                //    new OpenApiSecurityScheme
                //    {
                //      Reference = new OpenApiReference
                //      {
                //         Type = ReferenceType.SecurityScheme,
                //         Id = "Bearer"
                //      },
                //      Scheme = "oauth2",
                //      Name = "Bearer",
                //      In = ParameterLocation.Header,
                //  }, new List<string>()}
                //});
            });
        }
    }
}
