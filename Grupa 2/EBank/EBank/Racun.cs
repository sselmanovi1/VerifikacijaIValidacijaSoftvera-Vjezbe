using System;
using System.Collections.Generic;
using System.Text;

namespace EBank
{
    public class Racun
    {
        #region Atributi

        string brojRacuna;
        double stanjeRacuna;
        bool blokiran;

        #endregion

        #region Properties

        public string BrojRacuna
        {
            get => brojRacuna;
        }
        public double StanjeRacuna
        {
            get => stanjeRacuna;
        }
        public bool Blokiran
        {
            get => blokiran;
            set
            {
                if (stanjeRacuna > 0.0 && value == true)
                    throw new ArgumentException("Račun nije prazan!");
                else if (stanjeRacuna < 0.1 && value == false)
                    throw new ArgumentException("Račun je prazan!");

                blokiran = value;
            }
        }

        #endregion

        #region Konstruktor

        public Racun(double pocetnoStanje)
        {
            GenerišiBrojRačuna();
            stanjeRacuna = pocetnoStanje;
            Blokiran = false;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda u kojoj se vrši generisanje random broja računa.
        /// Svaki račun ima 15 karaktera. Svi karakteri su brojevi koji se nasumično
        /// odabiraju.
        /// </summary>
        /// <returns></returns>
        public void GenerišiBrojRačuna()
        {
            Random no = new Random();
            brojRacuna = "";
            for (int i = 0; i < 15; i++)
                brojRacuna += no.Next(10).ToString();
        }

        public void PromijeniStanjeRačuna(string verifikacija, double promjena)
        {
            if (verifikacija == "BANKAR12345")
                stanjeRacuna += promjena;
            else
                throw new AccessViolationException("Niste autorizovani za vršenje promjene!");
        }

        #endregion
    }
}
