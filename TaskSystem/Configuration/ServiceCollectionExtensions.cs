using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TaskSystem.Data;
using TaskSystem.Repository;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContexts(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("TaskDb");

            if (connectionString == "InMemoryDb")
            {
                builder.Services.AddDbContext<TaskDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
            }
            else
            {
                builder.Services.AddDbContext<TaskDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }
        }

        public static void RegisterRepositories(this WebApplicationBuilder builder)
        {

            //REFLEXÃO PARA REGISTRAR OS REPOSITORYS
            //var assembly = Assembly.GetExecutingAssembly();
            //var repositoryType = typeof(IRepository<>);

            //foreach (var type in assembly.GetTypes()
            //    .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "TaskSystem.Repository"))
            //{
            //    foreach (var iface in type.GetInterfaces()
            //        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == repositoryType))
            //    {
            //        builder.Services.AddScoped(iface, type);
            //    }
            //}

            //D.I, porem a classe precisa ser concreta
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskSystem", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            var key = Encoding.ASCII.GetBytes(builder.Configuration["appsettings:Secret"]);

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
