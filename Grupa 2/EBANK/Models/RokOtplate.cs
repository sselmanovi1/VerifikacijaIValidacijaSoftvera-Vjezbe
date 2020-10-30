using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum RokOtplate : int
    {
        [Display(Name = "1 godina")]
        Trajanje_1_godina = 1,
        [Display(Name = "5 godina")]
        Trajanje_5_godina = 5,
        [Display(Name = "10 godina")]
        Trajanje_10_godina = 10,
        [Display(Name = "15 godina")]
        Trajanje_15_godina =15,
        [Display(Name = "20 godina")]
        Trajanje_20_godina = 20
    }
}
