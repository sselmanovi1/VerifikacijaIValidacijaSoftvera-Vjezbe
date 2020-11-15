using System;
using System.Collections.Generic;
using System.Text;

namespace eParking
{
    public interface ITransakcija
    {
        DateTime DajVrijemeDolaska(Vozilo vozilo);
    }

    public class Transakcija : ITransakcija
    {
        public DateTime DajVrijemeDolaska(Vozilo vozilo)
        {
            throw new NotImplementedException();
        }
    }
}
