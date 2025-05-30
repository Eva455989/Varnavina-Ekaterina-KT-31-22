using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;
using varnavina_ekaterina_kt_31_22.Models;

public class DisciplineTests
{
    //проверяет корректность создания объекта Discipline.
    [Fact]
    public void Discipline_Creation_ValidData()
    {

        var discipline = new Discipline
        {
            DisciplineName = "Математика",
            TeacherId = 1
        };


        Assert.NotNull(discipline);
        Assert.Equal("Математика", discipline.DisciplineName);
        Assert.Equal(1, discipline.TeacherId);
        Assert.False(discipline.IsDeleted);
    }
    //проверяет можно ли изменить свойство IsDeleted на true
    [Fact]
    public void Discipline_SetIsDeleted_True()
    {
        var discipline = new Discipline();

        discipline.IsDeleted = true;

        Assert.True(discipline.IsDeleted);
    }
}
