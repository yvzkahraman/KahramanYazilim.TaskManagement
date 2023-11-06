using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Description { get; set; } = null!;
        public bool State { get; set; }

        public int AppUserId { get; set; }

        #region Navigation Properties
        public AppUser? AppUser { get; set; }
        #endregion

    }
}
