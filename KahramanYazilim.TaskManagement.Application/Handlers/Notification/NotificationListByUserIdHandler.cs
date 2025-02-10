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
    public class NotificationListByUserIdHandler : IRequestHandler<NotificationListByUserIdRequest, Result<List<NotificationListDto>>>
    {

        private readonly INotificationRepository repository;

        public NotificationListByUserIdHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<NotificationListDto>>> Handle(NotificationListByUserIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllByFilterAsync(x => x.AppUserId == request.UserId);


            var mappedData = result.Select(x => new NotificationListDto(x.Id, x.Description, x.State, x.AppUserId)).ToList();
            return new Result<List<NotificationListDto>>(mappedData, true, null, null);
        }
    }
}
