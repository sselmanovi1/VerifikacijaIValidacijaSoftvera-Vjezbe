using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public interface IRaspored
    {
        Soba RasporediStudenta(Student student);
    }
}
