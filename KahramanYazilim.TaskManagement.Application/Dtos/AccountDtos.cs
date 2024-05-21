using KahramanYazilim.TaskManagement.Application.Enums;

namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record LoginResponseDto(string Name, string Surname, RoleType Role);
}
