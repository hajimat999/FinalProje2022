using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    [Authorize(Roles = "Member")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OrderController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user =await userManager.FindByNameAsync(User.Identity.Name);
            List<BasketItem> basketItems =await context.BasketItems.Where(b => b.UserId == user.Id).ToListAsync();
            if(basketItems.Count() == 0)
            {
                ModelState.AddModelError("", "There are not any products in Basket");
                return View();
            }

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Order order)
        {
            if(!ModelState.IsValid) return View();

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            
            List<BasketItem> basketItems = await context.BasketItems.Include(b=>b.Product).Include(b=>b.Color).Where(b => b.UserId == user.Id).ToListAsync();
            
            order.BasketItems = basketItems;
            order.UserId = user.Id;
            order.User = user;
            order.CreatedAt = DateTime.Now;
            order.Status = false;
            order.TotalPrice = 0;
            foreach (BasketItem basketItem in basketItems)
            {
                order.TotalPrice += (basketItem.Price * basketItem
                    .Quantity);
                OrderItem orderItem = new OrderItem
                {
                    Model = basketItem.Product.Model,
                    Price = basketItem.Price,
                    Quantity = basketItem.Quantity,
                    UserId = user.Id,
                    ProductId = basketItem.ProductId,
                    Product = basketItem.Product,
                    User= user,
                    Order = order,
                    Color = basketItem.Color.ColorName
                };
                List<Product> products = context.Products.ToList();
                foreach (Product product in products)
                {
                    if (basketItem.ProductId == product.Id)
                    {
                        product.OrderCount += basketItem.Quantity;
                    }
                }
                context.OrderItems.Add(orderItem);
            }

            

            context.BasketItems.RemoveRange(basketItems);
            await context.AddAsync(order);
            await context.SaveChangesAsync();
            TempData["Succeeded"] = true;
            return RedirectToAction("Index", "Home");
        }
    }
}
