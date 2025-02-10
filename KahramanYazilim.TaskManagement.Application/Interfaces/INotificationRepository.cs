using KahramanYazilim.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface INotificationRepository
    {
        Task<int> SendNotification(Notification notification);
        Task<Notification?> GetByFilterAsync(Expression<Func<Notification, bool>> filter);
        Task<Notification?> GetByFilterAsNoTrackingAsync(Expression<Func<Notification, bool>> filter);

        Task<List<Notification>?> GetAllByFilterAsync(Expression<Func<Notification, bool>> filter, bool asNoTracking = true);

        Task<int> SaveChangesAsync();
    }
}
