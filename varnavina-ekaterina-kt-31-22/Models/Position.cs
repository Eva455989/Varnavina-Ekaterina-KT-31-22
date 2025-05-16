using Microsoft.EntityFrameworkCore;
namespace varnavina_ekaterina_kt_31_22.Models

{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft-delete
    }
}
