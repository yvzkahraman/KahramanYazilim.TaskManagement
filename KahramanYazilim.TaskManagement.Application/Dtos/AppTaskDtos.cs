namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record AppTaskListDto(int Id, string Title, string Description, string? PriorityDefinition, bool State);
}
