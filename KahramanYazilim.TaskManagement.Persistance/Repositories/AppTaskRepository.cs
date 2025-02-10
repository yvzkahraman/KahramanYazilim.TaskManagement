using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Context;
using KahramanYazilim.TaskManagement.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KahramanYazilim.TaskManagement.Persistance.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly TaskManagementContext context;

        public AppTaskRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(AppTask task)
        {
            await this.context.Tasks.AddAsync(task);
            return await this.context.SaveChangesAsync();
        }

        public async Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10)
        {
            var query = this.context.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(x => x.Title.ToLower().Contains(s.ToLower()));
            }

            var list = await query.Include(x => x.AppUser).Include(x => x.Priority).AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }

        public async Task<PagedData<AppTask>> GetAllByUserIdAsync(int activePage,int userId, string? s = null, int pageSize = 10)
        {
            var query = this.context.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(x => x.Title.ToLower().Contains(s.ToLower()));
            }

            var list = await query.Where(x=>x.AppUserId == userId).Include(x => x.AppUser).Include(x => x.Priority).AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }

        public async Task DeleteAsync(AppTask deleted)
        {
            this.context.Tasks.Remove(deleted);
            await this.context.SaveChangesAsync();
        }
        public async Task<List<AppTask>?> GetAllByFilter(Expression<Func<AppTask, bool>> filter)
        {
            return await this.context.Tasks.Where(filter).ToListAsync();
        }

        public async Task<AppTask?> GetByFilterAsync(Expression<Func<AppTask, bool>> filter)
        {
            return await this.context.Tasks.SingleOrDefaultAsync(filter);
        }

        public async Task<AppTask?> GetByFilterAsNoTrackingAsync(Expression<Func<AppTask, bool>> filter)
        {
            return await this.context.Tasks.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

    }
}
