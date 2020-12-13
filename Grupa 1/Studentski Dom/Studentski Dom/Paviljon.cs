using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IPodaci
    {
        string DajImePaviljona();
    }
    public class Paviljon : IPodaci
    {
        public string DajImePaviljona()
        {
            throw new NotImplementedException();
        }
    }
}
