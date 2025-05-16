using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId);
            builder.Property(p => p.PositionName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false);
            builder.ToTable("Positions");
        }
    }
}
