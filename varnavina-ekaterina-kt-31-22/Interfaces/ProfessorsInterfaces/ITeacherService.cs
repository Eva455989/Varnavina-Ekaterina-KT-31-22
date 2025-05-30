using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Professor>> GetAllAsync();
        Task<Professor?> GetByIdAsync(int id);
        Task<Professor> AddAsync(Professor teacher);
        Task<Professor?> UpdateAsync(Professor teacher);
        Task<bool> SoftDeleteAsync(int id);
    }
    //6.	Добавление/изменение удаление преподавателей
    public class TeacherService : ITeacherService
    {
        private readonly ProfessorDbContext _context;

        public TeacherService(ProfessorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _context.Teachers
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Where(t => !t.IsDeleted && t.TeacherId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Professor> AddAsync(Professor teacher)
        {
            teacher.IsDeleted = false;
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Professor?> UpdateAsync(Professor teacher)
        {
            var existing = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId && !t.IsDeleted);
            if (existing == null) return null;

            existing.FirstName = teacher.FirstName;
            existing.LastName = teacher.LastName;
            

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var existing = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == id && !t.IsDeleted);
            if (existing == null) return false;

            existing.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
