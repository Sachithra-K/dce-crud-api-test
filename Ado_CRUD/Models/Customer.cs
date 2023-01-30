using System.ComponentModel.DataAnnotations;

namespace Ado_CRUD.Models
{
    public class Customer
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CreateOn { get; set; }
        public bool IsActive { get; set; }
    }
}
