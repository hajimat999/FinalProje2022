using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class DiscountAmount:BaseEntity
    {
        [Required]
        public decimal Amount { get; set; }
        List<Product> Products { get; set; }
    }
}
