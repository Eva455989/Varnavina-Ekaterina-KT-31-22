using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(d => d.DisciplineId);
            builder.Property(d => d.DisciplineName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(d => d.IsDeleted)
                   .HasDefaultValue(false);
            builder.ToTable("Disciplines");
        }
    }
}
