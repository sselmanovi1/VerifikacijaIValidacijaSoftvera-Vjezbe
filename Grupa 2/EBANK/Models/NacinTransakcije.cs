using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum NacinTransakcije
    {
        [Display(Name = "U EBANK")]
        Interna,
        [Display(Name = "Na račun druge banke")]
        NaRacunDrugeBanke,
        [Display(Name = "Sa računa druge banke")]
        SaRacunaDrugeBanke
    }
}
