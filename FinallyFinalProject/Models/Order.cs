using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Order :BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public bool? Status { get; set; }
        [Required]
        public bool Deliver { get; set; } = false;
        public string Country { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string ApartmentAddress { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
