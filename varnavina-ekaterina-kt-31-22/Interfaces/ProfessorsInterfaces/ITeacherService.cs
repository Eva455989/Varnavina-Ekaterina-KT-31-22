using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task<Teacher?> UpdateAsync(Teacher teacher);
        Task<bool> SoftDeleteAsync(int id);
    }

    public class TeacherService : ITeacherService
    {
        private readonly ProfessorDbContext _context;

        public TeacherService(ProfessorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Where(t => !t.IsDeleted && t.TeacherId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            teacher.IsDeleted = false;
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher?> UpdateAsync(Teacher teacher)
        {
            var existing = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId && !t.IsDeleted);
            if (existing == null) return null;

            existing.FirstName = teacher.FirstName;
            existing.LastName = teacher.LastName;
            // Можно добавить обновление других свойств при необходимости

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
