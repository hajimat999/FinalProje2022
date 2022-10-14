using FinallyFinalProject.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.Models
{
    public class Contact:BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        public bool Look { get; set; }
        public DateTime Date { get; set; }
    }
}
