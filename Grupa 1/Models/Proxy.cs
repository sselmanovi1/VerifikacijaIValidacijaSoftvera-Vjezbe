using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Proxy : IStudentskiDom
    {
        public int NivoPristupa { get; set; }
        public IStudentskiDom StudentskiDom { get; set; }
        public Korisnik Korisnik { get; set; }

        public void Pristup(Korisnik korisnik)
        {
            StudentskiDom = StudentskiDomSingleton.getInstance();
            Korisnik = korisnik;
            if (korisnik is Student)
                NivoPristupa = 3;
            else if (korisnik is Restoran)
                NivoPristupa = 2;
            else if (korisnik is Uprava)
                NivoPristupa = 1;
            else
                NivoPristupa = 4;
        }

        public void BrisiStudenta(Student student)
        {
            if (NivoPristupa == 1)
            {
                StudentskiDomSingleton.getInstance().BrisiStudenta(student);
            }
        }

        public void UpisiStudenta(Student student)
        {
            if (NivoPristupa == 1)
            {
                StudentskiDomSingleton.getInstance().UpisiStudenta(student);
            }
        }
    }
}
