using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public interface AzurirajStanjeBonova
    {
        void AzurirajStanjeRucakaAsync(int id);
        void AzurirajStanjeVeceraAsync(int id);
    }
}
