using Microsoft.EntityFrameworkCore;
namespace varnavina_ekaterina_kt_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int HeadId { get; set; }
        public Teacher Head { get; set; } // Исправлено с HeadTeacher на Head
        public DateTime FoundedDate { get; set; } // Добавлено свойство FoundedDate
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }
}
