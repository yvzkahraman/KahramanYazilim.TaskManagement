﻿using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Context;
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
    }
}
