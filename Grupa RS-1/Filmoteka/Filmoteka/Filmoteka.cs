using System;
using System.Collections.Generic;
using System.Text;

namespace Filmoteka
{
    public class Filmoteka
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

        public Filmoteka()
        {

        }

        #endregion

        #region Metode

        public void RadSaKorisnicima(Gost korisnik, int opcija)
        {
            if (opcija == 0)
            {
                Gost postojeci = null;
                foreach (Gost k in gosti)
                {
                    if (k.Id == korisnik.Id)
                        postojeci = k;
                }
                if (postojeci == null)
                    foreach (Clan k in clanovi)
                    {
                        if (k.Id == korisnik.Id)
                            postojeci = k;
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
                foreach (Gost k in gosti)
                {
                    if (k.Id == korisnik.Id)
                        postojeci = k;
                }
                if (postojeci == null)
                    foreach (Clan k in clanovi)
                    {
                        if (k.Id == korisnik.Id)
                            postojeci = k;
                    }
                else
                {
                    gosti.Remove(postojeci);
                    return;
                }
                if (postojeci == null)
                    throw new ArgumentNullException("Korisnik ne postoji u sistemu!");
                else
                    clanovi.Remove(clanovi.Find(k => k.Id == korisnik.Id));
            }
        }

        public void DodajWatchlistu(Clan c, List<Film> filmovi, string naziv)
        {
            foreach (Film film in filmovi)
                if (film.Naziv.Length < 1)
                    throw new ArgumentNullException("Ime filma je prazno!");

            c.Watchliste.Add(new Watchlist(naziv, filmovi));
        }

        public List<Film> DajSveFilmoveZaRezisera(IReziser reziser)
        {
            List<Film> rezirani = new List<Film>();

            foreach (Film f in Filmovi)
            {
                if (reziser.DaLiJeReziraoFilm(f))
                    rezirani.Add(f);
            }

            return rezirani;
        }

        /// <summary>
        /// Metoda za filtriranje liste filmova prema glumcima.
        /// Ukoliko je lista filmova ili glumaca prazna, baca se izuzetak.
        /// U suprotnom, vraćaju se svi filmovi koji u listi glumaca imaju sve glumce koji su proslijeđeni kao parametar.
        /// </summary>
        /// <param name="glumci"></param>
        /// <returns></returns>
        public List<Film> DajSveFilmoveSGlumcima(List<string> glumci)
        {
            if (filmovi.Count < 1 || glumci == null || glumci.Count < 1)
                throw new Exception("Prazna lista!");

            List<Film> filtrirani = new List<Film>();

            foreach(Film f in filmovi)
            {
                bool sviGlumci = true;
                foreach (string glumac in glumci)
                    if (!f.Glumci.Contains(glumac))
                    {
                        sviGlumci = false;
                        break;
                    }
                if (sviGlumci)
                    filtrirani.Add(f);
            }

            return filtrirani;
        }

        public void DodajNastavak(Film film, double rating, bool istiGlumci, List<string> noviGlumci = null)
        {
            Film postojeci = Filmovi.Find(f => f.Id == film.Id);
            if (postojeci == null)
                throw new ArgumentNullException("Film nije registrovan!");

            string noviNaziv = film.Naziv + " 2";
            if (istiGlumci)
                noviGlumci = film.Glumci;

            Film nastavak = new Film(noviNaziv, rating, film.Žanr, noviGlumci);
            Filmovi.Add(nastavak);
        }

        #endregion
    }
}
