using FinallyFinalProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Comment:BaseEntity
    {
        [Required, StringLength(maximumLength: 90)]
        public string Text { get; set; }

        public int ProductId { get; set; }
        public bool Status { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
