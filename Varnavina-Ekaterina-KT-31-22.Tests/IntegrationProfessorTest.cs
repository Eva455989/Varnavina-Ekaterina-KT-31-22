using Microsoft.EntityFrameworkCore;
using varnavina_ekaterina_kt_31_22.Data;
using varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces;
using varnavina_ekaterina_kt_31_22.Models;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

public class IntegrationProfessorTests
{
    private DbContextOptions<ProfessorDbContext> _dbContextOptions;

    //Создаёт настройки для in-memory базы данных
    public IntegrationProfessorTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<ProfessorDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

    }
    //Добавление нового профессора в базу данных через сервис.
    [Fact]
    public async Task AddProfessor_Should_Add_Professor_To_Database()
    {
        using var context = new ProfessorDbContext(_dbContextOptions);
        var professorService = new TeacherService(context);
        var professor = new Professor { FirstName = "Марина", LastName = "Михайлова" };

        await professorService.AddAsync(professor);
        await context.SaveChangesAsync(); 

        Assert.Equal(1, await context.Teachers.CountAsync());
        var addedProfessor = await context.Teachers.FirstOrDefaultAsync();

        // Проверка на null перед доступом к свойствам
        Assert.NotNull(addedProfessor);
        Assert.Equal("Марина", addedProfessor.FirstName);
        Assert.Equal("Михайлова", addedProfessor.LastName);
    }
    //Получение всех профессоров из базы.
    [Fact]
    public async Task GetProfessors_Should_Return_All_Professors()
    {
        using var context = new ProfessorDbContext(_dbContextOptions);
        var professorService = new TeacherService(context);

        // Очистка базы данных перед добавлением новых данных
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var professors = new List<Professor>
        {
            new Professor { FirstName = "Марина", LastName = "Михайлова"},
            new Professor { FirstName = "Сергей", LastName = "Смирнов" }
        };
        await context.Teachers.AddRangeAsync(professors);
        await context.SaveChangesAsync();

        var result = await professorService.GetAllAsync();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.FirstName == "Марина" && p.LastName == "Михайлова");
        Assert.Contains(result, p => p.FirstName == "Сергей" && p.LastName == "Смирнов");
    }
}
