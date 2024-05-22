using KahramanYazilim.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Interfaces
{
    public interface IPriorityRepository
    {
        Task<List<Priority>> GetAllAsync();
    }
}
