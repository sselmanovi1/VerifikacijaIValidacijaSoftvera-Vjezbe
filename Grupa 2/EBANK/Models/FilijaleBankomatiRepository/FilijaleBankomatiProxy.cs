using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    public class FilijaleBankomatiProxy : IFilijaleBankomati
    {
       //0 znaci da ne moze nista raditi sa filijalama i bankomatima, a 1 da moze sve, 2 moze pregledati
        int nivoPristupa;
        IFilijaleBankomati filijaleBankomati;

        public FilijaleBankomatiProxy(OOADContext context)
        {
            filijaleBankomati = new FilijaleBankomati(context);
        }


        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Klijent)
                nivoPristupa = 2;
            else nivoPristupa = 0;
        }

        public Task DodajBankomat(Bankomat bankomat)
        {
            if(nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.DodajBankomat(bankomat);
        }

        public Task UrediBankomat(Bankomat bankomat)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.UrediBankomat(bankomat);
        }

        public Task DodajFilijalu(Filijala filijala)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.DodajFilijalu(filijala);
        }

        public Task UrediFilijalu(Filijala filijala)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.UrediFilijalu(filijala);
        }

        

        async Task<List<IMapObjekat>> IFilijaleBankomati.DajSveMapObjekte()
        {
           if(nivoPristupa != 1 && nivoPristupa != 2) 
                throw new AuthenticationException();

            return await filijaleBankomati.DajSveMapObjekte();
        }

        public Task<List<Filijala>> DajSveFilijale()
        {

            if (nivoPristupa != 1 && nivoPristupa != 2)
                throw new AuthenticationException();

            return filijaleBankomati.DajSveFilijale();
        }

        public Task<List<Bankomat>> DajSveBankomate()
        {

            if (nivoPristupa != 1 && nivoPristupa != 2)
                throw new AuthenticationException();

            return filijaleBankomati.DajSveBankomate();
        }

        public Task UkloniFilijalu(int? id)
        {

            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.UkloniFilijalu(id);
        }

        public Task UkloniBankomat(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.UkloniBankomat(id);
        }


        public Task<Filijala> DajFilijalu(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.DajFilijalu(id);
        }

        public Task<Bankomat> DajBankomat(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.DajBankomat(id);
        }

        public bool DaLiPostojiFilijala(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.DaLiPostojiFilijala(id);
        }

        public bool DaLiPostojiBankomat(int? id)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();

            return filijaleBankomati.DaLiPostojiBankomat(id);
        }
    }
}
