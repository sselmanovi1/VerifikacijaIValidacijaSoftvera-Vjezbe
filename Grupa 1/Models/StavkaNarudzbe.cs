using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class StavkaNarudzbe
    {
        public int StavkaNarudzbeId { get; set; }
        public String Namirnica { get; set; }
        public double Kolicina { get; set; }
        public string MjernaJedinica { get; set; }

        // Baza
        public int ZahtjevZaNabavkuNamirnicaId { get; set; }

        // Veze sa ostalim klasama
        public virtual ZahtjevZaNabavkuNamirnica ZahtjevZaNabavkuNamirnica { get; set; }

        public StavkaNarudzbe()
        {

        }

        public StavkaNarudzbe(string namirnica, double kolicina)
        {
            Namirnica = namirnica;
            Kolicina = kolicina;
        }
    }
}
