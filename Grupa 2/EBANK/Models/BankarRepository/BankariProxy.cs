using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.BankarRepository
{
    public class BankariProxy : IBankari
    {
        //0 - nista, 1 - samo pregledanje, 2 - pregledanje i uredjivanje
        int nivoPristupa = 2;
        IBankari bankari;

        public BankariProxy(OOADContext context)
        {
            bankari = new Bankari(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 2;
        }

        public Task DodajBankara(Bankar bankar)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return bankari.DodajBankara(bankar);
        }

        public Task UkloniBankara(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return bankari.UkloniBankara(id);
        }

        public Task UrediBankara(Bankar bankar)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return bankari.UrediBankara(bankar);
        }

        public Task<List<Bankar>> DajSveBankare()
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return bankari.DajSveBankare();
        }

        public async Task<Bankar> DajBankara(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return await bankari.DajBankara(id);
        }
        public bool DaLiPostojiBankar(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return bankari.DaLiPostojiBankar(id);
        }

        public Task<Bankar> DajBankara(string korisnickoIme)
        {
            return bankari.DajBankara(korisnickoIme);
        }
    }
}

