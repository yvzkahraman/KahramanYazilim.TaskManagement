using KahramanYazilim.TaskManagement.Domain.Entities;
using KahramanYazilim.TaskManagement.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KahramanYazilim.TaskManagement.Persistance.Context
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }

        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TaskReport> TaskReports { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppTaskConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskReportConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}



