using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Soba : ISoba
    {
        public int SobaId { get; set; }
        public int BrojSobe { get; set; }
        public int Kapacitet { get; set; }
        //public List<Student> Studenti { get; set; }
        public int PaviljonId { get; set; }

        // Veze sa ostalim klasama
        public virtual ICollection<Student> Students { get; set; }
        public virtual Paviljon Paviljon { get; set; }
        [InverseProperty("Soba1")]
        public virtual ICollection<ZahtjevZaPremjestanje> Soba1 { get; set; }
        [InverseProperty("Soba2")]
        public virtual ICollection<ZahtjevZaPremjestanje> Soba2 { get; set; }
        public virtual ZahtjevZaCimeraj ZahtjevZaCimeraj { get; set; }

        public Soba(int brojSobe, int kapacitet)
        {
            BrojSobe = brojSobe;
            Kapacitet = kapacitet;
        }

        public Soba(int brojSobe, int kapacitet, List<Student> studenti)
        {
            BrojSobe = brojSobe;
            Kapacitet = kapacitet;
            //Studenti = studenti;
        }

        public void DodajStudentaUSobu(Student student)
        {
            //Studenti.Add(student);
        }

        public void IzbaciStudentaIzSobe(Student student)
        {
            //Studenti.Remove(student);
        }

        public bool DaLiImaMjesta()
        {
            return Students.Count < Kapacitet;
        }

        public ISoba Clone()
        {
            Soba s = Clone() as Soba;
            s.BrojSobe++;
            StudentskiDomSingleton.Context.Soba.Add(s);
            return s;
        }
    }
}
