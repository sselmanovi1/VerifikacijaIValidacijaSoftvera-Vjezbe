using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class StudentPonovac : Student, IStudent
    {
        public StudentPonovac(int id, LicniPodaci podaci, PrebivalisteInfo prebivaliste, SkolovanjeInfo skolovanje, Soba soba, int brojRucaka, int brojVecera) 
            : base(id, podaci, prebivaliste, skolovanje, soba, brojRucaka, brojVecera)
        {
        }

        public void uplatiDom(Mjesec mjesec)
        {
            Student.Mjesec.Remove(mjesec);
            double dodajBudzet = 158 * 2;
            if (mjesec.Naziv.Equals("Septembar") || mjesec.Naziv.Equals("Juli"))
                dodajBudzet /= 2;
            StudentskiDomSingleton.getInstance().Uprava.Blagajna.StanjeBudgeta += dodajBudzet;

            //StudentskiDomSingleton.Context.RedovanStudent.Update(this);
            StudentskiDomSingleton.Context.Blagajna.Update(StudentskiDomSingleton.getInstance().Uprava.Blagajna);
            StudentskiDomSingleton.Context.SaveChanges();
        }
    }
}
