using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace varnavina_ekaterina_kt_31_22.Models.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.HasKey(l => l.LoadId);
            builder.Property(l => l.Hours)
                   .IsRequired();
            builder.HasOne(l => l.Teacher)
                   .WithMany(t => t.Loads)
                   .HasForeignKey(l => l.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.Discipline)
                   .WithMany()
                   .HasForeignKey(l => l.DisciplineId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(l => l.IsDeleted)
                   .HasDefaultValue(false);
            builder.ToTable("Loads");
        }
    }
}
