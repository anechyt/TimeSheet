using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Domain.Entities;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Infrastructure.Dal.Configuration
{
    public class RoleConfiguratin : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(36);
        }
    }
}
