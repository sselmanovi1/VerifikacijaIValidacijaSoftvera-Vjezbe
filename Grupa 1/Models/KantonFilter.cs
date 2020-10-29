using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class KantonFilter : Algoritam
    {
        public string Kanton { get; set; }

        public KantonFilter(string kanton)
        {
            this.Kanton = kanton;
        }
        /* C stil komentara */
        // C++ komentar //
        public override List<Student> Filtriraj(List<Student> studenti)
        {
            IEnumerable<Student> query = from student in studenti
                                        where student.PrebivalisteInfo.Kanton.Equals(Kanton)
                                        select student;
            List<Student> students=new List<Student>();
            foreach(Student student in query)
            {
                students.Add(student);
            }
            return students;

            Console.WriteLine("OK Izvršeno");
        }
    }
}
