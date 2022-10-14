using FinallyFinalProject.Models;
using System.Collections.Generic;

namespace FinallyFinalProject.HomeVModels
{
    public class HomeVM
    {
        public List<Setting> Settings { get; set; }
        public List<Product> Products { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
