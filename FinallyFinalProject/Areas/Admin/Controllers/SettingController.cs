using FinallyFinalProject.DAL;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinallyFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class SettingController : Controller
    {
        
        private readonly ApplicationDbContext context;
        public SettingController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Setting> settings = context.Settings.ToList();
            
            return View(settings);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (!ModelState.IsValid) return View();
            Setting settingModel = new Setting
            {
                Key =setting.Key,
                Value =setting.Value,
                CreatedAt = DateTime.Now
            };
            await context.Settings.AddAsync(settingModel);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null) return View();

            Setting setting = context.Settings.FirstOrDefault(x => x.Id == id); 
            context.Settings.Remove(setting);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
