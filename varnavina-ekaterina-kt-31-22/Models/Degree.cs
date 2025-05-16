using Microsoft.EntityFrameworkCore;
namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }
}
