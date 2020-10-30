using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Konverzija
    {
        [DisplayName("Iznos")]
        public float Iznos { get; set; }
        [DisplayName("Konvertovani iznos")]
        public float KonvertovaniIznos { get; set; }
        [DisplayName("Iz valute")]
        public Valuta IzValute { get; set; }
        [DisplayName("U valutu")]
        public Valuta UValutu { get; set; }

    }
}
