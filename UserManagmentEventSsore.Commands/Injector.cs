using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentEventSsore.Commands.Commands;

namespace UserManagmentEventSsore.Commands
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<ICommandsService, CommandsService>();

        }
    }
}
