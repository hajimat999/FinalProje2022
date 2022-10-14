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
    public class ProductColorController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductColorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<ProductColor> products = context.ProductColors.Include(c=>c.Product).ThenInclude(p=>p.ProductImages).Include(c=>c.Color).ToList();
            return View(products);
        }

   
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            ProductColor product = await context.ProductColors.FirstOrDefaultAsync(b => b.Id == id);
            if (product is null) return NotFound();
            return View(product);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, ProductColor productColor)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            ProductColor existed = await context.ProductColors.FirstOrDefaultAsync(b => b.Id == id);
            if (existed == null) return NotFound();
           

            
            existed.ProductCount = productColor.ProductCount;
            existed.UpdateAt = DateTime.Now;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            ProductColor product = await context.ProductColors.FindAsync(id);
            if (product is null) return NotFound();

            context.ProductColors.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
