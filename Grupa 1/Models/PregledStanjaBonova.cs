using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public interface PregledStanjaBonova
    {
        Task<int> DajBrojRucakaZaStudentaAsync(int id);
        Task<int> DajBrojVeceraZaStudentaAsync(int id);
    }
}
