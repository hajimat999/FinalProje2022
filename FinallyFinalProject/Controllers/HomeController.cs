using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            
            HomeVM homeVM = new HomeVM
            {
                Sliders =await context.Sliders.ToListAsync(),
                Settings =await context.Settings.ToListAsync(),
                Products =await context.Products.Include(c => c.ProductImages).ToListAsync()          
            };
            return View(homeVM);
        }
    }
}
