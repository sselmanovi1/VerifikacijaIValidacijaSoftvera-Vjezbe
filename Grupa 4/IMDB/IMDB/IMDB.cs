using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB
{
    public class IMDB
    {
        #region Atributi

        static List<Gost> gosti = new List<Gost>();
        static List<Clan> clanovi = new List<Clan>();
        static List<Film> filmovi = new List<Film>();

        #endregion

        #region Properties

        public List<Gost> Gosti 
        { 
            get => gosti; 
        }

        public List<Clan> Clanovi 
        { 
            get => clanovi; 
        }

        public List<Film> Filmovi 
        { 
            get => filmovi; 
        }

        #endregion

        #region Konstruktor

        public IMDB()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda kojom se generiše novi random ID za goste.
        /// Svaki random ID sastoji se od niza nasumičnih cifara i ima 20 karaktera.
        /// U slučaju da neki gost ili korisnik već imaju generisani ID, potrebno je nanovo generisati ga
        /// dok se ne dobije ispravan ID kojeg nijedan korisnik u listama nema.
        /// </summary>
        /// <returns></returns>
        public static string DajRandomID()
        {
            string id = "";
            Random rand = new Random();
            bool nePostoji = false;

            while (!nePostoji) 
            {
                for (int i = 0; i < 20; i++)
                    id += rand.Next(10);

                if (gosti.Find(g => g.Id == id) != null || clanovi.Find(c => c.Id == id) != null)
                    continue;
                else
                    nePostoji = true;
            }

            return id;
        }

        public void RadSaKorisnicima(Gost korisnik, int opcija)
        {
            if (opcija == 0)
            {
                Gost postojeci = null;
                foreach (Gost g in gosti)
                {
                    if (g.Id == korisnik.Id)
                        postojeci = g;
                }

                if (postojeci == null)
                    foreach (Clan c in clanovi)
                    {
                        if (c.Id == korisnik.Id)
                            postojeci = c;
                    }

                if (postojeci == null)
                    if (korisnik is Clan)
                        clanovi.Add((Clan)korisnik);
                    else
                        gosti.Add(korisnik);

                else
                    throw new InvalidOperationException("Korisnik već postoji u sistemu!");
            }

            else if (opcija == 1)
            {
                Gost postojeci = null;
                foreach (Gost g in gosti)
                {
                    if (g.Id == korisnik.Id)
                        postojeci = g;
                }
                if (postojeci == null)
                    foreach (Clan c in clanovi)
                    {
                        if (c.Id == korisnik.Id)
                            postojeci = c;
                    }
                else
                {
                    gosti.Remove(postojeci);
                    return;
                }
                if (postojeci == null)
                    throw new ArgumentNullException("Korisnik ne postoji u sistemu!");
                else
                {
                    foreach (Clan c in clanovi)
                    {
                        if (c.Id == korisnik.Id)
                            postojeci = c;
                    }
                    clanovi.Remove((Clan)postojeci);
                }
            }
        }

        public void DodajWatchlistu(Clan c, List<Film> filmovi, string naziv)
        {
            foreach (Film film in filmovi)
                if (film.Naziv.Length < 1)
                    throw new ArgumentNullException("Ime filma je prazno!");

            c.Watchliste.Add(new Watchlist(naziv, filmovi));
        }

        public double DajUkupnuPopularnostFilma(Film film)
        {
            double popularnost = 0;
            bool postoji = false;

            foreach (Clan c in clanovi)
            {
                foreach (Watchlist lista in c.Watchliste)
                {
                    if (lista.Filmovi.Find(f => f.Id == film.Id) != null)
                    {
                        postoji = true;
                        popularnost += film.DajŽanrovskuOcjenu();
                    }
                }
            }

            if (!postoji)
                throw new ArgumentNullException("Film se ne nalazi ni na jednoj watchlisti!");

            return popularnost;
        }

        public List<Film> DajSveFilmoveZaRezisera(IReziser reziser)
        {
            List<Film> rezirani = new List<Film>();
            
            foreach(Film f in Filmovi)
            {
                if (reziser.DaLiJeReziraoFilm(f))
                    rezirani.Add(f);
            }

            return rezirani;
        }

        #endregion
    }
}
