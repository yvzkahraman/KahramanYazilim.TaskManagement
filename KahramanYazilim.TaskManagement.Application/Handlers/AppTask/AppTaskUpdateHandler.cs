using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators;
using KahramanYazilim.TaskManagement.Application.Validators.AppTask;
using KahramanYazilim.TaskManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskUpdateHandler : IRequestHandler<AppTaskUpdateRequest, Result<AppTaskDto>>
    {
        private readonly IAppTaskRepository repository;
        private readonly IPriorityRepository priorityRepository;
        private readonly IUserRepository userRepository;
        private readonly INotificationRepository notificationRepository;

        public AppTaskUpdateHandler(IAppTaskRepository repository, IPriorityRepository priorityRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            this.repository = repository;
            this.priorityRepository = priorityRepository;
            this.userRepository = userRepository;
            this.notificationRepository = notificationRepository;
        }

        public async Task<Result<AppTaskDto>> Handle(AppTaskUpdateRequest request, CancellationToken cancellationToken)
        {

            var priorities = await this.priorityRepository.GetAllAsync();

            var priorityDtoList = priorities.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            var members = await this.userRepository.GetAllByFilterAsync(x => x.AppRoleId == (int)RoleType.Member);

            var memberDtoList = members.Select(x => new MemberListDto(x.Id,x.Name,x.Surname,x.Username)).ToList();

            var validator = new AppTaskUpdateRequestValidator();
            var validationResult = validator.Validate(request);


            if (validationResult.IsValid)
            {
                var updated = await this.repository.GetByFilterAsync(x=>x.Id == request.Id);
                if (updated == null) {

                    return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList, memberDtoList), false, "Task bulunamadı", null);
                }

                if (request.AppUserId == null || request.AppUserId == 0) {

                    updated.AppUserId = null;
                }
                else
                {

                    if(updated.AppUserId != request.AppUserId)
                    {
                        await this.notificationRepository.SendNotification(new Domain.Entities.Notification
                        {
                            AppUserId = request.AppUserId ?? 0,
                            Description = $"{request.Title} adlı iş üzerinize atandı",
                            State = false,
                        });
                    }

                    updated.AppUserId = request.AppUserId;
                    // send notification

               
                }

                updated.Title = request.Title;
                updated.Description = request.Description;
                updated.PriorityId = request.PriorityId;

                var rows = await this.repository.SaveChangesAsync();


                if (rows > 0)
                    return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList,memberDtoList), true, null, null);

                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList, memberDtoList), false, "bir hata oluştu", null);
            }
            else
            {
                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList, memberDtoList), false, null, validationResult.Errors.ToMap());
            }
        }
    }
}
