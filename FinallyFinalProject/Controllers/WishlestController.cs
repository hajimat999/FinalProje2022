using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class WishlestController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public WishlestController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || id == 0) return View();
            Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                Wishlest wishlest = await context.Wishlests.FirstOrDefaultAsync(w => w.ProductId == id);
                if (wishlest == null)
                {
                    wishlest = new Wishlest
                    {
                        WishlestItem = product.Model,
                        Product = product,
                        ProductId = product.Id,
                        UserId = user.Id,
                        User = user,
                        Quantity = 1
                    };
                    await context.Wishlests.AddAsync(wishlest);
                }
                else
                {
                    wishlest.Quantity++;
                }

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Delete(int? id)
        {
            if(id==0 || id is null)
            {
                return View();
            }
            Wishlest wishlest = context.Wishlests.FirstOrDefault(w => w.ProductId == id);
            if(wishlest == null)
            {
                return View();
            }
            context.Wishlests.Remove(wishlest);
            context.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        
    }
}
