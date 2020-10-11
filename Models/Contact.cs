using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ServicesID { get; set; }
        public Services Services { get; set; }
        [Required]
        [Display(Name = "Contact email")]
        public string ContactEmail { get; set; }
    }
}
