using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class PrebivalisteInfo
    {
        public int PrebivalisteInfoId { get; set; }
        public string Adresa { get; set; }
        public string Kanton { get; set; }
        public string Opcina { get; set; }

        // Veze sa ostalim klasama
        public virtual ZahtjevZaUpis ZahtjevZaUpis { get; set; }
        public virtual Student Student { get; set; }

        public PrebivalisteInfo()
        {

        }
        public PrebivalisteInfo(string adresa, string kanton, string opcina)
        {
            Adresa = adresa;
            Kanton = kanton;
            Opcina = opcina;
        }
    }
}
