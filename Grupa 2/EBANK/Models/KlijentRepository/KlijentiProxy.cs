using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.KlijentRepository
{
    public class KlijentiProxy : IKlijenti
    {
        //0 - nista, 1 - samo pregledanje, 2 - pregledanje i uredjivanje, 3 = pregledanje jednog klijenta
        int nivoPristupa;
        IKlijenti klijenti;

        public KlijentiProxy(OOADContext context)
        {
            klijenti = new Klijenti(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
            else if (korisnik is Klijent)
                nivoPristupa = 3;
            else nivoPristupa = 0;
        }

        public Task DodajKlijenta(Klijent klijent)
        {
            if(nivoPristupa != 2)
                throw new AuthenticationException();

            return klijenti.DodajKlijenta(klijent);
        }

        public Task UkloniKlijenta(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return klijenti.UkloniKlijenta(id);
        }

        public Task UrediKlijenta(Klijent klijent)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return klijenti.UrediKlijenta(klijent);
        }

        public Task<List<Klijent>> DajSveKlijente()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return klijenti.DajSveKlijente();
        }

        public async Task<Klijent> DajKlijenta(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return await klijenti.DajKlijenta(id);
        }
        public bool DaLiPostojiKlijent(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return klijenti.DaLiPostojiKlijent(id);
        }

        public Task<Klijent> DajKlijenta(string korisnickoIme)
        {
            return klijenti.DajKlijenta(korisnickoIme);
        }

        public Task<Klijent> DajKlijentaLK(string brojLicneKarte)
        {
            return klijenti.DajKlijentaLK(brojLicneKarte);
        }
    }
}
