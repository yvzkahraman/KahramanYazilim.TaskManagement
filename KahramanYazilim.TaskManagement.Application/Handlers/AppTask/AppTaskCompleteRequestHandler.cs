using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskCompleteRequestHandler : IRequestHandler<AppTaskCompleteRequest, Result<NoData>>
    {
        private readonly IAppTaskRepository appTaskRepository;
        private readonly INotificationRepository notificationRepository;

        public AppTaskCompleteRequestHandler(IAppTaskRepository appTaskRepository, INotificationRepository notificationRepository)
        {
            this.appTaskRepository = appTaskRepository;
            this.notificationRepository = notificationRepository;
        }

        public async Task<Result<NoData>> Handle(AppTaskCompleteRequest request, CancellationToken cancellationToken)
        {

            var updated = await this.appTaskRepository.GetByFilterAsync(x => x.Id == request.Id);

            updated.State = true;

            await this.appTaskRepository.SaveChangesAsync();

            await this.notificationRepository.SendNotification(new Domain.Entities.Notification
            {
                State = false,
                AppUserId=1,
                Description=$"{updated.Title} adlı iş emri tamamlandı",
                
            });

            return new Result<NoData>(new NoData(), true, null, null);

        }
    }
}
