using FinallyFinalProject.DAL;
using FinallyFinalProject.HomeVModels;
using FinallyFinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace FinallyFinalProject.Services
{
    public class LayoutService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public LayoutService(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public LayoutBasketVM Getbasket()
        {
            decimal totalPrice = 0;
            List<BasketItem> basketItems = context.BasketItems.Include(b=>b.Color).Include(b=>b.Product.ProductImages).Include(b=> b.Product.ProductColors).ThenInclude(b=>b.Color).ToList();
            foreach (BasketItem basketItem in basketItems)
            {
                totalPrice+=basketItem.Price * basketItem.Quantity; 
                

            }
            LayoutBasketVM layoutBasketVM = new LayoutBasketVM
            {
                BasketItems = basketItems,
                TotalPrice = totalPrice,
                
            };
            return layoutBasketVM;
        }
        public List<Wishlest> GetWishlest()
        {
            List<Wishlest> wishlests = context.Wishlests.Include(w => w.Product.ProductImages).Include(w=>w.Product.ProductColors).ThenInclude(w=>w.Color).ToList();
            return wishlests;
        }

        public List<Contact> GetContacts()
        {

            List<Contact> contacts = context.Contacts.ToList();
            return contacts;
        }

        public List<Setting> GetSettings()
        {
         
            List<Setting> settings = context.Settings.ToList();
            return settings;
        }

        
    }
}
