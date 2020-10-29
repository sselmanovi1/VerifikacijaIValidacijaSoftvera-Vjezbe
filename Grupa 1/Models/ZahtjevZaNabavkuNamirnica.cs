using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class ZahtjevZaNabavkuNamirnica : ZahtjevRestorana
    {
        //public int ZahtjevZaNabavkuNamirnicaId { get; set; }
        //public List<string> ListNamirnica { get; set; }
        //public List<StavkaNarudzbe> Narudzba { get; set; }

        // Baza

        // Veze sa ostalim klasama
        public virtual ICollection<StavkaNarudzbe> StavkeNadruzbe { get; set; }
        //public virtual ZahtjevRestorana ZahtjevRestorana { get; set; }

        public ZahtjevZaNabavkuNamirnica()
        {

        }

        public ZahtjevZaNabavkuNamirnica(List<string> listNamirnica, List<StavkaNarudzbe> narudzba, 
            Korisnik podnosilacZahtjeva, DateTime datum) : base((Restoran) podnosilacZahtjeva, datum)
        {
            //ListNamirnica = listNamirnica;
            //Narudzba = narudzba;
        }
    }
}
