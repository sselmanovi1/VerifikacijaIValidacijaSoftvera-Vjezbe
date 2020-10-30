using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    public class TransakcijaBuilder
    {
        private readonly Transakcija transakcija;

        public void PostaviVrijeme(DateTime vrijeme)
        {
            transakcija.Vrijeme = vrijeme;
        }

        public void PostaviRacune(Racun saRacuna, Racun naRacun)
        {
            transakcija.SaRacuna = saRacuna;
            transakcija.NaRacun = naRacun;
        }

        public void PostaviIznos(float iznos)
        {
            transakcija.Iznos = iznos;
        }

        public void PostaviVrstuTransakcije(VrstaTransakcije vrstaTransakcije)
        {
            transakcija.VrstaTransakcije = vrstaTransakcije;
        }
        
        public void PostaviNacinTransakcije(NacinTransakcije nacinTransakcije)
        {
            transakcija.NacinTransakcije = nacinTransakcije;
        }

    }
}
