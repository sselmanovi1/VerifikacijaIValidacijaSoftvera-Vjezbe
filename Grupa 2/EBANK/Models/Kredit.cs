using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Kredit:KreditBaza
    {
        public Kredit()
        {
            IsplaceniIznos = 0; // Set the initial value for model
            PocetakOtplate = DateTime.Now;
            StatusKredita = StatusKredita.Aktivan;
        }
        [Display(Name = "Isplaćeni iznos")]
        public float IsplaceniIznos {get; set;}
        [Display(Name = "Početak otplate")]
        public DateTime PocetakOtplate { get; set; }
        [Display(Name = "Status kredita")]
        public StatusKredita StatusKredita { get; set; }

        public void UplatiMjesecnuRatu() 
        {
            int rokOtplate = 1;
            switch (RokOtplate)
            {
                case RokOtplate.Trajanje_1_godina: rokOtplate = 1; break;
                case RokOtplate.Trajanje_5_godina: rokOtplate = 1; break;
                case RokOtplate.Trajanje_10_godina: rokOtplate = 1; break;
                case RokOtplate.Trajanje_15_godina: rokOtplate = 1; break;
                case RokOtplate.Trajanje_20_godina: rokOtplate = 1; break;
            }
            Racun.StanjeRacuna = Racun.StanjeRacuna - (Iznos / (rokOtplate * 12));
        }

        public void ZavrsiKredit()
        {
            if (IsplaceniIznos == Iznos) StatusKredita = StatusKredita.Zavrsen;
        }
}
}
