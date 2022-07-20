using Microsoft.EntityFrameworkCore;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infrastructure.Dal
{
    public class TimeSheetContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Role> Role { get; set; }

        public TimeSheetContext(DbContextOptions<TimeSheetContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasOne(d => d.Role)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Activity_RoleId");

                entity.HasOne(d => d.Project)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Activity_ProjectId");

                entity.HasOne(d => d.ActivityType)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityTypeId)
                .HasConstraintName("FK_Activity_ActivityTypeId");

                entity.HasOne(d => d.Employee)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Activity_EmployeeId");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
