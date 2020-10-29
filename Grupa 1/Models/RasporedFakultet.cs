using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class RasporedFakultet : IRaspored
    {
        public Soba RasporediStudenta(Student student)
        {
            Soba slobonda = null;



            foreach (Paviljon p in StudentskiDomSingleton.Context.Paviljon.ToList())
            {
                p.Sobe = StudentskiDomSingleton.Context.Soba.Where(s => s.PaviljonId == p.PaviljonId).ToList();

                foreach (Soba s in p.Sobe)
                {
                    s.Students = StudentskiDomSingleton.Context.Student.Where(st => st.SobaId == s.SobaId).ToList();

                    if (s.DaLiImaMjesta())
                    {
                        if (slobonda == null && s.Students.Count == 0)
                            slobonda = s;
                        else
                        {
                            foreach (Student st in s.Students)
                            {
                                st.SkolovanjeInfo = StudentskiDomSingleton.Context.SkolovanjeInfo.FirstOrDefault(si => si.SkolovanjeInfoId == st.SkolovanjeInfoId);

                                if (st.SkolovanjeInfo.Fakultet.Equals(student.SkolovanjeInfo.Fakultet))
                                    return s;
                            }
                        }
                    }
                }
            }
            return slobonda;
        }
    
    }
}
