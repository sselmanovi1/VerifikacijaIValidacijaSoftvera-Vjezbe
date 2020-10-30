using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Novost
    {
        public int Id { get; set; }
        [Display(Name = "Vrijeme dodavanja")]
        public DateTime VrijemeDodavanja { get; set; } = DateTime.Now;

        [Required]
        public string Naslov { get; set; }

        [Required]
        [Display(Name = "Sadržaj")]
        public string Sadrzaj { get; set; }
        
        [Required]
        public bool Prikazana { get; set; }

    }
}
