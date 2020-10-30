using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Racun
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Broj računa")]
        public int Id{ get; set; }

        [Required]
        [Display(Name = "Stanje računa")]
        public float StanjeRacuna{ get; set; }

        [Required]
        [Display(Name = "Vrsta računa")]
        public VrstaRacuna VrstaRacuna { get; set; }

        [Required]
        public Klijent Klijent { get; set; }
    }
}
