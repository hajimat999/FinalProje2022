using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public ContactController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact message)
        {
            if (!ModelState.IsValid) return View();
            if(message.Look == false)
            {
                ModelState.AddModelError("Look", "Please, agree with it");
                return View();
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                Contact contact = new Contact
                {
                    Look = message.Look,
                    CreatedAt = DateTime.Now,
                    Subject = message.Subject,
                    Email = user.Email,
                    Name = user.UserName,
                    Date = DateTime.Now,
                };
                await context.Contacts.AddAsync(contact);
            }
            else
            {
                ModelState.AddModelError("", "Please, Log In");
                return View();
            }
            
            
            await context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
