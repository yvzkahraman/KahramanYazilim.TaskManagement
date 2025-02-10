using KahramanYazilim.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface ITaskReportRepository
    {
        Task<List<TaskReport>?> GetAllByFilterAsync(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true);

        Task<TaskReport?> GetByFilter(Expression<Func<TaskReport, bool>> filter, bool asNoTracking = true);


        Task<int> CreateAsync(TaskReport taskReport);

        Task<int> SaveChangesAsync();
    }
}
