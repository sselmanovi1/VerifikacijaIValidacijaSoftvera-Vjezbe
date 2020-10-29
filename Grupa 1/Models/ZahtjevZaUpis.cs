using StudentskiDom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class ZahtjevZaUpis : Zahtjev
    {
        //public LicniPodaci LicniPodaci { get; set; }
        //public PrebivalisteInfo Prebivaliste { get; set; }
        //public SkolovanjeInfo Skolovanje { get; set; }

        // Baza
        public int LicniPodaciId { get; set; }
        public int PrebivalisteInfoId { get; set; }
        public int SkolovanjeInfoId { get; set; }


        // Veze sa ostalim klasama
        //public virtual Zahtjev Zahtjev { get; set; }
        public virtual LicniPodaci LicniPodaci { get; set; }
        public virtual PrebivalisteInfo PrebivalisteInfo { get; set; }
        public virtual SkolovanjeInfo SkolovanjeInfo { get; set; }

        public ZahtjevZaUpis() : base(DateTime.Now)
        {

        }

        public ZahtjevZaUpis(LicniPodaci licniPodaci, PrebivalisteInfo prebivaliste, SkolovanjeInfo skolovanje, DateTime datum)
            : base(datum)
        {
            //LicniPodaci = licniPodaci;
            //Prebivaliste = prebivaliste;
            //Skolovanje = skolovanje;
        }
    }
}
