using EBANK.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Korisnik
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }

        public static explicit operator Korisnik(OOADContext v)
        {
            throw new NotImplementedException();
        }
    }
}
