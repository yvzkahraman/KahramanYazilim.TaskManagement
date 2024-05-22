using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Persistance.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementContext context;

        public PriorityRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await this.context.Priorities.AsNoTracking().ToListAsync();
        }
    }
}
