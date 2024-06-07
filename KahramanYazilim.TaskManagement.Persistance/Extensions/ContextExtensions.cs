using KahramanYazilim.TaskManagement.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KahramanYazilim.TaskManagement.Persistance.Extensions
{
    public static class ContextExtensions
    {
        public static async Task<PagedData<T>> ToPagedAsync<T>(this IQueryable<T> query, int activePage, int pageSize)
            where T : class, new()
        {
            var list = await query.AsNoTracking().Skip((activePage - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalPage = await query.AsNoTracking().CountAsync();

            return new PagedData<T>(list, activePage, totalPage, pageSize);
        }
    }
}
