using Microsoft.EntityFrameworkCore;
namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Professor
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Department>? Departments { get; set; }
        public ICollection<Discipline>? Disciplines { get; set; }
        public ICollection<Load>? Loads { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }

}
