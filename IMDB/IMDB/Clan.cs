using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB
{
    public class Clan : Gost
    {
        #region Atributi

        List<Watchlist> watchliste;
        DateTime rokPretplate;

        #endregion

        #region Properties

        public List<Watchlist> Watchliste
        {
            get => watchliste;
        }
        public DateTime RokPretplate
        {
            get => rokPretplate;
        }

        #endregion

        #region Konstruktor

        public Clan(string user, string pass, string name, string surname, DateTime endDate)
            : base(user, pass, name, surname)
        {
            watchliste = new List<Watchlist>();
            rokPretplate = endDate;
        }

        public Clan(DateTime endDate)
            : base()
        {
            watchliste = new List<Watchlist>();
            rokPretplate = endDate;
        }

        #endregion

        #region Metode

        public void ProdužiRok(DateTime noviRok)
        {
            rokPretplate = noviRok;
        }

        public void ResetujListe()
        {
            watchliste.Clear();
        }

        #endregion
    }
}
