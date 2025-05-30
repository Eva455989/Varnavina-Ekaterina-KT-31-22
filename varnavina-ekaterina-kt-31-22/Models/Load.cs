using Microsoft.EntityFrameworkCore;

namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public int Hours { get; set; }
        public int TeacherId { get; set; }
        public Professor Teacher { get; set; }
        public int DisciplineId { get; set; } 
        public Discipline Discipline { get; set; } 
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }
}
