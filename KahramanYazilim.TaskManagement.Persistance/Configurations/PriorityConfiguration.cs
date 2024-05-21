using KahramanYazilim.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KahramanYazilim.TaskManagement.Persistance.Configurations
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.Property(x => x.Definition).IsRequired(true);
            builder.Property(x => x.Definition).HasMaxLength(250);


            builder.HasMany(x => x.Tasks).WithOne(x => x.Priority).HasForeignKey(x => x.PriorityId);
        }
    }
}
