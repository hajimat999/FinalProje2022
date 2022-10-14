using FinallyFinalProject.Models;
using System.Collections.Generic;

namespace FinallyFinalProject.HomeVModels
{
    public class ShopVModel
    {
        public Comment Comment { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; } 
        public ProductColor ProductColor { get; set; }  
        public List<BasketItem> BasketItems { get; set; }
        
    }
}
