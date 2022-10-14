using FinallyFinalProject.DAL;
using FinallyFinalProject.Migrations;
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
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Order> orders = context.Orders.Include(o=>o.BasketItems).Include(o=>o.User).ToList();
            foreach (Order item in orders)
            {
                if (item.CreatedAt.AddDays(15) < DateTime.Now)
                {
                    if (item.Status == true)
                    {
                        item.Deliver = true;
                    }
                }
            }
            context.SaveChanges();
            return View(orders);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Order order = context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return View();
            context.Orders.Remove(order);
            List<OrderItem> orderItems = await context.OrderItems.Where(o => o.OrderId == id).ToListAsync();
            context.OrderItems.RemoveRange(orderItems);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Success(int? id)
        {
            if (id == null) return View();
            Order existed = context.Orders.Include(o => o.BasketItems).Include(o => o.User).FirstOrDefault(o => o.Id == id);

            existed.Status = true;
            existed.Deliver = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
   
        public async Task<IActionResult> Deliver()
        {
            List<Order> orders =await context.Orders.Include(o=>o.User).Where(o => o.Deliver == true).ToListAsync();
            return View(orders);
           
        }

        
    }
}
