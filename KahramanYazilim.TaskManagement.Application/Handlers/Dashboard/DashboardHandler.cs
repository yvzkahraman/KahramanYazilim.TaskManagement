using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.Dashboard
{
    public class DashboardHandler : IRequestHandler<DashboardRequest, Result<DashboardDto>>
    {
        private readonly IAppTaskRepository taskRepository;
        private readonly IUserRepository userRepository;
        private readonly INotificationRepository notificationRepository;

        public DashboardHandler(IAppTaskRepository taskRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
            this.notificationRepository = notificationRepository;
        }

        public async Task<Result<DashboardDto>> Handle(DashboardRequest request, CancellationToken cancellationToken)
        {
            var taskResult = await this.taskRepository.GetAllByFilter(x => true);
            var taskCount = taskResult.Count();

            var userResult = await this.userRepository.GetAllByFilterAsync(x => x.AppRoleId == (int)RoleType.Member);
            var userCount = userResult.Count();

            var notificationResult = await this.notificationRepository.GetAllByFilterAsync(x => x.State == false && x.AppUserId == request.UserId);

            var notificationCount = notificationResult.Count();

            return new Result<DashboardDto>(new DashboardDto(taskCount, userCount, notificationCount),true,null, null);

        }
    }
}
