namespace KahramanYazilim.TaskManagement.Domain.Entities
{

    //FLUENT API 
    public class AppTask : BaseEntity
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int? AppUserId { get; set; }

        public int PriorityId { get; set; }


        // Lookup 
        public bool State { get; set; }

        #region NavigationProperties
        public AppUser? AppUser { get; set; }

        public Priority? Priority { get; set; }

        public List<TaskReport> TaskReports { get; set; }
        #endregion


    }
}
