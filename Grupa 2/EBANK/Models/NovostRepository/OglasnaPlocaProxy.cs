using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.NovostRepository
{
    public class OglasnaPlocaProxy : IOglasnaPloca
    {
        //0 - nista, 1 - pregledanje i uredjivanje, 2 - samo pregledanje
        int nivoPristupa;
        IOglasnaPloca OglasnaPloca;

        public OglasnaPlocaProxy(OOADContext context)
        {
            OglasnaPloca = new OglasnaPloca(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Klijent)
                nivoPristupa = 2;
            else nivoPristupa = 0;
        }

        public Task DodajNovost(Novost novost)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return OglasnaPloca.DodajNovost(novost);
        }

        public Task UkloniNovost(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return OglasnaPloca.UkloniNovost(id);
        }

        public Task UrediNovost(Novost novost)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return OglasnaPloca.UrediNovost(novost);
        }

        public Task<List<Novost>> DajSveNovosti()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return OglasnaPloca.DajSveNovosti();
        }

        public async Task<Novost> DajNovost(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return await OglasnaPloca.DajNovost(id);
        }

        public bool DaLiPostojiNovost(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return OglasnaPloca.DaLiPostojiNovost(id);
        }

        public Task<List<Novost>> DajSvePrikazaneNovosti()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return OglasnaPloca.DajSvePrikazaneNovosti();
        }
    }
}
