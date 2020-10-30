using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.NovostRepository
{
    interface IOglasnaPloca
    {
        public Task DodajNovost(Novost novost);
        public Task UrediNovost(Novost novost);
        public Task UkloniNovost(int? id);
        public Task<List<Novost>> DajSveNovosti();
        public Task<List<Novost>> DajSvePrikazaneNovosti();
        public Task<Novost> DajNovost(int? id);
        public bool DaLiPostojiNovost(int? id);
    }
}
