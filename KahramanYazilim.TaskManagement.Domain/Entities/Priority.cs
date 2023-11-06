using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Domain.Entities
{
    public class Priority : BaseEntity
    {
    
        public string Definition { get; set; } = null!;

        #region Navigation Properties
        public List<AppTask>? Tasks { get; set; }
        #endregion

    }
}
