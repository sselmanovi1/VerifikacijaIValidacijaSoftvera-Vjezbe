using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public interface AzurirajMeni
    {
        void DodajRucak(Rucak rucak);
        void DodajVeceru(Vecera vecera);
        void IzbaciRucak(Rucak rucak);
        void IzbaciVeceru(Vecera vecera);
    }
}
