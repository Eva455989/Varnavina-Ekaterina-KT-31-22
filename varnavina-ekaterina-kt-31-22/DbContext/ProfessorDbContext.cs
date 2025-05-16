using Microsoft.EntityFrameworkCore;
using varnavina_ekaterina_kt_31_22.Models;
using varnavina_ekaterina_kt_31_22.Models.Configurations;

namespace varnavina_ekaterina_kt_31_22.Data
{
    public class ProfessorDbContext : DbContext
    {
        // Добавляем таблицы
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Load> Loads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
        }

        public ProfessorDbContext(DbContextOptions<ProfessorDbContext> options) : base(options)
        {
        }
    }
}
