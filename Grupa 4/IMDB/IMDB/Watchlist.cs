using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB
{
    public class Watchlist
    {
        #region Atributi

        string naziv;
        List<Film> filmovi;

        #endregion

        #region Properties

        public string Naziv 
        { 
            get => naziv;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Neispravno ime za watchlistu!");

                naziv = value;
            }
        }
        public List<Film> Filmovi 
        { 
            get => filmovi;
        }

        #endregion

        #region Konstruktor

        public Watchlist(string name, List<Film> movies = null)
        {
            Naziv = name;

            if (movies == null)
                filmovi = new List<Film>();
            else
                filmovi = movies;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda za filtriranje filmova iz watchliste. Potrebno je vratiti samo one filmove
        /// čiji je žanr jednak vrijednosti parametra.
        /// Ukoliko u watchlisti nema nijedan film ili je žanr nedefinisan (Zanr.None), potrebno je baciti izuzetak.
        /// </summary>
        /// <param name="žanr"></param>
        /// <returns></returns>
        public List<Film> DajSveFilmoveKojiPripadajuŽanru(Zanr žanr)
        {
            if (Filmovi.Count < 1 || žanr == Zanr.None)
                throw new Exception("Nemoguće filtrirati filmove!");

            List<Film> filmovi = new List<Film>();

            foreach(Film f in Filmovi)
            {
                if (f.Žanr == žanr)
                    filmovi.Add(f);
            }

            return filmovi;
        }

        #endregion
    }
}
