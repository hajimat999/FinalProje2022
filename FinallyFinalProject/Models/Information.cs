using FinallyFinalProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Information:BaseEntity
    {
        public int Key { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Shipping { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string ReturnRequest { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Guarantee { get; set; }
        public List<Product> Products { get; set; }
    }
}
