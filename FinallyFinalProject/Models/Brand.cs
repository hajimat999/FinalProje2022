using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Brand:BaseEntity
    {
        [Required, StringLength(maximumLength: 20)]
        public string BrandName { get; set; }
        public List<Product> Products { get; set; }
    }
}
