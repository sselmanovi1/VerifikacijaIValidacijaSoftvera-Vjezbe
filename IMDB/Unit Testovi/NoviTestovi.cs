using IMDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });

            var imdb = new IMDB.IMDB();
            imdb.Filmovi.Add(film);

            IReziser r = new Reziser();

            List<Film> rezirani = imdb.DajSveFilmoveZaRezisera(r);

            Assert.IsTrue(rezirani.Contains(film));
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestPopularnostFilmaJednaLista()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Clan c = new Clan(new DateTime(2021, 1, 1));

            var imdb = new IMDB.IMDB();
            imdb.Clanovi.Add(c);
            imdb.DodajWatchlistu(c, new List<Film>() { film }, "Example");

            double popularnost = imdb.DajUkupnuPopularnostFilma(film);

            Assert.AreEqual(popularnost, film.DajéanrovskuOcjenu());
        }

        [TestMethod]
        public void TestPopularnostFilmaViöeListi()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Clan c = new Clan(new DateTime(2021, 1, 1));

            var imdb = new IMDB.IMDB();
            imdb.Clanovi.Add(c);
            imdb.DodajWatchlistu(c, new List<Film>() { film }, "Example 1");
            imdb.DodajWatchlistu(c, new List<Film>() { film }, "Example 2");

            double popularnost = imdb.DajUkupnuPopularnostFilma(film);

            Assert.AreEqual(popularnost, film.DajéanrovskuOcjenu() * 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPopularnostIzuzetak()
        {
            Film film = new Film("Need For Speed", 3.5, Zanr.Akcija, new List<string>() { "Aaron Paul", "Dominic Cooper" });
            Clan c = new Clan(new DateTime(2021, 1, 1));

            var imdb = new IMDB.IMDB();
            imdb.Clanovi.Add(c);

            double popularnost = imdb.DajUkupnuPopularnostFilma(film);
        }

        #endregion
    }
}
