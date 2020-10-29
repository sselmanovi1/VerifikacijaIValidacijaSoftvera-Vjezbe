using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class SkolovanjeInfo
    {
        public int SkolovanjeInfoId { get; set; }
        public string Fakultet { get; set; }
        public int BrojIndeksa { get; set; }
        public int CiklusStudija { get; set; }
        public int GodinaStudija { get; set; }

        // Veza sa ostalim klasama
        public virtual ZahtjevZaUpis ZahtjevZaUpis { get; set; }
        public virtual Student Student { get; set; }

        public SkolovanjeInfo()
        {

        }
        public SkolovanjeInfo(string fakultet, int brojIndeksa, int ciklusStudija, int godinaStudija)
        {
            Fakultet = fakultet;
            BrojIndeksa = brojIndeksa;
            CiklusStudija = ciklusStudija;
            GodinaStudija = godinaStudija;
        }
    }
}
