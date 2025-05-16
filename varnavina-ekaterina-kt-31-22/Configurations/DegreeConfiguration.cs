using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.HasKey(d => d.DegreeId);
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(d => d.IsDeleted)
                   .HasDefaultValue(false);
            builder.ToTable("Degrees");
        }
    }
}
