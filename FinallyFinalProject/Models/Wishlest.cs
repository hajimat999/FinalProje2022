using FinallyFinalProject.Models.Base;

namespace FinallyFinalProject.Models
{
    public class Wishlest : BaseEntity
    {
        public string WishlestItem { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Quantity { get; set; }

    }
}
