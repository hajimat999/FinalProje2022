using FinallyFinalProject.Models.Base;

namespace FinallyFinalProject.Models
{
    public class OrderItem : BaseEntity
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int? OrderId { get; set; }
        public Product Product { get; set; }
        public AppUser User { get; set; }
        
        public Order Order { get; set; }
    }
}
