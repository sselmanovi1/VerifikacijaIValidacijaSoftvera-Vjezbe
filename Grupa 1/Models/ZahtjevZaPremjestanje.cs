using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class ZahtjevZaPremjestanje : ZahtjevStudenta
    {
        //public Paviljon TrenutniPaviljon { get; set; }
        //public Soba TrenutnaSoba { get; set; }
        //public Paviljon NoviPaviljon { get; set; }
        //public Soba NovaSoba { get; set; }
        public string RazlogPremjestanja { get; set; }

        // Baza
        public int Soba1Id { get; set; }
        public int Soba2Id { get; set; }
        public int Paviljon1Id { get; set; }
        public int Paviljon2Id { get; set; }

        // Veze sa ostalim klasama
        public virtual Soba Soba1 { get; set; }
        public virtual Soba Soba2 { get; set; }
        public virtual Paviljon Paviljon1 { get; set; }
        public virtual Paviljon Paviljon2 { get; set; }

        public ZahtjevZaPremjestanje()
        {

        }

        public ZahtjevZaPremjestanje(Paviljon trenutniPaviljon, Soba trenutnaSoba, Paviljon noviPaviljon, Soba novaSoba, 
            string razlogPremjestanja, Korisnik podnosilacZahtjeva, DateTime datum) : base((Student)podnosilacZahtjeva, datum)
        {
            //TrenutniPaviljon = trenutniPaviljon;
            //TrenutnaSoba = trenutnaSoba;
            //NoviPaviljon = noviPaviljon;
            //NovaSoba = novaSoba;
            RazlogPremjestanja = razlogPremjestanja;
        }
    }
}
