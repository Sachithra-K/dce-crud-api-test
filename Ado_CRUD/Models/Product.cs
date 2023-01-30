using System.ComponentModel.DataAnnotations;

namespace Ado_CRUD.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
