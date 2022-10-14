using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinallyFinalProject.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<Order> Orders { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }

        public List<Wishlest> Wishlests { get; set; }
    }
}
