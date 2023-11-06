using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Dtos
{
    public record Result<T>(T data, bool IsSuccess, string ErrorMessage);
    public record NoData();
}
