using FinallyFinalProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinallyFinalProject.Models
{
    public class Product:BaseEntity
    {
        [Required, StringLength(maximumLength: 20)]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Rating { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Description { get; set; }
        public bool OnSale { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public int InformationId { get; set; }
        public Information Information { get; set; }
        [Required]
        public int DiscountAmountId { get; set; }
        public DiscountAmount DiscountAmount { get; set; }
        public int OrderCount { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Wishlest> Wishlests { get; set; }
        public List<Rating> Ratings { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }

        [NotMapped]
        public List<int> ColorIds { get; set; }
        [NotMapped]
        public IFormFile MainPhoto { get; set; }
        [NotMapped]
        public IFormFile HoverPhoto { get; set; }

    }
}
