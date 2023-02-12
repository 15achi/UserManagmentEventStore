using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User.Repositories;
using UserManagment.Infrastructure.Repositories;

namespace UserManagment.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IEventStore>(provider =>
            provider.GetService<EventStoreRepository>());
            services.AddScoped<IEventStore, EventStoreRepository>();

            services.AddScoped<IUserRepository>(provider =>
            provider.GetService<UserRepository>());
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
