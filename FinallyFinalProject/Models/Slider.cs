using FinallyFinalProject.Models.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinallyFinalProject.Models
{
    public class Slider:BaseEntity
    {
        public string Image { get; set; }
        [Required]
        public string Title1 { get; set; }
        [Required]
        public string Title2 { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte Order { get; set; }
        [Required]
        public string ButtonUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
