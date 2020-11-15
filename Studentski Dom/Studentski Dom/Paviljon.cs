using System;

namespace Studentski_Dom
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
