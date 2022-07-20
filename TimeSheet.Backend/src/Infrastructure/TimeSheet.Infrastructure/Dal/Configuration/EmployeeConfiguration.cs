using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Infrastructure.Dal.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasConversion(e => e.Value, e => new Name(e))
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(e => e.Sex)
                .HasConversion(e => e.Value, e => new Sex(e))
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(e => e.Birthday)
                .IsRequired();
        }
    }
}
