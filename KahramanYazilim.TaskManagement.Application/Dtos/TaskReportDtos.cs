using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record TaskReportListDto(int Id, string Definition, string Detail, int AppTaskId, string? AppTask);

}
