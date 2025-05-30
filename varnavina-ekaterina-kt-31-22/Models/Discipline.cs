using Microsoft.EntityFrameworkCore;
namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int TeacherId { get; set; }
        public Professor Teacher { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft-delete
        public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
    }
}
