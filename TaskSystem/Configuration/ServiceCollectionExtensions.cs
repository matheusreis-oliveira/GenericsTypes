using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
    }
}
