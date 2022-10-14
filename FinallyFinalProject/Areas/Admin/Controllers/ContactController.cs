using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext context;

        public ContactController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = context.Contacts.ToList();
            return View(contacts);
        }
        public IActionResult Delete(int? id)
        {
            Contact contact = context.Contacts.FirstOrDefault(x => x.Id == id);
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
