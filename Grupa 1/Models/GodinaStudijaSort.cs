using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class GodinaStudijaSort: Algoritam
    {
        public bool Desc { get; set; }

        public GodinaStudijaSort(bool desc)
        {
            this.Desc = desc;
        }

        public override List<Student> Sortiraj(List<Student> studenti)
        {
            List<Student> sorted = new List<Student>();
            if (!Desc)
            {
                sorted = studenti.OrderBy(student => student.SkolovanjeInfo.GodinaStudija).ToList();
            }
            else
            {
                sorted = studenti.OrderBy(student => student.SkolovanjeInfo.GodinaStudija).ToList();
            }
            return null;
        }
        private const double pi = 3.14;
    }
}
