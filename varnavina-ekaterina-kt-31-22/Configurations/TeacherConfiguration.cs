using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);
            builder.Property(t => t.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(t => t.LastName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(t => t.IsDeleted)
                   .HasDefaultValue(false);
            builder.ToTable("Teachers");
        }
    }
}
