using FinallyFinalProject.DAL;
using FinallyFinalProject.Migrations;
using FinallyFinalProject.Models;
using FinallyFinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products =await context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Comments)
                .Include(p => p.Information).Include(p => p.DiscountAmount).Include(p => p.ProductImages).Include(p=>p.ProductColors).ThenInclude(p=>p.Color).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Information =await  context.Informations.ToListAsync();
            ViewBag.Category = await context.Categories.ToListAsync();
            ViewBag.Color = await context.Colors.ToListAsync();
            ViewBag.Brand = await context.Brands.ToListAsync();
            ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Information = await context.Informations.ToListAsync();
                ViewBag.Category = await context.Categories.ToListAsync();
                ViewBag.Color = await context.Colors.ToListAsync();
                ViewBag.Brand = await context.Brands.ToListAsync();
                ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();
                return View();
            }
            if (product.MainPhoto == null || product.HoverPhoto == null || product.Photos == null)
            {
                ViewBag.Information = await context.Informations.ToListAsync();
                ViewBag.Category = await context.Categories.ToListAsync();
                ViewBag.Color = await context.Colors.ToListAsync();
                ViewBag.Brand = await context.Brands.ToListAsync();
                ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();

                ModelState.AddModelError(string.Empty, "You must choose 1 main photo and 1 hover photo and 1 another photo");
                return View();
            }
            if (product.MainPhoto.ContentType == null || !product.MainPhoto.ContentType.Contains("image/") || product.HoverPhoto.ContentType == null || !product.HoverPhoto.ContentType.Contains("image/"))
            {
                ViewBag.Information = await context.Informations.ToListAsync();
                ViewBag.Category = await context.Categories.ToListAsync();
                ViewBag.Color = await context.Colors.ToListAsync();
                ViewBag.Brand = await context.Brands.ToListAsync();
                ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();

                ModelState.AddModelError(string.Empty, "Please, enter correct image");
                return View();
            }
            if (product.MainPhoto.Length / 1024 / 1024 > 2 || product.HoverPhoto.Length / 1024 / 1024 > 2)
            {
                ViewBag.Information = await context.Informations.ToListAsync();
                ViewBag.Category = await context.Categories.ToListAsync();
                ViewBag.Color = await context.Colors.ToListAsync();
                ViewBag.Brand = await context.Brands.ToListAsync();
                ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();

                ModelState.AddModelError(string.Empty, "Please, enter correct image");
                return View();
            }

            TempData["FileName"] = null;
            int count = 0;
            product.ProductImages = new List<ProductImage>();
            List<IFormFile> remove = new List<IFormFile>();
            foreach (var photo in product.Photos)
            {
               
                if (photo.ContentType == null || !photo.ContentType.Contains("image/") || photo.Length / 1024 / 1024 > 2)
                {
                    remove.Add(photo);
                    TempData["FileName"] += photo.FileName + ",";
                    count++;
                    continue;
                }
                string fileNameFalse = string.Concat(Guid.NewGuid(), photo.FileName);
                string pathFalse = Path.Combine(webHostEnvironment.WebRootPath, "BrandNewImages");
                string filePathFalse = Path.Combine(pathFalse, fileNameFalse);

                try
                {
                    using (FileStream stream = new FileStream(filePathFalse, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }
                }
                catch (Exception)
                {
                    throw new FileLoadException();
                }

                ProductImage productFalseImage = new ProductImage
                {
                    Name = fileNameFalse,
                    IsMain = false,
                    Alternative = photo.Name,
                    Product = product
                };
                product.ProductImages.Add(productFalseImage);

            }
            product.Photos.RemoveAll(p=>remove.Any(r=>r.FileName == p.FileName));

            if(product.Photos.Count == count)
            {
                ViewBag.Information = await context.Informations.ToListAsync();
                ViewBag.Category = await context.Categories.ToListAsync();
                ViewBag.Color = await context.Colors.ToListAsync();
                ViewBag.Brand = await context.Brands.ToListAsync();
                ViewBag.DiscountAmount = await context.discountAmounts.ToListAsync();

                ModelState.AddModelError(string.Empty, "Please, all photos are not valid");
                return View();
            }

            string fileName = string.Concat(Guid.NewGuid(), product.MainPhoto.FileName);
            string path = Path.Combine(webHostEnvironment.WebRootPath, "BrandNewImages");
            string filePath = Path.Combine(path, fileName);

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.MainPhoto.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }

            ProductImage main = new ProductImage
            {
                Name = fileName,
                IsMain = true,
                Alternative = product.Model,
                Product = product
            };

            string fileNameHover = string.Concat(Guid.NewGuid(), product.HoverPhoto.FileName);
            string pathHover = Path.Combine(webHostEnvironment.WebRootPath, "BrandNewImages");
            string filePathHover = Path.Combine(pathHover, fileNameHover);

            try
            {
                using (FileStream stream = new FileStream(filePathHover, FileMode.Create))
                {
                    await product.HoverPhoto.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }

            ProductImage hover = new ProductImage
            {
                Name = fileNameHover,
                IsMain = null,
                Alternative = product.Model,
                Product = product
            };
            product.ProductImages.Add(hover);
            product.ProductImages.Add(main);

            product.ProductColors = new List<ProductColor>();
            if(product.ColorIds != null)
            {
                foreach (int colorId in product.ColorIds)
                {
                    ProductColor productColor = new ProductColor
                    {
                        Product = product,
                        ColorId = colorId,
                    };
                    product.ProductColors.Add(productColor);
                }
            }
         
            if(product.OnSale == true)
            {
                DiscountAmount discountAmount = context.discountAmounts.FirstOrDefault(dis => dis.Id == product.DiscountAmountId);
                product.DiscountPrice = (discountAmount.Amount * product.Price) / 100;
            }
            else
            {
                product.DiscountPrice = 0;
            }
            if(product.Comments == null)
            {
                product.Rating = 0;
            }
            
            product.OrderCount = 0;
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return View();
            Product product = context.Products.Include(p=>p.ProductImages).FirstOrDefault(p => p.Id == id);
            if(product == null) return NotFound();
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "BrandNewImages", product.ProductImages.FirstOrDefault(pi => pi.IsMain == true).Name);
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "BrandNewImages", product.ProductImages.FirstOrDefault(pi => pi.IsMain == false).Name);
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "BrandNewImages", product.ProductImages.FirstOrDefault(pi => pi.IsMain == null).Name);

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        
    }
}
