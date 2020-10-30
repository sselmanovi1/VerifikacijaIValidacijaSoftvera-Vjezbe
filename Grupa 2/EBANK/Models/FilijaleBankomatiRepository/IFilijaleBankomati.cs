using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    interface IFilijaleBankomati
    {
        public Task DodajBankomat(Bankomat bankomat);
        public Task UrediBankomat(Bankomat bankomat);
        public Task DodajFilijalu(Filijala filijala);
        public Task UrediFilijalu(Filijala filijala);
        public Task UkloniFilijalu(int? id);
        public Task UkloniBankomat(int? id);
        public Task<List<IMapObjekat>> DajSveMapObjekte();
        public Task<List<Filijala>> DajSveFilijale();
        public Task<List<Bankomat>> DajSveBankomate();
        public Task<Filijala> DajFilijalu(int? id);
        public Task<Bankomat> DajBankomat(int? id);
        public bool DaLiPostojiFilijala(int? id);
        public bool DaLiPostojiBankomat(int? id);
        
    }
}
