using Domari;
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
        public void TestPrviCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(1, 1);

            Assert.AreEqual(1800, skolarina);
        }

        [TestMethod]
        public void TestDrugiCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(2, 2);

            Assert.AreEqual(2000, skolarina);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravniPodaci()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }

        #endregion
    }
}
