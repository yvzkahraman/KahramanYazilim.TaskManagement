using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Domain.Entities;
using System.Linq.Expressions;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true);

        Task<int> CreateUserAsync(AppUser appUser);

        Task<List<AppUser>?> GetAllByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true);

        Task<PagedData<AppUser>> GetAllAsync(int activePage, string? s = null, int pageSize = 10);
    }
}
