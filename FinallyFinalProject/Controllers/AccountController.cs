using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
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
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Admin", "UserImages");
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
                UserName=registerVModel.UserName,
                Email = registerVModel.Email, 
                Role = "Member",
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
            await userManager.AddToRoleAsync(user, "Member");

            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            
            mail.From = new MailAddress("hajimatfa@code.edu.az", "Kenan999");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Verify Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/Admin/Template/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            string about = $"Welcome <strong>{user.FirstName + " " + user.LastName}</strong> please click the link in below";

            body = body.Replace("{{link}}", link);
            mail.Body = body.Replace("{{About}}", about);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;            
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hajimatfa@code.edu.az", "Tovelo999");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(mail);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            await userManager.ConfirmEmailAsync(user, token);

            await signInManager.SignInAsync(user, true);
            

            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public JsonResult ShowLogin()
        {
            return Json(User.Identity.IsAuthenticated);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(AccountVM account)
        {
            AppUser user = await userManager.FindByEmailAsync(account.AppUser.Email);
            if (user == null) return BadRequest();

            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("hajimatfa@code.edu.az", "Kenan999");
            mail.To.Add(new MailAddress(user.Email));

            mail.Subject = "Reset Password";
            mail.Body = $"<a href='{link}'>Please click here to reset your password</a>";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("hajimatfa@code.edu.az", "Tovelo999");
            smtp.Send(mail);
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = token
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(AccountVM account)
        {
            AppUser user = await userManager.FindByEmailAsync(account.AppUser.Email);
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = account.Token
            };
            if (!ModelState.IsValid) return View(model);
            IdentityResult result = await userManager.ResetPasswordAsync(user, account.Token, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }
            await signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }     

    }
}
