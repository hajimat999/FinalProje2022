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
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext context;

        public BrandController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Brand> brands = context.Brands.ToList();
            return View(brands);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid) return View();
            Brand existed = await context.Brands.FirstOrDefaultAsync(b => b.BrandName.ToLower().Trim() == brand.BrandName.ToLower().Trim());
            if (existed != null)
            {
                ModelState.AddModelError("BrandName", "You can not duplicate category name");
                return View();
            }
            brand.CreatedAt = DateTime.Now;
            brand.UpdateAt = DateTime.Now;
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            Brand brand = await context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand is null) return NotFound();
            return View(brand);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Brand newBrand)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            Brand existed = await context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (existed == null) return NotFound();
            bool duplicate = context.Brands.Any(c => c.BrandName.Trim().ToLower() == newBrand.BrandName.Trim().ToLower());
            if (duplicate)
            {
                ModelState.AddModelError("BrandName", "You cannot duplicate name");
                return View();
            }

            existed.BrandName = newBrand.BrandName;
            existed.UpdateAt = DateTime.Now;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            Brand brand = await context.Brands.FindAsync(id);
            if (brand is null) return NotFound();

            context.Brands.Remove(brand);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
