using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Migrations;
using FinallyFinalProject.Models;
using FinallyFinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<AppUser> users = context.Users.Where(u=>u.Role.Contains("Member")).ToList();
            
            return View(users);
        }
       

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await context.Users.FindAsync(id);
            if(user == null) return NotFound();
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "Admin/UserImages", user.Image);

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
