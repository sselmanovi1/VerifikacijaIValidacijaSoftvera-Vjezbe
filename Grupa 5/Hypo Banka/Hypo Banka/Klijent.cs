using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hypo_Banka
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
                if (String.IsNullOrEmpty(value)
                    || value.Length != 7
                    || !value.Substring(0, 3).All(char.IsDigit)
                    || !value.Substring(3, 1).All(char.IsLetter)
                    || !value.Substring(4).All(char.IsDigit))
                    throw new ArgumentException("Pogrešan broj lične karte!");

                brojLicneKarte = value;
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
        /// Metoda u kojoj se vraća ukupan iznos novca na svim računima klijenta.
        /// Ukoliko klijent nema nijedan račun, dolazi do pojave izuzetka, kao i u
        /// slučaju da su svi njegovi računi blokirani.
        /// </summary>
        /// <param name="r"></param>
        public double DajUkupanIznosNovcaNaSvimRačunima()
        {
            
            bool sviBlokirani = true;
            foreach (Racun r in Racuni)
            {
                if (r.StanjeRacuna > 0.0)
                {
                    sviBlokirani = false;
                    break;
                }
            }
            if (Racuni.Count == 0 || sviBlokirani)
                throw new Exception("Svi računi blokirani ili ih nema!");

            double ukupnoStanje = 0.0;
            foreach (Racun r in Racuni)
            {
                ukupnoStanje += r.StanjeRacuna;
            }

            return ukupnoStanje;
        }

        public bool SkiniIznosSaNekogOdRačuna(double ukupniIznos)
        {
            double preostaliIznos = ukupniIznos;
            foreach (Racun r in racuni)
            {
                if (!r.Blokiran)
                {
                    double razlika = preostaliIznos - r.StanjeRacuna;
                    if (razlika > 0)
                    {
                        r.PromijeniStanjeRačuna("BANKAR12345", -1 * (preostaliIznos - razlika));
                        preostaliIznos = razlika;
                    }
                    else
                    {
                        r.PromijeniStanjeRačuna("BANKAR12345", -preostaliIznos);
                        preostaliIznos = 0;
                    }

                }
            }
            if (preostaliIznos > 0)
                throw new InvalidOperationException("Nema dovoljno novca na računima!");

            return true;
        }

        #endregion
    }
}
