using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FinallyFinalProject.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class DiscountController : Controller
    {
        private readonly ApplicationDbContext context;

        public DiscountController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<DiscountAmount> discountAmounts = context.discountAmounts.ToList();        
            return View(discountAmounts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(DiscountAmount discountAmount)
        {
            if (!ModelState.IsValid) return View();
            DiscountAmount existed = await context.discountAmounts.FirstOrDefaultAsync(d => d.Amount == discountAmount.Amount);
            if (existed != null)
            {
                ModelState.AddModelError("Amount", "You cannot enter the same amount ");
                return View();
            }
            discountAmount.CreatedAt = DateTime.Now;
            discountAmount.UpdateAt = DateTime.Now;
            await context.discountAmounts.AddAsync(discountAmount);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id == 0) return NotFound();
            DiscountAmount discountAmount = await context.discountAmounts.FirstOrDefaultAsync(d => d.Id == id);
            if (discountAmount is null) return NotFound();
            return View(discountAmount);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, DiscountAmount discountAmount)
        {
            if (id is null || id == 0) return NotFound();
            if (!ModelState.IsValid) return View();

            DiscountAmount existed = await context.discountAmounts.FirstOrDefaultAsync(b => b.Id == id);
            if (existed == null) return NotFound();
            bool duplicate = context.discountAmounts.Any(c => c.Amount == discountAmount.Amount);
            if (duplicate)
            {
                ModelState.AddModelError("Amount", "You cannot enter the same amount");
                return View();
            }

            existed.Amount = discountAmount.Amount;
            existed.UpdateAt = DateTime.Now;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();

            DiscountAmount discount = await context.discountAmounts.FindAsync(id);
            if (discount is null) return NotFound();

            context.discountAmounts.Remove(discount);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
