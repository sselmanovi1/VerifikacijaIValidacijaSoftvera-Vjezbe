using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class Mjesec
    {
        public int MjesecId { get; set; }
        public string Naziv { get; set; }
        public int StudentId { get; set; }

        //Veze sa ostalim klasama
        public virtual Student Student { get; set; }

        public Mjesec(string naziv, int studentId)
        {
            Naziv = naziv;
            StudentId = studentId;
        }
    }
}
