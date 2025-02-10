using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.Notification
{
    public class NotificationUpdateHandler : IRequestHandler<NotificationUpdateRequest, Result<NoData>>
    {
        private readonly INotificationRepository repository;

        public NotificationUpdateHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(NotificationUpdateRequest request, CancellationToken cancellationToken)
        {
            var updated = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            if (updated == null)
                return new Result<NoData>(new NoData(), false, "Bildirim bulunamadı", null);

            updated.State = true;

            await this.repository.SaveChangesAsync();

            return new Result<NoData>(new NoData(),true,null,null);
        }
    }
}
