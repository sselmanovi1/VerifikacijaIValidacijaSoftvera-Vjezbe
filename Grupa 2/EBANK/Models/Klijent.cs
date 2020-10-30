using EBANK.Data;
using EBANK.Models.KlijentRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Klijent : Korisnik
    {
        [Required]
        [Display (Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public Spol Spol { get; set; }

        [Required]
        public string JMBG { get; set; }
        [Required]
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }
        [Required]
        [Display(Name = "Broj lične karte")]
        public string BrojLicneKarte { get; set; }
        [Required]
        public Adresa Adresa { get; set; }
        [Required]
        public string Zanimanje { get; set; }
        public String Grad { get; set; }

        public String Drzava { get; set; }

        [Required]
        public DateTime VrijemeDodavanja { get; set; } = DateTime.Now;
    }
}
