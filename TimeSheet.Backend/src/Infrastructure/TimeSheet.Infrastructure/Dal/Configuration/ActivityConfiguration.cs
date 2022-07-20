using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Infrastructure.Dal.Configuration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProjectId)
                .IsRequired();
            builder.Property(x => x.RoleId)
                .IsRequired();
            builder.Property(x => x.ActivityTypeId)
                .IsRequired();
            builder.Property(x => x.EmployeeId)
                .IsRequired();
        }
    }
}
