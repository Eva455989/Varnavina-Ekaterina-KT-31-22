using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Discipline>> GetDisciplinesFilteredAsync(int? teacherId, int? minLoad, int? maxLoad);
    }

    // 1.	Получение списка дисциплин (учесть фильтрацию по преподавателю, по диапазону в нагрузке – например выводить дисциплины с
    // нагрузкой от 20 до 30 часов за семестр)
    public class SubjectService : ISubjectService
    {
        private readonly ProfessorDbContext _context;

        public SubjectService(ProfessorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesFilteredAsync(int? teacherId, int? minLoad, int? maxLoad)
        {
            var query = _context.Disciplines
                .Where(d => !d.IsDeleted) // Убедитесь, что это условие присутствует
                .AsQueryable();

            if (teacherId.HasValue)
            {
                query = query.Where(d => d.TeacherId == teacherId.Value);
            }

            var disciplinesWithLoad = await query
                .Select(d => new
                {
                    Discipline = d,
                    TotalLoad = d.Loads.Where(l => !l.IsDeleted).Sum(l => (int?)l.Hours) ?? 0
                })
                .ToListAsync();

            if (minLoad.HasValue)
            {
                disciplinesWithLoad = disciplinesWithLoad.Where(x => x.TotalLoad >= minLoad.Value).ToList();
            }

            if (maxLoad.HasValue)
            {
                disciplinesWithLoad = disciplinesWithLoad.Where(x => x.TotalLoad <= maxLoad.Value).ToList();
            }

            return disciplinesWithLoad.Select(x => x.Discipline).ToList();
        }


    }
}
