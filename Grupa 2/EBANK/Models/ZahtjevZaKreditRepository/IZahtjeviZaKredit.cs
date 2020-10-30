using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.ZahtjevZaKreditRepository
{
    interface IZahtjeviZaKredit
    {
        public Task PodnesiZahtjevZaKredit(ZahtjevZaKredit zahtjevZaKredit);
        public Task RijesiZahtjev(int? id, bool prihvacen);
        public Task<List<ZahtjevZaKredit>> DajSveZahtjeve();
        public Task<ZahtjevZaKredit> DajZahtjev(int? id);
        public bool DaLiPostojiZahtjev(int? id);
    }
}
