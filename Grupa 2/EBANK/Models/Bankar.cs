using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Bankar : Korisnik
    {
        [Required]
        [Display(Name = "Mjesto zaposlenja")]
        public Adresa MjestoZaposlenja { get; set; }
    }
}
