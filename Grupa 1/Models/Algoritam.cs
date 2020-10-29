using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public abstract class Algoritam
    {
        public List<Student> TemplateMethod(List<Student> studenti) {
            List<Student> students = new List<Student>(studenti);
            students = Filtriraj(students);
            students = Sortiraj(students);
            return students;
        }

        public virtual List<Student> Sortiraj(List<Student> studenti)
        {
            return studenti;
        } 

        public virtual List<Student>  Filtriraj(List<Student> studenti)
        {
            return studenti;
        }


    }
}
