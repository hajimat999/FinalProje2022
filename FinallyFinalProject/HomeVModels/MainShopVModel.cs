using FinallyFinalProject.Models;
using System.Collections.Generic;

namespace FinallyFinalProject.HomeVModels
{
    public class MainShopVModel
    {
        public List<Product> Products { get; set; }
        public List<Color> Colors { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}
