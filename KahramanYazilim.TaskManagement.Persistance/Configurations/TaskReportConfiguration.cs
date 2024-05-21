using KahramanYazilim.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KahramanYazilim.TaskManagement.Persistance.Configurations
{
    public class TaskReportConfiguration : IEntityTypeConfiguration<TaskReport>
    {
        public void Configure(EntityTypeBuilder<TaskReport> builder)
        {
            builder.Property(x => x.Detail).IsRequired(true);

            builder.Property(x => x.Definition).IsRequired(true);
            builder.Property(x => x.Definition).HasMaxLength(250);

            builder.Property(x => x.AppTaskId).IsRequired(true);
        }
    }
}
