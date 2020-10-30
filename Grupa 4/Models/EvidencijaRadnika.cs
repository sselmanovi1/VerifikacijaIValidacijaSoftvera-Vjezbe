using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekemin.Models
{
    public class EvidencijaRadnika
    {
        public int Id { get; set; }
        /* KOMENTAR */
        public virtual ICollection<Radnik> RADNICI { get; set; }

    }
}
