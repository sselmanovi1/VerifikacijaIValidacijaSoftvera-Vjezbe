using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace eParking
{
    public class Vozilo
    {

        #region Atributi

        string vrsta, tablice;
        int brojSjedišta;

        #endregion

        #region Properties

        public string Vrsta
        {
            get => vrsta;
            set
            {
                List<string> vrste = new List<string>() { "Automobil", "Motor", "Autobus", "Kamionet", "Minibus" };
                if (vrste.Find(element => element == value) == null)
                    throw new ArgumentException("Nepostojeća vrsta vozila!");

                vrsta = value;
            }
        }

        public string Tablice
        {
            get => tablice;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length != 9
                    || !value.Substring(0, 3).All(char.IsDigit)
                    || !(value.Substring(3, 1) == "-")
                    || !value.Substring(4, 1).All(char.IsUpper)
                    || !(value.Substring(5, 1) == "-")
                    || !value.Substring(6).All(char.IsDigit))
                    throw new FormatException("Neispravan format tablica!");

                tablice = value;
            }
        }

        public int BrojSjedišta
        {
            get => brojSjedišta;
            set
            {
                if (value < 0)
                    throw new FormatException("Neispravan broj sjedišta!");

                brojSjedišta = value;
            }
        }

        #endregion

        #region Konstruktor

        public Vozilo(string type, string plates, int noSeats)
        {
            Vrsta = type;
            Tablice = plates;
            BrojSjedišta = noSeats;
        }

        #endregion

    }
}
