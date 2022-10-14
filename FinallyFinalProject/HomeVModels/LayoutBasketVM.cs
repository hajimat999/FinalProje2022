using FinallyFinalProject.Models;
using System.Collections.Generic;

namespace FinallyFinalProject.HomeVModels
{
    public class LayoutBasketVM
    {
        public List<BasketItem> BasketItems { get; set; } 
        public decimal TotalPrice { get; set; } 
    }
}
