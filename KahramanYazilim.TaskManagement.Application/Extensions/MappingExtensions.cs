using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Domain.Entities;

namespace KahramanYazilim.TaskManagement.Application.Extensions
{
    public static class MappingExtensions
    {
        public static AppUser ToMap(this RegisterRequest request)
        {
            return new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                Name = request.Name,
                Password = request.Password,
                Surname = request.Surname,
                Username = request.Username,

            };
        }

        public static Priority ToMap(this PriorityCreateRequest request)
        {

            return new Priority
            {
                Definition = request.Definition,
            };
        }

        public static AppTask ToMap(this AppTaskCreateRequest request)
        {
            return new AppTask
            {
                Description = request.Description,
                Title = request.Title,
                PriorityId = request.PriorityId,
                State = false
            };
        }

        public static AppTaskListDto ToMap(this AppTask appTask)
        {
            return new AppTaskListDto(appTask.Id, appTask.Title, appTask.Description, appTask?.Priority?.Definition, appTask?.State ?? false, appTask.AppUserId, appTask.AppUserId.HasValue ? appTask.AppUser?.Name + " " + appTask.AppUser?.Surname : null, appTask.PriorityId);
        }

        public static List<MemberListDto> ToMap(this List<AppUser> users)
        {
            return users.Select(x => new MemberListDto(x.Id, x.Name, x.Surname, x.Username)).ToList();
        }

    }

}
