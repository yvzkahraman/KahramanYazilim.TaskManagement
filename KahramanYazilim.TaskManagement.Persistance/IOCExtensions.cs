﻿using KahramanYazilim.TaskManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Persistance
{
    public static class IOCExtensions
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
        }
    }
}