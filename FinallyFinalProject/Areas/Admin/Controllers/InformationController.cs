using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class InformationController : Controller
    {
        private readonly ApplicationDbContext context;

        public InformationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Information> informations = context.Informations.ToList();
            return View(informations);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Information information)
        {
            if (!ModelState.IsValid) return View();
            Information existed = await context.Informations.FirstOrDefaultAsync(b => b.ReturnRequest.ToLower().Trim() == information.ReturnRequest.ToLower().Trim());
            if (existed != null)
            {
                ModelState.AddModelError("ReturnRequest", "You cannot duplicate name");
                return View();
            }
            information.CreatedAt = DateTime.Now;
            information.UpdateAt = DateTime.Now;
            await context.Informations.AddAsync(information);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            Information information = await context.Informations.FirstOrDefaultAsync(b => b.Id == id);
            if (information is null) return NotFound();
            return View(information);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Information information)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            Information existed = await context.Informations.FirstOrDefaultAsync(b => b.Id == id);
            if (existed == null) return NotFound();
            bool duplicate = context.Informations.Any(c => c.ReturnRequest.Trim().ToLower() == information.ReturnRequest.Trim().ToLower());
            if (duplicate)
            {
                ModelState.AddModelError("ReturnRequest", "You cannot duplicate name");
                return View();
            }

            existed.ReturnRequest = information.ReturnRequest;
            existed.Guarantee = information.Guarantee;
            existed.Shipping = information.Shipping;
            existed.Key = information.Key;
            existed.UpdateAt = DateTime.Now;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            Information information = await context.Informations.FindAsync(id);
            if (information is null) return NotFound();

            context.Informations.Remove(information);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
