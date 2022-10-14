using FinallyFinalProject.Models.Base;

namespace FinallyFinalProject.Models
{
    public class ProductImage :BaseEntity
    {
        public string Name { get; set; }
        public string Alternative { get; set; }
        public bool? IsMain { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
