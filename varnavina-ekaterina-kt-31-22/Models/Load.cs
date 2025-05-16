using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public int Hours { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; } // Добавлено свойство DisciplineId
        public Discipline Discipline { get; set; } // Навигационное свойство для Discipline
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }
}
