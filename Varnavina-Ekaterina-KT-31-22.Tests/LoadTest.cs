using System.Collections.Generic;
using System.Linq;
using Xunit;
using varnavina_ekaterina_kt_31_22.Models;

public class LoadTests
{
    //проверяет создание объекта Load с правильными значениями
        [Fact]
    public void Load_Creation_ValidData()
    {

        var load = new Load
        {
            Hours = 30,
            TeacherId = 1,
            DisciplineId = 1
        };


        Assert.NotNull(load);
        Assert.Equal(30, load.Hours);
        Assert.Equal(1, load.TeacherId);
        Assert.Equal(1, load.DisciplineId);
        Assert.False(load.IsDeleted);
    }

    //проверяет можно ли установить свойство IsDeleted в true
    [Fact]
    public void Load_SetIsDeleted_True()
    {

        var load = new Load();

        load.IsDeleted = true;

        Assert.True(load.IsDeleted);
    }
}
