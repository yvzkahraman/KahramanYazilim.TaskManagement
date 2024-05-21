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
