using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public interface IStudentskiDom
    {
        void UpisiStudenta(Student student);
        void BrisiStudenta(Student student);
    }
}
