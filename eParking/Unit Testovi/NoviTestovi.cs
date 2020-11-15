using eParking;
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
            Lokacija l = new Lokacija("Kampus", new List<string>() { "Zmaja od Bosne" }, 2.50, 50);
            Clan c = new Clan(DateTime.Now.AddYears(1));
            Parking p = new Parking();
            p.DodajKorisnika(c, true);
            p.RadSaLokacijom(l, 0);

            p.RezervišiParking(c, l);

            ITransakcija transakcija = new Transakcija();

            p.OslobodiParkingMjesto(transakcija, c);

            Assert.AreEqual(p.Lokacije[0].DajTrenutniBrojSlobodnogMjesta(), 1);
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestZaradaJednaUlica()
        {
            Lokacija l = new Lokacija("Kampus", new List<string>() { "Zmaja od Bosne" }, 2.50, 50);
            Clan c = new Clan("user1", "password12", "Adresa", new Vozilo("Automobil", "123-A-123", 5), DateTime.Now.AddYears(1));
            Parking p = new Parking();
            p.DodajKorisnika(c, true);
            p.RadSaLokacijom(l, 0);

            p.RezervišiParking(c, l);
            double zarada = p.IzračunajTrenutnuZaradu();

            Assert.AreEqual(zarada, 2.50);
        }

        [TestMethod]
        public void TestZaradaVišeUlica()
        {
            Lokacija l1 = new Lokacija("Kampus", new List<string>() { "Zmaja od Bosne" }, 2.50, 50);
            Lokacija l2 = new Lokacija("Ilidža", new List<string>() { "Željeznička", "Sarajevska" }, 1.50, 100);
            Clan c1 = new Clan("user1", "password12", "Adresa", new Vozilo("Automobil", "123-A-123", 5), DateTime.Now.AddYears(1));
            Clan c2 = new Clan("user2", "password12", "Adresa", new Vozilo("Automobil", "124-A-124", 5), DateTime.Now.AddYears(1));
            Parking p = new Parking();
            p.DodajKorisnika(c1, true);
            p.DodajKorisnika(c2, true);
            p.RadSaLokacijom(l1, 0);
            p.RadSaLokacijom(l2, 0);

            p.RezervišiParking(c1, l1);
            p.RezervišiParking(c2, l2);
            double zarada = p.IzračunajTrenutnuZaradu();

            Assert.AreEqual(zarada, 2.50 + 1.50 / 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestZaradaIzuzetak()
        {
            Lokacija l = new Lokacija("Kampus", new List<string>() { }, 2.50, 50);
            Clan c = new Clan("user1", "password12", "Adresa", new Vozilo("Automobil", "123-A-123", 5), DateTime.Now.AddYears(1));
            Parking p = new Parking();
            p.DodajKorisnika(c, true);
            p.RadSaLokacijom(l, 0);

            p.RezervišiParking(c, l);

            double zarada = p.IzračunajTrenutnuZaradu();
        }

        #endregion
    }
}
