using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    public class TransakcijeProxy : ITransakcije
    {
        //0 ne moze nista, 1 i 2 mogu samo pregledati, a 3 moze uplacivati
        private int nivoPristupa;
        private readonly ITransakcije transakcije;

        public TransakcijeProxy(OOADContext context)
        {
            transakcije = new Transakcije(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Klijent) nivoPristupa = 3;
            else if (korisnik is Bankar) nivoPristupa = 2;
            else if (korisnik is Administrator) nivoPristupa = 1;
            else nivoPristupa = 0;

        }
        public Task<List<Transakcija>> DajSveTransakcije()
        {
            if(nivoPristupa == 0) throw new AuthenticationException();
            return transakcije.DajSveTransakcije();
        }

        public Task<Transakcija> DajTransakciju(int? id)
        {
            if (nivoPristupa == 0) throw new AuthenticationException();
            return transakcije.DajTransakciju(id);
        }

        public Task Uplati(Transakcija transakcija)
        {
            if (nivoPristupa != 3) throw new AuthenticationException();
            return transakcije.Uplati(transakcija);
        }

        public bool DaLiPostojiTransakcija(int? id)
        {
            return transakcije.DaLiPostojiTransakcija(id);
        }

        public Task<List<Transakcija>> DajTransakcije(int? id)
        {
            if (nivoPristupa == 0) throw new AuthenticationException();
            return transakcije.DajTransakcije(id);
        }
    }
}
