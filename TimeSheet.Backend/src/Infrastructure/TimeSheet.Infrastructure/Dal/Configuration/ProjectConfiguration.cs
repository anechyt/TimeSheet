using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Infrastructure.Dal.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasConversion(e => e.Value, e => new Name(e))
                .IsRequired()
                .HasMaxLength(36);
        }
    }
}
