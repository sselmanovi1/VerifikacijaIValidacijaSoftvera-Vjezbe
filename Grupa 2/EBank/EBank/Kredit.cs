using System;
using System.Collections.Generic;
using System.Text;

namespace EBank
{
    public class Kredit
    {
        #region Atributi

        Klijent klijent;
        double iznos, rata, kamatnaStopa;
        DateTime rokOtplate;

        #endregion

        #region Properties

        public Klijent Klijent
        {
            get => klijent;
            set => klijent = value;
        }

        public double Iznos
        {
            get => iznos;
            set
            {
                if (value < 0.00 || value > 100000.00)
                    throw new InvalidOperationException("Pogrešna vrijednost iznosa!");

                iznos = value;
            }
        }

        public double Rata
        {
            get => rata;
            set
            {
                if (value < 0.00 || value > 4000.00)
                    throw new InvalidOperationException("Pogrešna vrijednost rate!");

                rata = value;
            }
        }

        public double KamatnaStopa
        {
            get => kamatnaStopa;
            set
            {
                if (value < 0.02 || value > 0.1)
                    throw new ArgumentException("Pogrešan iznos kamatne stope!");

                kamatnaStopa = value;
            }
        }

        public DateTime RokOtplate
        {
            get => rokOtplate;
            set
            {
                if (DateTime.Compare(value, DateTime.Now) < 0 ||
                    DateTime.Now.AddYears(10) < value)
                    throw new ArgumentException("Pogrešan rok otplate!");

                rokOtplate = value;
            }
        }

        #endregion

        #region Konstruktor

        public Kredit(Klijent client, double amount, double monthlyAmount, double interestRate, DateTime dueDate)
        {
            Klijent = client;
            Iznos = amount;
            Rata = monthlyAmount;
            KamatnaStopa = interestRate;
            RokOtplate = dueDate;
        }

        #endregion

        #region Metode

        public bool SkiniRatuKredita()

        {
            Racun racun = klijent.Racuni.Find(r => r.StanjeRacuna > 0.00);
            if (racun == null)
                throw new InvalidOperationException("Svi računi su prazni!");

            racun.PromijeniStanjeRačuna("BANKAR12345", -Rata * (1.00 + kamatnaStopa));
            return true;
        }

        #endregion
    }
}
