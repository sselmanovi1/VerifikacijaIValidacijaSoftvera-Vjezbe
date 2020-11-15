using EBank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            Banka b = new Banka();
            Klijent k = new Klijent();
            Racun r = new Racun(100);
            k.OtvoriNoviRacun(r);

            Kredit kredit = new Kredit(k, 50000, 1000, 0.05, DateTime.Now.AddYears(1));

            IZahtjev zahtjev = new Zahtjev();

            b.OdobriKredit(zahtjev, kredit);

            Assert.AreEqual(b.Krediti.Count, 0);
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestOtplateRateNormal()
        {
            Klijent k = new Klijent();
            Racun r = new Racun(1000);
            k.OtvoriNoviRacun(r);

            Kredit kredit = new Kredit(k, 500, 100, 0.02, DateTime.Now.AddYears(1));

            kredit.SkiniRatuKredita();

            Assert.AreEqual(k.Racuni[0].StanjeRacuna, 1000 - 102);
        }

        [TestMethod]
        public void TestOtplateSDrugogRačuna()
        {
            Klijent k = new Klijent();
            Racun r1 = new Racun(1000);
            Racun r2 = new Racun(1000);
            k.OtvoriNoviRacun(r1);
            k.OtvoriNoviRacun(r2);

            r1.PromijeniStanjeRačuna("BANKAR12345", -1000);
            r1.Blokiran = true;

            Kredit kredit = new Kredit(k, 500, 100, 0.02, DateTime.Now.AddYears(1));

            kredit.SkiniRatuKredita();

            Assert.AreEqual(k.Racuni[1].StanjeRacuna, 1000 - 102);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOtplateIzuzetak()
        {
            Klijent k = new Klijent();
            Racun r1 = new Racun(1000);
            Racun r2 = new Racun(1000);
            k.OtvoriNoviRacun(r1);
            k.OtvoriNoviRacun(r2);

            r1.PromijeniStanjeRačuna("BANKAR12345", -1000);
            r1.Blokiran = true;

            r2.PromijeniStanjeRačuna("BANKAR12345", -1000);
            r2.Blokiran = true;

            Kredit kredit = new Kredit(k, 500, 100, 0.02, DateTime.Now.AddYears(1));

            kredit.SkiniRatuKredita();
        }

        #endregion
    }
}
