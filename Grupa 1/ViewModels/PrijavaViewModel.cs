using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.ViewModels
{
    public class PrijavaViewModel
    {
        [Required(ErrorMessage = "Morate unijeti prezime.")]
        public string Prezime { get; set; }   

        [Required(ErrorMessage ="Unesite ispravan JMBG.")]
        [Range(1000000000000,9999999999999,ErrorMessage ="JMBG mora imati 13 cifara.")]
        public long JMBG { get; set; }

        [Required(ErrorMessage ="Morate unijeti ime.")]
        public string Ime { get; set; }

        [Required(ErrorMessage ="Unesite mjesto rođenja.")]
        public string MjestoRodjenja { get; set; }

        [Required(ErrorMessage ="Unesite broj mobitela.")]
        public int Mobitel { get; set; }

        [Required(ErrorMessage ="Morate unijeti email adresu.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Unesite validnu email adresu.")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Molimo unesite ispravnu adresu.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Molimo unesite ispravnu općinu.")]
        public string Opcina { get; set; }

        [Required(ErrorMessage ="Molimo unesite ispravan index.")]
        [Range(10000,99999,ErrorMessage ="Index mora imati 5 cifara.")]
        public int Index { get; set; }

    }
}
