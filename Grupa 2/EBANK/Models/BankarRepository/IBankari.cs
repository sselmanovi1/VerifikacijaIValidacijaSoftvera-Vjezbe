using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.BankarRepository
{
    interface IBankari
    {
        public Task DodajBankara(Bankar bankar);
        public Task UrediBankara(Bankar bankar);
        public Task UkloniBankara(int? id);
        public Task<List<Bankar>> DajSveBankare();
        public Task<Bankar> DajBankara(int? id);
        public bool DaLiPostojiBankar(int? id);
        public Task<Bankar> DajBankara(string korisnickoIme);

    }
}
