using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class ZahtjevZaCimeraj : ZahtjevStudenta
    {
        //public Paviljon Paviljon { get; set; }
        //public Soba Soba { get; set; }
        //public Student PrviCimer { get; set; }
        //public Student DrugiCimer { get; set; }
        public string DodatneNapomene { get; set; }

        // Baza
        public int PaviljonId { get; set; }
        public int SobaId { get; set; }
        public int Cimer1Id { get; set; }
        public int Cimer2Id { get; set; }


        // Veze sa ostalim klasama
        public virtual Student Cimer1 { get; set; }
        public virtual Student Cimer2 { get; set; }
        public virtual Soba Soba { get; set; }
        public virtual Paviljon Paviljon { get; set; }

        public ZahtjevZaCimeraj()
        {

        }

        public ZahtjevZaCimeraj(Paviljon paviljon, Soba soba, Student prviCimer, Student drugiCimer, string dodatneNapomene,
            Korisnik podnosilacZahtjeva, DateTime datum) : base((Student) podnosilacZahtjeva, datum)
        {
            Paviljon = paviljon;
            Soba = soba;
            //PrviCimer = prviCimer;
            //DrugiCimer = drugiCimer;
            DodatneNapomene = dodatneNapomene;
        }
    }
}
