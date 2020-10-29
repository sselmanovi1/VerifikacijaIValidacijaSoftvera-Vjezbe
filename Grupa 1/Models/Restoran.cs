using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Restoran : Korisnik, AzurirajMeni, AzurirajStanjeBonova, PregledStanjaBonova
    {
        // public int Id { get; set; }
       
        //public DnevniMeni DnevniMeni { get; set; }
        //public int IdTrenutnogStudenta { get; set; }

        // Baza
        public int DnevniMeniId { get; set; }
        //public int StudentId { get; set; }

        // Veze sa ostalim klasama
        //public virtual Student Student { get; set; }
        public virtual DnevniMeni DnevniMeni { get; set; }
        public virtual ICollection<ZahtjevRestorana> ZahtjevRestorana { get; set; }
        //public virtual ZahtjevZaNabavkuNamirnica ZahtjevZaNabavkuNamirnica { get; set; }
        //public virtual Korisnik Korisnik { get; set; }

        public void AzurirajDnevniMeni(List<Rucak> listRucaka, List<Vecera> listVecera)
        {
            DnevniMeni.Rucak = listRucaka;
            DnevniMeni.Vecera = listVecera;
            foreach(Rucak r in listRucaka)
            {
                StudentskiDomSingleton.Context.Rucak.Add(r);
            }
            foreach(Vecera v in listVecera)
            {
                StudentskiDomSingleton.Context.Vecera.Add(v);
            }
            StudentskiDomSingleton.Context.DnevniMeni.Update(DnevniMeni);
            StudentskiDomSingleton.Context.SaveChanges();
        }

        public Restoran()
        {
            //IdTrenutnogStudenta = -1;
            // Treba postaviti useranme i password za Restoran
        }

        public void DodajRucak(Rucak rucak)
        {
            DnevniMeni.DodajRucak(rucak);
        }

        public void DodajVeceru(Vecera vecera)
        {
            DnevniMeni.DodajVeceru(vecera);
        }

        public void IzbaciRucak(Rucak rucak)
        {
            DnevniMeni.IzbaciRucak(rucak);
        }

        public void IzbaciVeceru(Vecera vecera)
        {
            DnevniMeni.IzbaciVeceru(vecera);
        }

        public void IzbaciSve()
        {
            DnevniMeni.IzbaciSve();
        }

        public async void AzurirajStanjeRucakaAsync(int id)
        {
            Student student = await StudentskiDomSingleton.getInstance().NadjiStudentaPoIDu(id);
            if(student != null)
            {
                student.BrojRucaka--;
                StudentskiDomSingleton.Context.Student.Update(student);
                StudentskiDomSingleton.Context.SaveChanges();
            }
        }

        public async void AzurirajStanjeVeceraAsync(int id)
        {
            Student student = await StudentskiDomSingleton.getInstance().NadjiStudentaPoIDu(id);
            if (student != null)
            {
                student.BrojRucaka++;
                StudentskiDomSingleton.Context.Student.Update(student);
                StudentskiDomSingleton.Context.SaveChanges();
            }
        }

        public async Task<int> DajBrojRucakaZaStudentaAsync(int id)
        {
            Student student = await StudentskiDomSingleton.getInstance().NadjiStudentaPoIDu(id);
            if (student != null)
            {
                return student.BrojRucaka;
            }
            return 0;
        }

        public async Task<int> DajBrojVeceraZaStudentaAsync(int id)
        {
            Student student = await StudentskiDomSingleton.getInstance().NadjiStudentaPoIDu(id);
            if (student != null)
            {
                return student.BrojVecera;
            }
            return 0;
        }
    }
}
