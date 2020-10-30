using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public interface IZahtjevObserver
    {
        public Task NaOdobrenZahtjev(Kredit kredit);
    }
}
