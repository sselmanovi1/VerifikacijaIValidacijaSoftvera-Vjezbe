using System;
using System.Collections.Generic;

namespace IMDB
{
    public enum Zanr
    {
        Akcija,
        Triler,
        Kriminalisticki,
        Komedija,
        SciFi,
        Horor,
        Drama,
        None
    }

    public class Film
    {
        #region Atributi

        int id;
        static int brojač;
        string naziv;
        Zanr žanr;
        double ocjena;
        List<string> glumci;

        #endregion

        #region Properties

        public int Id 
        { 
            get => id;
        }

        public string Naziv 
        { 
            get => naziv;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naziv ne smije biti prazan!");

                naziv = value;
            }
        }

        public double Ocjena 
        { 
            get => ocjena;
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentException("Ocjena nije u dozvoljenom opsegu!");

                ocjena = value;
            }
        }

        public Zanr Žanr 
        { 
            get => žanr; 
            set => žanr = value; 
        }

        public List<string> Glumci 
        { 
            get => glumci;
            set
            {
                foreach (string glumac in value)
                    if (String.IsNullOrWhiteSpace(glumac))
                        throw new ArgumentException("Ime glumca je prazno!");

                glumci = value;
            }
        }

        #endregion

        #region Konstruktor

        public Film(string name, double rating, Zanr genre, List<string> actors)
        {
            brojač++;
            id = brojač.GetHashCode();

            Naziv = name;
            Ocjena = rating;
            Žanr = genre;

            if (actors == null)
                Glumci = new List<string>();
            else
                Glumci = actors;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda za kalkulisanje ocjene koristeći popularnost žanra.
        /// Ocjena filma množi se sa ocjenom žanra, koja je u osnovi jednaka 1.
        /// Žanrovi koji imaju pozitivnu ocjenu su: Komedija, SciFi i Drama.
        /// Ostali žanrovi imaju negativnu ocjenu.
        /// U slučaju da je žanr horor, ocjena se dodatno množi sa 5.
        /// U slučaju da je žanr komedija, ocjena se dodatno množi sa 4.
        /// Ako žanr nije specificiran (Zanr.None), dolazi do pojave izuzetka.
        /// </summary>
        /// <returns></returns>
        public double DajŽanrovskuOcjenu()
        {
            if (žanr == Zanr.None)
                throw new Exception("Žanr nije specificiran!");

            double žanrovskaOcjena = ocjena;
            List<Zanr> zanrovi = new List<Zanr>() { Zanr.Komedija, Zanr.SciFi, Zanr.Drama };
            bool postoji = false;
            foreach (Zanr z in zanrovi)
            {
                if (žanr == z)
                    postoji = true;
            }
            if (!postoji)
                žanrovskaOcjena *= -1;

            if (žanr == Zanr.Horor)
                žanrovskaOcjena *= 5;

            else if (žanr == Zanr.Komedija)
                žanrovskaOcjena *= 4;

            return žanrovskaOcjena;
        }

        #endregion
    }
}
