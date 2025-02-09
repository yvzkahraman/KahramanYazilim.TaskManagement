using KahramanYazilim.TaskManagement.Domain.Entities;

namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record AppTaskListDto(int Id, string Title, string Description, string? PriorityDefinition, bool State, int? AppUserId, string? AppUserFullname, int PriorityId);

    public record AppTaskDto(List<PriorityListDto> Priorities, List<AppUser>? Employees = null);

}
