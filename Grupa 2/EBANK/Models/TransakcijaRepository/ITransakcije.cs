using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    interface ITransakcije
    {
        public Task Uplati(Transakcija transakcija);
        public Task<List<Transakcija>> DajSveTransakcije();
        public Task<Transakcija> DajTransakciju(int? id);
        public Task<List<Transakcija>> DajTransakcije(int? id);
        bool DaLiPostojiTransakcija(int? id);
    }
}
