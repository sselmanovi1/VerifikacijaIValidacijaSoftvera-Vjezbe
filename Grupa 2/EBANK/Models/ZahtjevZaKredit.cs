using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class ZahtjevZaKredit : KreditBaza
    {
        [Required]
        [Display(Name = "Namjena kredita")]
        public String NamjenaKredita { get; set; }

        [Required]
        [Display(Name = "Mjesečni prihodi")]
        public float MjesecniPrihodi { get; set; }

        [Required]
        [Display(Name = "Prosječni troškovi domaćinstva")]
        public float ProsjecniTroskoviDomacinstva { get; set; }

        [Required]
        [Display(Name = "Naziv radnog mjesta")]
        public String NazivRadnogMjesta { get; set; }

        [Required]
        [Display(Name = "Naziv Vašeg poslodavca")]
        public String NazivPoslodavca { get; set; }

        [Required]
        [Display(Name = "Ukupno radnog staža")]
        public int RadniStaz { get; set; }

        [Required]
        [Display(Name = "Broj nekretnina u vlasništvu")]
        public int BrojNekretnina { get; set; }

        
        [Required]
        [Display(Name = "Bračno stanje")]
        public BracnoStanje BracnoStanje { get; set; }

        
        [Display(Name = "Ime supružnika")]
        public string SupruznikIme { get; set; }

        [Display(Name = "Prezime supružnika")]
        public string SupruznikPrezime { get; set; }

        [Display(Name = "Zanimanje supružnika")]
        public string SupruznikZanimanje { get; set; }

        [Required]
        [Display(Name = "Imate li neplaćenih dugova?")]
        public bool ImaNeplacenihDugova { get; set; }


        [Display(Name = "Broj neplaćenih dugova")]
        public float BrojNeplacenihDugova { get; set; } = 0;


        [Required]
        [Display(Name = "Status zahtjeva")]
        public StatusZahtjevaZaKredit StatusZahtjeva { get; set; } = StatusZahtjevaZaKredit.Neobradjen;


        public char DajKreditnuSposobnost()
        {
            if (MjesecniPrihodi - ProsjecniTroskoviDomacinstva > 1000 && BrojNekretnina >= 1 && BrojNeplacenihDugova == 0 && BracnoStanje == BracnoStanje.UBraku && SupruznikZanimanje != "Nezaposlen" && RadniStaz > 10) return 'A';
            else if ((MjesecniPrihodi - ProsjecniTroskoviDomacinstva > 700) && (MjesecniPrihodi - ProsjecniTroskoviDomacinstva < 1000) && BrojNekretnina >= 1 && BrojNeplacenihDugova == 0 && BracnoStanje == BracnoStanje.UBraku && SupruznikZanimanje != "Nezaposlen" && RadniStaz > 5) return 'B';
            else if ((MjesecniPrihodi - ProsjecniTroskoviDomacinstva > 500) && (MjesecniPrihodi - ProsjecniTroskoviDomacinstva < 700) && BrojNekretnina >= 1 && BrojNeplacenihDugova == 0 && RadniStaz > 5) return 'C';
            else if ((MjesecniPrihodi - ProsjecniTroskoviDomacinstva > 300) && (MjesecniPrihodi - ProsjecniTroskoviDomacinstva < 500) && BrojNekretnina >= 1 && BrojNeplacenihDugova == 0 && BracnoStanje == BracnoStanje.UBraku && RadniStaz > 5) return 'D';
            else if ((MjesecniPrihodi - ProsjecniTroskoviDomacinstva > 100) && (MjesecniPrihodi - ProsjecniTroskoviDomacinstva < 300) && BrojNekretnina == 1 && BrojNeplacenihDugova > 0) return 'E';
            else if ((MjesecniPrihodi - ProsjecniTroskoviDomacinstva <= 100) && BrojNekretnina == 0 && BrojNeplacenihDugova > 0) return 'F';
            else return 'F';
        }
    }
}