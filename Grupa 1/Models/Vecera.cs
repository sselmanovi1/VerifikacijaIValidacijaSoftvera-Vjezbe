using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Vecera
    {
        public int VeceraId { get; set; }
        public string Naziv { get; set; }
        // Baza
        public int DnevniMeniId { get; set; }

        // Veze sa ostalim klasama
        public virtual DnevniMeni DnevniMeni { get; set; }

        public Vecera(string naziv, int dnevniMeniId)
        {
            Naziv = naziv;
            DnevniMeniId = dnevniMeniId;
        }
    }
}
