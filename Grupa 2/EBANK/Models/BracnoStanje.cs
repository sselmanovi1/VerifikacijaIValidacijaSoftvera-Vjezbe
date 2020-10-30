using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum BracnoStanje
    {
        [Display(Name = "u braku")]
        UBraku,
        [Display(Name = "Razveden/a")]
        Razveden,
        [Display(Name = "Samac")]
        Samac
    }
}
