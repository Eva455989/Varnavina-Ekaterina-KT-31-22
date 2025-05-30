using System.Collections.Generic;
using System.Linq;
using Xunit;
using varnavina_ekaterina_kt_31_22.Models;



public class ProfessorTests
{
    //Правильность присвоения и получения свойства FirstName у объекта Professor
    [Fact]
    public void Professor_Should_Have_Valid_FirstName()
    {

        var professor = new Professor { FirstName = "Иван", LastName = "Петров" };


        var result = professor.FirstName;


        Assert.Equal("Иван", result);
    }

    //Правильность присвоения и получения свойства LastName у объекта Professor

    [Fact]
    public void Professor_Should_Have_Valid_LastName()
    {
        var professor = new Professor { FirstName = "Иван", LastName = "Петров"};

        var result = professor.LastName;

        Assert.Equal("Петров", result);
    }
    //проверяет что новый объект Professor изначально не помечен как удалённый
        [Fact]
    public void Professor_Should_Be_Initially_Not_Deleted()
    {
        var professor = new Professor();

        var result = professor.IsDeleted;

        Assert.False(result);
    }
}
