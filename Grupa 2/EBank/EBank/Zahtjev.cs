using System;
using System.Collections.Generic;
using System.Text;

namespace EBank
{
    public interface IZahtjev
    {
        bool DaLiJePovoljan();
    }
    public class Zahtjev : IZahtjev
    {
        public bool DaLiJePovoljan()
        {
            throw new NotImplementedException();
        }
    }
}
