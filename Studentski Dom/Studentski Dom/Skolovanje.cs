using System;

namespace Studentski_Dom
{
    public class Skolovanje
    {
        #region Atributi

        string maticniFakultet, brojIndeksa;
        int godinaStudija, ciklusStudija;

        #endregion

        #region Properties

        public string MaticniFakultet
        {
            get => maticniFakultet;
            set => maticniFakultet = value;
        }
        public string BrojIndeksa
        {
            get => brojIndeksa;
            set => brojIndeksa = value;
        }
        public int GodinaStudija
        {
            get => godinaStudija;
            set => godinaStudija = value;
        }
        public int CiklusStudija
        {
            get => ciklusStudija;
            set => ciklusStudija = value;
        }

        #endregion

        #region Konstruktor

        public Skolovanje()
        {
            maticniFakultet = "Elektrotehnički fakultet";
            brojIndeksa = StudentskiDom.GenerišiSljedećiBroj();
            GodinaStudija = 1;
            CiklusStudija = 1;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda kojom se vrši prelazak na sljedeću godinu studija.
        /// Ukoliko nema prelaska s jednog na drugi ciklus studija, samo se povećava
        /// vrijednost godine studija. Pri prelasku na drugi ciklus studija,
        /// vrši se dodavanje trenutnog brojača za broj indeksa iz studentskog doma
        /// na trenutni broj indeksa u formatu "brojač/stari broj indeksa".
        /// Napomena: Metoda za dobavljanje brojača već je definisana!
        /// </summary>
        /// <returns></returns>
        public bool PređiNaSljedećuGodinu()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
