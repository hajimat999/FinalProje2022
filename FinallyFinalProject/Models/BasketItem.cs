using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinallyFinalProject.Models
{
    public class BasketItem :BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }  
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [NotMapped]
        public List<Color> Colors { get; set; }
        public string ColorName { get; set; }
    }
}
