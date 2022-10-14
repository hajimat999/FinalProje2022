using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class ColorController : Controller
    {
        private readonly ApplicationDbContext context;

        public ColorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Color> colors = context.Colors.ToList();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Color color)
        {
            if (!ModelState.IsValid) return View();
            Color existed = await context.Colors.FirstOrDefaultAsync(b => b.ColorName.ToLower().Trim() == color.ColorName.ToLower().Trim());
            if (existed != null)
            {
                ModelState.AddModelError("ColorName", "You can not duplicate category name");
                return View();
            }
            color.CreatedAt = DateTime.Now;
            color.UpdateAt = DateTime.Now;
            await context.Colors.AddAsync(color);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            Color color = await context.Colors.FirstOrDefaultAsync(b => b.Id == id);
            if (color is null) return NotFound();
            return View(color);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Color newColor)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            Color existed = await context.Colors.FirstOrDefaultAsync(b => b.Id == id);
            if (existed == null) return NotFound();
            bool duplicate = context.Colors.Any(c => c.ColorName.Trim().ToLower() == newColor.ColorName.Trim().ToLower());
            if (duplicate)
            {
                ModelState.AddModelError("ColorName", "You cannot duplicate name");
                return View();
            }

            existed.ColorName = newColor.ColorName;
            existed.UpdateAt = DateTime.Now;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            Color color = await context.Colors.FindAsync(id);
            if (color is null) return NotFound();

            context.Colors.Remove(color);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
