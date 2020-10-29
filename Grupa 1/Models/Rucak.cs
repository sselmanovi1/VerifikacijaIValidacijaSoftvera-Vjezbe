using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Rucak
    {
        public int RucakId { get; set; }
        public string Naziv { get; set; }
        // Baza
        public int DnevniMeniId { get; set; }

        // Veze sa ostalim klasama
        public virtual DnevniMeni DnevniMeni { get; set; }

        public Rucak(string naziv, int dnevniMeniId)
        {
            Naziv = naziv;
            DnevniMeniId = dnevniMeniId;
        }

    }
}
