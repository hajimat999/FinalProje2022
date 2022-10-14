using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Migrations;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =("Admin"))]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController( UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVModel registerVModel)
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
                Role="Admin",
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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVModel loginVModel)
        {

            if (!ModelState.IsValid) return View();

            AppUser user = await userManager.FindByNameAsync(loginVModel.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginVModel.Password, loginVModel.RememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "You have been blocked about 10 minutes");
                    return View();
                }

                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }
            return RedirectToAction("Index", "Dashboard", "Admin");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Dashboard", "Admin");
        }
        public JsonResult ShowLogin()
        {
            return Json(User.Identity.IsAuthenticated);
        }
    }
}
