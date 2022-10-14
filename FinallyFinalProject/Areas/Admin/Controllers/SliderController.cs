using FinallyFinalProject.DAL;
using FinallyFinalProject.Utilities;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authorization;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class SliderController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SliderController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if(slider.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please, choose image");
                return View("Photo", "please, choose a image");
            }
            if (slider.Photo.ContentType==null || !slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Please, enter correct image");
                return View();
            }
            if(slider.Photo.Length / 1024 / 1024 > 2)
            {
                ModelState.AddModelError("Photo", "Please, enter correct image");
                return View();
            }
            string fileName = string.Concat(Guid.NewGuid(), slider.Photo.FileName);
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Admin", "NewImages");
            string filePath = Path.Combine(path, fileName);

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await slider.Photo.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw new FileLoadException();
            }
            slider.Image = fileName;
            slider.CreatedAt = DateTime.Now;
            slider.UpdateAt = DateTime.Now;
            await context.Sliders.AddAsync(slider);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == 0 || id is null) return NotFound();
            Slider slider = await context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider is null) return NotFound();
            return View(slider);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
   
            Slider existed = await context.Sliders.FindAsync(id);
            if (existed is null) return NotFound();
            if (!ModelState.IsValid) return View(existed);


            if (slider.Photo == null)
            {
                string filename = existed.Image;
                DateTime update = existed.CreatedAt;
                context.Entry(existed).CurrentValues.SetValues(slider);
                existed.Image = filename;
                existed.UpdateAt = DateTime.Now;
                existed.CreatedAt = update;
           
                
            }
            else
            {
                if (slider.Photo.ContentType == null || !slider.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Please, enter correct image");
                    return View(existed);
                }
                if (slider.Photo.Length / 1024 / 1024 > 2)
                {
                    ModelState.AddModelError("Photo", "Please, enter correct image");
                    return View(existed);
                }
                

                string fileName = string.Concat(Guid.NewGuid(), slider.Photo.FileName);
                string path = Path.Combine(webHostEnvironment.WebRootPath, "Admin", "NewImages");
                string filePath = Path.Combine(path, fileName);
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await slider.Photo.CopyToAsync(stream);
                    }
                }
                catch (Exception)
                {

                    throw new FileLoadException();
                }

                FileValidator.FileDelete(webHostEnvironment.WebRootPath, "Admin/NewImages", existed.Image);
                DateTime update = existed.CreatedAt;
                context.Entry(existed).CurrentValues.SetValues(slider);
                existed.Image = fileName;
                existed.UpdateAt = DateTime.Now;
                existed.CreatedAt = update;



            }
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)  return View();
            Slider slider = await context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if(slider == null) return NotFound();
            FileValidator.FileDelete(webHostEnvironment.WebRootPath, "Admin/NewImages", slider.Image);
            context.Sliders.Remove(slider);
            await context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
