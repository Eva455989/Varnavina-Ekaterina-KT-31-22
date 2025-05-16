using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.DepartmentName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(d => d.FoundedDate) // Теперь это свойство существует
                   .IsRequired();
            builder.Property(d => d.IsDeleted)
                   .HasDefaultValue(false);
            builder.HasOne(d => d.Head) // Исправлено с HeadTeacher на Head
                   .WithMany()
                   .HasForeignKey(d => d.HeadId) // Исправлено с HeadTeacherId на HeadId
                   .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Departments");
        }
    }
}
