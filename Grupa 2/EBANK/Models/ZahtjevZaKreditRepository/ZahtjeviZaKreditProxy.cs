using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.ZahtjevZaKreditRepository
{
    public class ZahtjeviZaKreditProxy : IZahtjeviZaKredit
    {
        int nivoPristupa; //1 moze podnositi zahtjeve, a 2 pregledati i prihvatati
        IZahtjeviZaKredit zahtjevi;

        public ZahtjeviZaKreditProxy(OOADContext context)
        {
            zahtjevi = new ZahtjeviZaKredit(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Klijent)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
            else nivoPristupa = 0;
        }

        public Task<List<ZahtjevZaKredit>> DajSveZahtjeve()
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.DajSveZahtjeve();
        }

        public async Task<ZahtjevZaKredit> DajZahtjev(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return await zahtjevi.DajZahtjev(id);
        }

        public bool DaLiPostojiZahtjev(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.DaLiPostojiZahtjev(id);
        }

        public Task PodnesiZahtjevZaKredit(ZahtjevZaKredit zahtjevZaKredit)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return zahtjevi.PodnesiZahtjevZaKredit(zahtjevZaKredit);
        }

        public Task RijesiZahtjev(int? id, bool prihvacen)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.RijesiZahtjev(id, prihvacen);
        }

    }
}
