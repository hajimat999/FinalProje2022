using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext context;

        public ShopController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public async Task<IActionResult> Shop(List<int> ids, int page = 1)
        {
           
            if (ids.Count == 0)
            {
                List<Product> products = await context.Products.Include(p => p.Brand).Include(p => p.Category)
                .Include(p => p.Information).Include(p => p.DiscountAmount).Include(p => p.ProductImages).Include(p => p.Ratings).ThenInclude(r => r.User).Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.Comments).ThenInclude(c => c.User).Skip((page-1)*9).Take(9).ToListAsync();

                MainShopVModel mainShopVModel = new MainShopVModel
                {
                    Categories = context.Categories.ToList(),
                    Colors = context.Colors.ToList(),
                    Brands = context.Brands.ToList(),
                    Products = products
                };
                return View(mainShopVModel);
            }
            else
            {
                if (ids[0] != 0)
                {
                    List<Product> products = context.Products.Include(p => p.ProductImages).Where(p => p.CategoryId == ids[0]).Skip((page - 1) * 3).Take(3).ToList();
                    MainShopVModel mainShopVModel = new MainShopVModel
                    {
                        Categories = context.Categories.ToList(),
                        Colors = context.Colors.ToList(),
                        Brands = context.Brands.ToList(),
                        Products = products
                    };
                    return View(mainShopVModel);
                }
                else if (ids[1] != 0)
                {
                    List<Product> products = context.Products.Include(p => p.ProductImages).Include(p=>p.Ratings).Where(p => p.BrandId == ids[1]).Skip((page - 1) * 9).Take(9).ToList();
                    MainShopVModel mainShopVModel = new MainShopVModel
                    {
                        Categories = context.Categories.ToList(),
                        Colors = context.Colors.ToList(),
                        Brands = context.Brands.ToList(),
                        Products = products
                    };
                    return View(mainShopVModel);

                }
                else if(ids[2] != 0)
                {
                    List<ProductColor> productColors = context.ProductColors.Include(p=>p.Product).Where(p => p.ColorId == ids[2]).ToList();
                    List<Product> allProducts = context.Products.Include(p=>p.ProductImages).Include(p=>p.Ratings).Skip((page - 1) * 9).Take(9).ToList();
                    List<Product> products = new List<Product>();

                    foreach (ProductColor item in productColors)
                    {
                        bool c = allProducts.Any(ap => ap.Id == item.ProductId);
                        if (c == true)
                        {
                            products.Add(item.Product);
                        }

                    }
                    MainShopVModel mainShopVModel = new MainShopVModel
                    {
                        Categories = context.Categories.ToList(),
                        Colors = context.Colors.ToList(),
                        Brands = context.Brands.ToList(),
                        Products = products.ToList()
                    };
                    return View(mainShopVModel);

                }
                return Redirect(Request.Headers["Referer"].ToString());
            }

        }   
            

        
         
    }
}
