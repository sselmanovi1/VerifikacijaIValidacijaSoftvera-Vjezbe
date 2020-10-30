using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.KreditRepository
{
    interface IKrediti
    {
        public  Task<Kredit> DajKredit(int? id);
        public bool DaLiPostojiKredit(int? id);
        public  Task<List<Kredit>> DajSveKredite();
        public Task<List<Kredit>> DajSveKrediteKlijenta(int? id);
    }
}
