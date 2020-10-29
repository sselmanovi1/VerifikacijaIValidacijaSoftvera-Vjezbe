using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Zahtjev
    {
        public int ZahtjevId { get; set; }
        public DateTime Datum { get; set; }
        public bool Odobren { get; set; }

        // Veze sa ostalim klasama
        public virtual ZahtjevRestorana ZahtjevRestorana { get; set; }
        public virtual ZahtjevStudenta ZahtjevStudenta { get; set; }
        public virtual ZahtjevZaUpis ZahtjevZaUpis { get; set; }

        public Zahtjev()
        {
            Datum = DateTime.Now;
            Odobren = false;
        }

        public Zahtjev(DateTime datum)
        {
            Datum = datum;
            Odobren = false;
        }

        public void PosaljiZahtjev() 
        {
            throw new NotImplementedException();
        }
    }
}
