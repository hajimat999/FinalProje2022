using FinallyFinalProject.Models.Base;

namespace FinallyFinalProject.Models
{
    public class Rating : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int Point { get; set; }
    }
}
