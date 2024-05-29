using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Context;
using KahramanYazilim.TaskManagement.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KahramanYazilim.TaskManagement.Persistance.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly TaskManagementContext context;

        public AppTaskRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<PagedData<AppTask>> GetAllAsync(int activePage, int pageSize = 10)
        {
            var list = await this.context.Tasks.Include(x => x.Priority).AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }
    }
}
