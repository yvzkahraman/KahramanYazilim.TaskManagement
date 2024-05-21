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
    }
}
