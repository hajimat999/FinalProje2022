using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinallyFinalProject.DAL;
using System.Linq;
using FinallyFinalProject.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }
        public IActionResult Index()
        {
            List<AppUser> appUsers = context.Users.Where(u => u.Role.Contains("Admin")).ToList();
            return View(appUsers);
        }
        public IActionResult CreateAdmin()
        {           
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateAdmin(RegisterVModel registerVModel)
        {          
            
            if (!ModelState.IsValid) return View();
            if (registerVModel.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please, choose image");
                return View();
            }
            if (registerVModel.Photo.ContentType == null || !registerVModel.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Please, enter correct image");
                return View();
            }
            if (registerVModel.Photo.Length / 1024 / 1024 > 2)
            {
                ModelState.AddModelError("Photo", "Please, enter correct image");
                return View();
            }
            string fileName = string.Concat(Guid.NewGuid(), registerVModel.Photo.FileName);
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Admin", "AdminImages");
            string filePath = Path.Combine(path, fileName);

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await registerVModel.Photo.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }
            AppUser user = new AppUser
            {
                FirstName = registerVModel.FirstName,
                LastName = registerVModel.LastName,
                UserName = registerVModel.UserName,
                Email = registerVModel.Email,
                Role = "Admin",
                Image = fileName

            };
            IdentityResult result = await userManager.CreateAsync(user, registerVModel.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Admin", "Admin");

        }

        public async Task<IActionResult> Update(string id)
        {
            if (id is null) return NotFound();
            AppUser appUser = await context.Users.FirstOrDefaultAsync(u =>u.Id==id);
            if (appUser is null) return NotFound();
            return View(appUser);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id, RegisterVModel registerVModel)
        {

            AppUser existed = await context.Users.FindAsync(id);
            if (existed is null) return NotFound();
            if (!ModelState.IsValid) return View(existed);


            if (registerVModel.Photo == null)
            {
                string filename = existed.Image;
                
                context.Entry(existed).CurrentValues.SetValues(registerVModel);
                existed.Image = filename;
                


            }
            else
            {
                if (registerVModel.Photo.ContentType == null || !registerVModel.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Please, enter correct image");
                    return View(existed);
                }
                if (registerVModel.Photo.Length / 1024 / 1024 > 2)
                {
                    ModelState.AddModelError("Photo", "Please, enter correct image");
                    return View(existed);
                }


                string fileName = string.Concat(Guid.NewGuid(), registerVModel.Photo.FileName);
                string path = Path.Combine(webHostEnvironment.WebRootPath, "Admin", "AdminImages");
                string filePath = Path.Combine(path, fileName);
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await registerVModel.Photo.CopyToAsync(stream);
                    }
                }
                catch (Exception)
                {

                    throw new FileLoadException();
                }

                FileValidator.FileDelete(webHostEnvironment.WebRootPath, "Admin/AdminImages", existed.Image);
                
                context.Entry(existed).CurrentValues.SetValues(registerVModel);
                existed.Image = fileName;        

            }
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await context.Users.FindAsync(id);
            if (user == null) return NotFound();
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "Admin/AdminImages", user.Image);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
