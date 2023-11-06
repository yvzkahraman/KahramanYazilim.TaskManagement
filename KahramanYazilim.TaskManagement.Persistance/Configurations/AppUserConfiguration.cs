using KahramanYazilim.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.Surname).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(200);

            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(200);


            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.Property(x => x.Username).HasMaxLength(200);
            builder.Property(x => x.Username).IsRequired(true);

            builder.Property(x => x.AppRoleId).IsRequired(true);

            builder.HasMany(x => x.Tasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Notifications).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);


        }
    }
}
