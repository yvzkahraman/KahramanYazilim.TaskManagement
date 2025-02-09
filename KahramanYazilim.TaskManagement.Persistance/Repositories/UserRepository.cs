using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Context;
using KahramanYazilim.TaskManagement.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KahramanYazilim.TaskManagement.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementContext context;

        public UserRepository(TaskManagementContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUserAsync(AppUser appUser)
        {
            this.context.Users.Add(appUser);
            return await this.context.SaveChangesAsync();

        }


        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {

            if (asNoTracking)
            {
                return await this.context.Users.AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await this.context.Users.SingleOrDefaultAsync(filter);
        }
        public async Task<List<AppUser>?> GetAllByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {

            if (asNoTracking)
            {
                return await this.context.Users.AsNoTracking().Where(filter).ToListAsync();
            }
            return await this.context.Users.Where(filter).ToListAsync();
        }


        public async Task<PagedData<AppUser>> GetAllAsync(int activePage, string? s = null, int pageSize = 10)
        {
            var query = this.context.Users.Where(x=>x.AppRoleId == (int)RoleType.Member).AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(x=>x.Name.ToLower().Contains(s.ToLower()) || x.Surname.ToLower().Contains(s.ToLower()));
            }

          

            var list = await query.AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }

    }
}
