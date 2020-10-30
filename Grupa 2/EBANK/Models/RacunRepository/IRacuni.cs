using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.RacunRepository
{
    interface IRacuni
    {
        public Task OtvoriRacun(Racun racun);
        public Task ZatvoriRacun(int? id);
        public Task<List<Racun>> DajSveRacune();
        public Task<Racun> DajRacun(int? id);
        public bool DaLiPostojiRacun(int? id);
        public Task<List<Racun>> DajSveRacuneKlijenta(int? id);
        public Task UrediStanjeRacuna(Racun racun);
        public Task<List<Racun>> DajRacune(int? id);
    }
}
