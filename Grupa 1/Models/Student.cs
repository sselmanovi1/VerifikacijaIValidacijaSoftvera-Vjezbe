using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentskiDom.Models
{
    public class Student : Korisnik
    {
        //public LicniPodaci LicniPodaci { get; set; }
        //public PrebivalisteInfo PrebivalisteInfo { get; set; }
        //public SkolovanjeInfo SkolovanjeInfo { get; set; }
        //public Soba Soba { get; set; }
        public int BrojRucaka { get; set; }
        public int BrojVecera { get; set; }

        // Baza
        public int LicniPodaciId { get; set; }
        public int PrebivalisteInfoId { get; set; }
        public int SkolovanjeInfoId { get; set; }
        public int SobaId { get; set; }

        // Veze sa ostalim klasama
        //public virtual Korisnik Korisnik { get; set; }
        public virtual PrebivalisteInfo PrebivalisteInfo { get; set; }
        public virtual LicniPodaci LicniPodaci { get; set; }
        public virtual SkolovanjeInfo SkolovanjeInfo { get; set; }
        //public virtual Restoran Restoran { get; set; }
        public virtual Soba Soba { get; set; }
        public virtual ZahtjevStudenta ZahtjevStudenta { get; set; }
        public virtual ICollection<Mjesec> Mjesec { get; set; }

        [InverseProperty("Cimer1")]
        public virtual ICollection<ZahtjevZaCimeraj> ZahtjevZaCimeraj1 { get; set; }

        [InverseProperty("Cimer2")]
        public virtual ICollection<ZahtjevZaCimeraj> ZahtjevZaCimeraj2 { get; set; }

        public Student()
        {

        }
        public Student(int id, LicniPodaci podaci, PrebivalisteInfo prebivaliste, SkolovanjeInfo skolovanje,
            Soba soba, int brojRucaka, int brojVecera)
        {
            Id = id;
            LicniPodaci = podaci;
            PrebivalisteInfo = prebivaliste;
            SkolovanjeInfo = skolovanje;
            Soba = soba;
            BrojRucaka = brojRucaka;
            BrojVecera = brojVecera;
        }
        
        public void azurirajLicnePodatke(string prezime, string ime, string mjestoRodjenja, Pol pol, string email,
            long jmbg, DateTime datumRodjenja, int mobitel, string slika)
        {
            LicniPodaci = new LicniPodaci(prezime, ime, mjestoRodjenja, pol, email, jmbg, datumRodjenja, mobitel, slika);
        }

        public void azurirajSkolovanje(string fakultet, int brojIndeksa, int ciklusStudija, int godinaStudija)
        {
            SkolovanjeInfo = new SkolovanjeInfo(fakultet, brojIndeksa, ciklusStudija, godinaStudija);   
        }

        public void uplatiDom(Mjesec mjesec)
        {
            Student.Mjesec.Remove(mjesec);
            double dodajBudzet = 158;
            if (mjesec.Naziv.Equals("Septembar") || mjesec.Naziv.Equals("Juli"))
                dodajBudzet /= 2;
            StudentskiDomSingleton.getInstance().Uprava.Blagajna.StanjeBudgeta += dodajBudzet;

            //StudentskiDomSingleton.Context.RedovanStudent.Update(this);
            StudentskiDomSingleton.Context.Blagajna.Update(StudentskiDomSingleton.getInstance().Uprava.Blagajna);
            StudentskiDomSingleton.Context.SaveChanges();
        }

    }
}
