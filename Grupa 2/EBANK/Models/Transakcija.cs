using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Transakcija
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public DateTime Vrijeme { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Sa računa")]
        public Racun? SaRacuna { get; set; }

        [Required]
        [Display(Name = "Na račun")]
        public Racun? NaRacun { get; set; }

        [Required]
        public float Iznos { get; set; }

        [Required]
        [Display(Name = "Vrsta transakcije")]
        public VrstaTransakcije VrstaTransakcije { get; set; }

        [Required]
        [Display(Name = "Način transakcije")]
        public NacinTransakcije NacinTransakcije { get; set; } = NacinTransakcije.Interna;

    }
}
