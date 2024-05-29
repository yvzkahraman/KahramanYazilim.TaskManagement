using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Domain.Entities;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {

        Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10);
    }
}
