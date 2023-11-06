using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Domain.Entities
{
    public class TaskReport : BaseEntity
    {
    
        public string Definition { get; set; } = null!;

        public string Detail { get; set; } = null!;

        public int AppTaskId { get; set; }

        public AppTask? AppTask { get; set; }
    }
}
