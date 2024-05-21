using KahramanYazilim.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KahramanYazilim.TaskManagement.Persistance.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).IsRequired(true);
            builder.Property(x => x.Definition).HasMaxLength(150);


            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.AppRoleId);
        }
    }
}
