using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum VrstaRacuna
    {
        [Display(Name = "Tekući račun")]
        Tekuci,
        [Display(Name = "Žiro račun")]
        Ziro,
        [Display(Name = "Devizni račun")]
        Devizni,
        [Display(Name = "Štedni račun")]
        Stedni
    }
}
