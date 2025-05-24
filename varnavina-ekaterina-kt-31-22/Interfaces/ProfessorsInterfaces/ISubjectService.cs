using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Discipline>> GetDisciplinesFilteredAsync(int? teacherId, int? minLoad, int? maxLoad);
    }

    // Реализация интерфейса в том же файле (по условию лабораторной)
    public class SubjectService : ISubjectService
    {
        private readonly ProfessorDbContext _context;

        public SubjectService(ProfessorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesFilteredAsync(int? teacherId, int? minLoad, int? maxLoad)
        {
            // Запрос дисциплин, учитывая soft-delete
            var query = _context.Disciplines
                .Where(d => !d.IsDeleted)
                .AsQueryable();

            if (teacherId.HasValue)
            {
                query = query.Where(d => d.TeacherId == teacherId.Value);
            }

            // Получаем нагрузки по дисциплинам
            var disciplinesWithLoad = await query
                .Select(d => new
                {
                    Discipline = d,
                    TotalLoad = d.Loads.Where(l => !l.IsDeleted).Sum(l => (int?)l.Hours) ?? 0
                })
                .ToListAsync();

            // Фильтрация по диапазону нагрузки
            if (minLoad.HasValue)
                disciplinesWithLoad = disciplinesWithLoad.Where(x => x.TotalLoad >= minLoad.Value).ToList();

            if (maxLoad.HasValue)
                disciplinesWithLoad = disciplinesWithLoad.Where(x => x.TotalLoad <= maxLoad.Value).ToList();

            return disciplinesWithLoad.Select(x => x.Discipline).ToList();
        }
    }
}
