using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student : Korisnik
    {
        #region Atributi

        static int trenutniBroj = 0;
        int identifikacioniBroj;
        LicniPodaci podaci;
        List<string> prebivaliste;
        Skolovanje skolovanje;
        double stanjeRacuna;

        #endregion

        #region Properties

        public int IdentifikacioniBroj
        {
            get => identifikacioniBroj;
        }
        public LicniPodaci Podaci
        {
            get => podaci;
            set => podaci = value;
        }
        public List<string> Prebivaliste
        {
            get => prebivaliste;
            set => prebivaliste = value;
        }
        public Skolovanje Skolovanje
        {
            get => skolovanje;
            set => skolovanje = value;
        }
        public double StanjeRacuna 
        { 
            get => stanjeRacuna; 
        }

        #endregion

        #region Konstruktor

        public Student(string user, string pass, LicniPodaci data, List<string> address, Skolovanje school)
            : base(user, pass)
        {
            Podaci = data;
            Skolovanje = school;

            if (address == null)
                Prebivaliste = new List<string>();
            else
                Prebivaliste = address;

            trenutniBroj += 1;
            identifikacioniBroj = trenutniBroj;

            stanjeRacuna = 1000.00;
        }

        public Student()
        {

        }

        #endregion

        #region Metode

        public void AzurirajStanjeRacuna(double iznos)
        {
            stanjeRacuna += iznos;
        }

        /// <summary>
        /// Metoda u okviru koje se vrši plaćanje obaveza prema studentskom domu.
        /// Ukoliko na računu studenta ima dovoljno novca, skida se iznos koji je
        /// proslijeđen kao parametar. Također se skida i iznos provizije od 1.5 KM.
        /// Ukoliko nema dovoljno novca, potrebno je baciti izuzetak odgovarajućeg tipa.
        /// </summary>
        /// <param name="iznos"></param>
        public void Placanje(double iznos)
        {
            if (StanjeRacuna < iznos + 1.5)
                throw new Exception("Nema dovoljno novca na računu!");
            else
                AzurirajStanjeRacuna(-iznos - 1.5);
        }

        #endregion
    }
}
