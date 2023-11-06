using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Domain.Entities
{
    public class AppRole : BaseEntity
    {
     
        public string Definition { get; set; } = null!;

        #region Navigation Properties
        public List<AppUser>? Users { get; set; }
        #endregion

    }
}
