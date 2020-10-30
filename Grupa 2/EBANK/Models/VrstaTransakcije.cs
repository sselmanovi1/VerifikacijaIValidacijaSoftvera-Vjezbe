using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum VrstaTransakcije
    {
        [Display(Name = "Uobičajeno plaćanje")]
        UobicajenoPlacanje,
        [Display(Name = "Individualno plaćanje")]
        IndividualnoPlacanje,
        Kupnja,
        [Display(Name = "Individualni dohodak")]
        IndividualniDohodak,
        [Display(Name = "Uobičajeni dohodak")]
        UobicajeniDohodak
    }
}
