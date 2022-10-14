using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Migrations;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class DetailController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public DetailController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Shop(int? id)
        {
            Product product = await context.Products.Include(p => p.Brand).Include(p => p.Category)
                .Include(p => p.Information).Include(p => p.DiscountAmount).Include(p => p.ProductImages).Include(p=>p.Ratings).ThenInclude(r=>r.User).Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.Comments).ThenInclude(c=>c.User).FirstOrDefaultAsync(p => p.Id == id);
            List<BasketItem> basketItems = context.BasketItems.Where(b => b.ProductId == id).ToList();

            ShopVModel shopVModel = new ShopVModel
            {
                Product = product,
                BasketItems = basketItems,
                Products = context.Products.Include(x => x.ProductImages).Include(x => x.Information).Include(x => x.Category).Where(x => x.CategoryId == product.CategoryId).ToList()
            };
            return View(shopVModel);    
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Shop(Comment comment, ProductColor productColor, int id)
         {
            Product product1 = await context.Products.Include(p => p.Brand).Include(p => p.Category)
                .Include(p => p.Information).Include(p => p.DiscountAmount).Include(p => p.ProductImages).Include(p=>p.Ratings).ThenInclude(r=>r.User).Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.Comments).ThenInclude(c => c.User).FirstOrDefaultAsync(p => p.Id == id);
            List<BasketItem> basketItems = context.BasketItems.Where(b => b.ProductId == id).ToList();

            ShopVModel shopVModel = new ShopVModel
            {
                Product = product1,
                BasketItems = basketItems,
                Products = context.Products.Include(x => x.ProductImages).Include(x => x.Information).Include(x => x.Category).Where(x => x.CategoryId == product1.CategoryId).ToList()
            };


            if (comment.Id == 0)
            {
                if (comment.Text == null)
                {
                    ModelState.AddModelError("Text", "Please, Fill In");
                    return View(shopVModel);
                }
                if (User.Identity.IsAuthenticated)
                {
                    if (comment.Status != true)
                    {
                        ModelState.AddModelError("comment.Status", "Please, you should agree with it");
                        return View(shopVModel);
                    }
                    AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                    comment.User = user;
                    comment.UserId = user.Id;
                    comment.ProductId = id;
                    await context.Comments.AddAsync(comment);
                    await context.SaveChangesAsync();

                }
                else
                {

                    return RedirectToAction("Login", "Account");

                }
            }
            else
            {
                
                if(productColor.ProductId == 0)
                {
                    ModelState.AddModelError("", "You Must Choose one of colors");
                    return View(shopVModel);
                }
                Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product is null) return NotFound();
                if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
                {
                    AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                    BasketItem existed = await context.BasketItems.FirstOrDefaultAsync(b => b.UserId == user.Id && b.ProductId == id && b.ColorId==productColor.ProductId);
                    List<ProductColor> productColor1 =context.ProductColors.Where(p=>id == p.ProductId).ToList();
                    ProductColor productColor2 = productColor1.FirstOrDefault(p => p.ColorId == productColor.ProductId);
                    Color color = context.Colors.FirstOrDefault(c=>c.Id==productColor.ProductId);
                    if(productColor2.ProductCount > 0)
                    {
                        if (existed == null)
                        {
                            
                            existed = new BasketItem
                            {
                                Product = product,
                                ProductId = product.Id,
                                User = user,
                                UserId = user.Id,
                                Price = product.DiscountPrice,
                                CreatedAt = DateTime.Now,
                                UpdateAt = DateTime.Now,
                                ColorId = productColor.ProductId,
                                Color =color,
                                Quantity = 1,
                                                      
                            };
                            
                            
                            context.BasketItems.Add(existed);

                        }
                        else
                        {                           
                            if(existed.ColorId != productColor.ProductId)
                            {
                                BasketItem newBasketItem = new BasketItem
                                {
                                    Product = product,
                                    ProductId = product.Id,
                                    User = user,
                                    UserId = user.Id,
                                    Price = product.DiscountPrice,
                                    CreatedAt = DateTime.Now,
                                    UpdateAt = DateTime.Now,
                                    ColorId = productColor.ProductId,
                                    Color = color,
                                    Quantity = 1,
                                };
                                context.BasketItems.Add(newBasketItem);

                            }
                            else
                            {
                                existed.Quantity++;
                            }
                            
                        }
                        productColor2.ProductCount--;
                        await context.SaveChangesAsync();

                    }
                    else
                    {
                       
                        ModelState.AddModelError("", "There are not any products in Stock");
                        return View(shopVModel);
                    }
                    
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }

            }
           

            return Redirect(Request.Headers["Referer"].ToString());

        }
 
        public IActionResult Delete(int? id)
        {
            BasketItem basketItem = context.BasketItems.FirstOrDefault(b=>b.Id ==id);
            if (basketItem == null) return View();


            ProductColor productColor = context.ProductColors.FirstOrDefault(p => basketItem.ColorId == p.ColorId && basketItem.ProductId==p.ProductId);

            productColor.ProductCount += basketItem.Quantity;
            context.BasketItems.Remove(basketItem);
            context.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Plus(int? id)
        {          

            List<BasketItem> basketItems = await context.BasketItems.Where(b => b.ProductId == id).ToListAsync();
            
            
            if (basketItems.Count != 0)
            {
                foreach (BasketItem basketItem in basketItems)
                {
                    ProductColor productColor = context.ProductColors.FirstOrDefault(p => basketItem.ColorId == p.ColorId && basketItem.ProductId == p.ProductId);

                    if (productColor.ProductCount > 0)
                    {
                        basketItem.Quantity++;
                        productColor.ProductCount--;
                    }
                    else
                    {
                        return NotFound();
                    }
                   
                }

            }           
            else
            {
                
                if ((User.Identity.IsAuthenticated && User.IsInRole("Member")))
                {
                    AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                    Product product = context.Products.FirstOrDefault(p => p.Id == id);
                    List<ProductColor> productColor1 = context.ProductColors.Where(p => id == p.ProductId).ToList();

                    foreach (ProductColor productColor in productColor1)
                    {
                        if (productColor.ProductCount > 0)
                        {
                            bool c = context.ProductColors.Any(c => c.ColorId == productColor.ColorId && c.ProductId == productColor.ProductId);
                            if (c == true)
                            {
                                productColor.ProductCount--;
                                Color color = context.Colors.FirstOrDefault(c => c.Id == productColor.ColorId);
                                BasketItem basketItem = new BasketItem
                                {
                                    Product = product,
                                    ProductId = product.Id,
                                    User = user,
                                    UserId = user.Id,
                                    Price = product.DiscountPrice,
                                    CreatedAt = DateTime.Now,
                                    UpdateAt = DateTime.Now,
                                    ColorId = color.Id,
                                    Color = color,
                                    Quantity = 1,

                                };
                                await context.BasketItems.AddAsync(basketItem);
                            }

                        }
                        else
                        {
                            return NotFound();
                        }
                        


                    }

                    
                }
                else
                {
                    return RedirectToAction("Login", "Account");

                }

               
               
                
            }
            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public async Task<IActionResult> Minus(int? id)
        {
            List<BasketItem> basketItems = await context.BasketItems.Where(b => b.ProductId == id).ToListAsync();

            if (basketItems.Count != 0)
            {
                foreach (BasketItem basketItem in basketItems)
                {
                    ProductColor productColor = context.ProductColors.FirstOrDefault(p => basketItem.ColorId == p.ColorId && basketItem.ProductId == p.ProductId);

                    if (productColor.ProductCount > 0)
                    {
                        basketItem.Quantity--;
                        productColor.ProductCount++;
                        if(basketItem.Quantity == 0)
                        {
                            context.BasketItems.Remove(basketItem);
                        }
                    }
                    else
                    {
                        return NotFound();
                    }

                }

            }
            else
            {
                return NotFound();
            }

            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }
    
        public async Task<IActionResult> AddRate(List<int> ids)
        {
            int point = ids[1];
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return BadRequest();
                }
                bool c = context.Ratings.Any(r => r.UserId == user.Id && r.ProductId.ToString() == ids[0].ToString());
                if (c == true)
                {
                    ViewBag.Error = "You cannot rating";

                    return Redirect(Request.Headers["Referer"].ToString());
                }
                Product product = context.Products.FirstOrDefault(p => p.Id.ToString() == ids[0].ToString());
                int pointSum = 0;
                int pointCount = 0;
                if(product.Ratings != null)
                {
                    if(product.Ratings.Count > 1)
                    {
                        foreach (Rating rate in product.Ratings)
                        {
                            pointCount++;
                            pointSum += rate.Point;
                        }
                        product.Rating = (pointSum / pointCount);
                    }
                    else
                    {
                        product.Rating = point;
                    }
                    

                }
                else
                {
                    product.Rating = point;
                }



                Rating rating = new Rating
                {
                    CreatedAt = DateTime.Now,
                    User = user,
                    UserId = user.Id,
                    ProductId = product.Id,
                    Point = point
                };
                
                await context.Ratings.AddAsync(rating);
                
            }
                 
            else
            {
                return RedirectToAction("Login", "Account");
            }
            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }


    }

    
}
