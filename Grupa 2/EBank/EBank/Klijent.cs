using System;
using System.Collections.Generic;
using System.Linq;

namespace EBank
{
    public class Klijent : Korisnik
    {
        #region Atributi

        DateTime datumRodenja;
        string brojLicneKarte;
        List<Racun> racuni;

        #endregion

        #region Properties

        public DateTime DatumRodenja
        {
            get => datumRodenja;
            set
            {
                if (DateTime.Compare(DateTime.Now, value) < 0
                    || value.AddYears(18) > DateTime.Now)
                    throw new InvalidOperationException("Datum nije ispravan!");

                datumRodenja = value;
            }
        }
        public string BrojLicneKarte
        {
            get => brojLicneKarte;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Pogrešan broj lične karte!");
                else if (!String.IsNullOrEmpty(value))
                {
                    if (value.Length != 7
                        || !value.Substring(0, 3).All(char.IsDigit)
                        || !value.Substring(3, 1).All(char.IsLetter)
                        || !value.Substring(4).All(char.IsDigit))
                        throw new ArgumentException("Pogrešan broj lične karte!");
                    else
                    {
                        brojLicneKarte = value;
                    }
                }
                else
                {
                    brojLicneKarte = value;
                }
                
            }
        }
        public List<Racun> Racuni
        {
            get => racuni;
        }

        #endregion

        #region Konstruktor

        public Klijent(string ime, string prezime, string korisnickoIme, string lozinka,
            DateTime rodenje, string licna)
            : base(ime, prezime, korisnickoIme, lozinka)
        {
            DatumRodenja = rodenje;
            BrojLicneKarte = licna;
            racuni = new List<Racun>();
        }

        public Klijent() : base()
        {
            racuni = new List<Racun>();
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda u kojoj se otvara novi račun za klijenta.
        /// Klijent ne može imati više od 3 računa.
        /// Ukoliko već posjeduje jedan ili više računa, a neki od tih računa je
        /// blokiran, ne dopušta se otvaranje novog računa.
        /// </summary>
        /// <param name="r"></param>
        public void OtvoriNoviRacun(Racun r)
        {
            if (racuni.Count > 2 || racuni.Find(racun => racun.Blokiran) != null)
                throw new Exception("Ne možete otvoriti novi račun!");

            racuni.Add(r);
        }

        #endregion
    }
}
