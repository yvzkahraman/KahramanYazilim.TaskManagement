using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Domain.Entities;
using System.Linq.Expressions;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        //DRY => 

        Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10);

        Task<int> CreateAsync(AppTask task);
        Task DeleteAsync(AppTask deleted);
        Task<AppTask?> GetByFilterAsync(Expression<Func<AppTask, bool>> filter);
        Task<AppTask?> GetByFilterAsNoTrackingAsync(Expression<Func<AppTask, bool>> filter);
     }
}
