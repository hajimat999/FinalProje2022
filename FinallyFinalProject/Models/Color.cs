using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Color:BaseEntity
    {
        [Required, StringLength(maximumLength: 20)]
        public string ColorName { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        
        
    }
}
