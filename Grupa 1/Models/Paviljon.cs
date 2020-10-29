using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Paviljon
    {
        public int PaviljonId { get; set; }
        public string Naziv { get; set; }
        //public List<ISoba> Sobe { get; set; }
        public int Kapacitet { get; set; }
        public int BrojStudenata { get; set; }

        // Veze sa ostalim klasama
        public virtual ZahtjevZaCimeraj ZahtjevZaCimeraj { get; set; }
        [InverseProperty("Paviljon1")]
        public virtual ICollection<ZahtjevZaPremjestanje> ZahtjevZaPremjestanje1 { get; set; }
        [InverseProperty("Paviljon2")]
        public virtual ICollection<ZahtjevZaPremjestanje> ZahtjevZaPremjestanje2 { get; set; }
        public virtual ICollection<Soba> Sobe { get; set; }

        public Paviljon()
        {
            Sobe = new List<Soba>();
        }

        public Paviljon(string naziv, List<ISoba> sobe, int kapacitet, int brojStudenata)
        {
            Naziv = naziv;
            //Sobe = sobe;
            //Kapacitet = kapacitet;
            //BrojStudenata = brojStudenata;
        }
        #region Regija za atribute
        public bool DaLiImaMjesta()
        {
            return BrojStudenata < Kapacitet;
        }

        public int BrojSlobodnihMjesta()
        {
            return Kapacitet - BrojStudenata;
        }
        #endregion
    }
}
