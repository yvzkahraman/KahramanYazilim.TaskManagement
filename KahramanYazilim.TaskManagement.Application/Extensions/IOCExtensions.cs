using KahramanYazilim.TaskManagement.Application.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Extensions
{
    public static class IOCExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(LoginRequest).Assembly));
        }
    }
}
