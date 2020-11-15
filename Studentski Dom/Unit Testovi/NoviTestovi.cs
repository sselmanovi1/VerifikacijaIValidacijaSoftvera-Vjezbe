using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studentski_Dom;
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
            StudentskiDom dom = new StudentskiDom(15);

            Student s = new Student();
            s.Skolovanje = new Skolovanje();
            s.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s, 0);

            IPodaci paviljon = new Paviljon();

            List<Student> studenti = dom.DajStudenteIzPaviljona(paviljon);

            Assert.IsTrue(studenti.Find(student => student.IdentifikacioniBroj == s.IdentifikacioniBroj) != null);
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestAutomatskiEmail()
        {
            LicniPodaci lp = new LicniPodaci();

            lp.Ime = "Jennifer";
            lp.Prezime = "Harris";

            lp.AutomatskoPostavljanjeNedostajucihPodataka();

            Assert.AreEqual(lp.Email, "jharris1@etf.unsa.ba");
        }

        [TestMethod]
        public void TestAutomatskaSlika()
        {
            LicniPodaci lp = new LicniPodaci();

            lp.Prezime = "Harris";
            lp.DatumRodjenja = new DateTime(1980, 01, 01);

            lp.AutomatskoPostavljanjeNedostajucihPodataka();

            Assert.AreEqual(lp.Slika, "server.etf.unsa.ba/slike/Harris_01011980.jpg");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravniPodaci()
        {
            LicniPodaci lp = new LicniPodaci();

            lp.Email = "jharris1@eff.unsa.ba";

            lp.AutomatskoPostavljanjeNedostajucihPodataka();
        }

        #endregion
    }
}
