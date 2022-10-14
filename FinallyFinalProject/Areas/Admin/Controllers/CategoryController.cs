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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await context.Categories.ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            Category existed =await context.Categories.FirstOrDefaultAsync(c => c.CategoryName.ToLower().Trim() == category.CategoryName.ToLower().Trim());
            if (existed != null)
            {
                ModelState.AddModelError("CategoryName", "You can not duplicate category name");
                return View();
            }
            category.CreatedAt = DateTime.Now;
            category.UpdateAt = DateTime.Now;
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int? id, Category newCategory)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            Category existed = context.Categories.FirstOrDefault(c => c.Id == id);
            if (existed == null) return NotFound();
            bool duplicate = context.Categories.Any(c => c.CategoryName.Trim().ToLower() == newCategory.CategoryName.Trim().ToLower());
            if (duplicate)
            {
                ModelState.AddModelError("CategoryName", "You cannot duplicate name");
                return View();
            }

            existed.CategoryName = newCategory.CategoryName;
            existed.UpdateAt = DateTime.Now;
            
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            Category category = await context.Categories.FindAsync(id);
            if (category is null) return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
