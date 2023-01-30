namespace Ado_CRUD.Models
{
    public class CustomerRelatedData
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CreateOn { get; set; }
        public bool IsActive { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int OrderBy { get; set; }
        public string? OrderedOn { get; set; }
        public string? SippedOn { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? SupplierName { get; set; }
    } 
}
