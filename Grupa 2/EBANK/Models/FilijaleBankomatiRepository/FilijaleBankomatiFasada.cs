using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    public class FilijaleBankomatiFasada
    {
        public Bankomat NapraviBankomat(String ime, Adresa adresa)
        {
            Bankomat bankomat = new Bankomat(ime, adresa);
            return bankomat;
        }

        public Filijala NapraviFilijalu(String ime, String brojTelefona, Adresa adresa)
        {
            Filijala filijala = new Filijala(ime, brojTelefona, adresa);
            return filijala;
        }
    }
}
