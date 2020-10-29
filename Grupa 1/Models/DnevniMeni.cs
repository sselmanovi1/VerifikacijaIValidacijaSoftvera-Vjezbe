using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class DnevniMeni : AzurirajMeni
    {
        public int DnevniMeniId { get; set; }
        //public List<string> ListaRucaka { get; set; }
        //public List<string> ListaVecera { get; set; }

        // Veze sa ostalim klasama
        public virtual Restoran Restoran { get; set; }
        public virtual ICollection<Rucak> Rucak { get; set; }
        public virtual ICollection<Vecera> Vecera { get; set; }


        public DnevniMeni()
        {

        }


        public DnevniMeni(List<Rucak> listaRucaka, List<Vecera> listaVecera)
        {
            this.Rucak = listaRucaka;
            this.Vecera = listaVecera;
        }

        public void DodajRucak(Rucak rucak)
        {
            rucak.DnevniMeniId = DnevniMeniId;
            Rucak.Add(rucak);
            StudentskiDomSingleton.Context.Rucak.Add(rucak);
            updateMeni();
        }

        public void DodajVeceru(Vecera vecera)
        {
            vecera.DnevniMeniId = DnevniMeniId;
            Vecera.Add(vecera);
            StudentskiDomSingleton.Context.Vecera.Add(vecera);
            updateMeni();
        }

        public void IzbaciRucak(Rucak rucak)
        {
            rucak.DnevniMeniId = DnevniMeniId;
            Rucak.Remove(rucak);
            StudentskiDomSingleton.Context.Rucak.Remove(rucak);
            updateMeni();
        }

        public void IzbaciVeceru(Vecera vecera)
        {
            vecera.DnevniMeniId = DnevniMeniId;
            Vecera.Remove(vecera);
            StudentskiDomSingleton.Context.Vecera.Remove(vecera);
            updateMeni();
        }

        public void IzbaciSve()
        {
            StudentskiDomSingleton.Context.Rucak.RemoveRange(Rucak);
            StudentskiDomSingleton.Context.Vecera.RemoveRange(Vecera);
            Rucak.Clear();
            Vecera.Clear();
            updateMeni();
        }

        private void updateMeni()
        {
            StudentskiDomSingleton.Context.SaveChanges();
        }
    }
}
