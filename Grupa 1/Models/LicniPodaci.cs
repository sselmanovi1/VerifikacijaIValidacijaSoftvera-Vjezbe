using StudentskiDom.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class LicniPodaci
    {
        public int LicniPodaciId { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string MjestoRodjenja { get; set; }
        public Pol Pol { get; set; }
        public string Email { get; set; }
        public long Jmbg { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public int Mobitel { get; set; }
        public String Slika { get; set; }

        // Veze sa ostalim klasama

        public virtual Student Student { get; set; }
        public virtual ZahtjevZaUpis ZahtjevZaUpis { get; set; }

        public LicniPodaci()
        {

        }
        public LicniPodaci(string prezime, string ime, string mjestoRodjenja, Pol pol, string email,
            long jmbg, DateTime datumRodjenja, int mobitel, string slika)
        {
            Prezime = prezime;
            Ime = ime;
            MjestoRodjenja = mjestoRodjenja;
            Pol = pol;
            Email = email;
            Jmbg = jmbg;
            DatumRodjenja = datumRodjenja;
            Mobitel = mobitel;
            Slika = slika;
        }
    }
}
