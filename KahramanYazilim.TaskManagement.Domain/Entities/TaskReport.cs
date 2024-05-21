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
