using Microsoft.EntityFrameworkCore;
using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces;
using varnavina_ekaterina_kt_31_22.Models;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IntegrationDisciplineTests
{
    private readonly DbContextOptions<ProfessorDbContext> _dbContextOptions;

    public IntegrationDisciplineTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<ProfessorDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
    }
    //Корректность фильтрации дисциплин по TeacherId.
    [Fact]
    public async Task GetDisciplinesFilteredAsync_WithTeacherId_ReturnsFilteredDisciplines()
    {
        using var context = new ProfessorDbContext(_dbContextOptions);
        var subjectService = new SubjectService(context);

        var teacherId = 1;
        var disciplines = new List<Discipline>
        {
            new Discipline { DisciplineName = "Математика", TeacherId = teacherId, IsDeleted = false },
            new Discipline { DisciplineName = "Физика", TeacherId = teacherId, IsDeleted = false },
            new Discipline { DisciplineName = "Химия", TeacherId = 2, IsDeleted = false }
        };

        await context.Disciplines.AddRangeAsync(disciplines);
        await context.SaveChangesAsync();

        // Добавляем нагрузки с правильными DisciplineId
        var loads = new List<Load>
        {
            new Load { Hours = 30, TeacherId = teacherId, DisciplineId = disciplines[0].DisciplineId, IsDeleted = false },
            new Load { Hours = 20, TeacherId = teacherId, DisciplineId = disciplines[1].DisciplineId, IsDeleted = false },
            new Load { Hours = 15, TeacherId = 2, DisciplineId = disciplines[2].DisciplineId, IsDeleted = false }
        };

        await context.Loads.AddRangeAsync(loads);
        await context.SaveChangesAsync();

        var result = await subjectService.GetDisciplinesFilteredAsync(teacherId, null, null);

        Assert.Equal(2, result.Count());
        Assert.Contains(result, d => d.DisciplineName == "Математика");
        Assert.Contains(result, d => d.DisciplineName == "Физика");
    }


    //Возврат всех дисциплин, если фильтр по учителю не задан.
    [Fact]
    public async Task GetDisciplinesFilteredAsync_NoTeacherId_ReturnsAllDisciplines()
    {
        using var context = new ProfessorDbContext(_dbContextOptions);
        var subjectService = new SubjectService(context);

        var disciplines = new List<Discipline>
        {
            new Discipline { DisciplineName = "Математика", TeacherId = 1, IsDeleted = false },
            new Discipline { DisciplineName = "Физика", TeacherId = 2, IsDeleted = false }
        };

        await context.Disciplines.AddRangeAsync(disciplines);
        await context.SaveChangesAsync();

        var result = await subjectService.GetDisciplinesFilteredAsync(null, null, null);

        Assert.Equal(2, result.Count());
        Assert.Contains(result, d => d.DisciplineName == "Математика");
        Assert.Contains(result, d => d.DisciplineName == "Физика");
    }
    //Успешное добавление дисциплины в базу данных.
    [Fact]
    public async Task AddDiscipline_Success()
    {
        using var context = new ProfessorDbContext(_dbContextOptions);
        var subjectService = new SubjectService(context);
        var discipline = new Discipline { DisciplineName = "Физика", TeacherId = 1 };


        await context.Disciplines.AddAsync(discipline);
        await context.SaveChangesAsync();

        var result = await context.Disciplines.FindAsync(discipline.DisciplineId);
        Assert.NotNull(result);
        Assert.Equal("Физика", result.DisciplineName);
    }
}
