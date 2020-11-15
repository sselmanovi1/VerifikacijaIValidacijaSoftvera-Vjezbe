using System;
using System.Collections.Generic;

namespace Studentski_Dom
{
    public class Soba
    {
        #region Atributi

        int brojSobe, kapacitet;
        List<Student> stanari;

        #endregion

        #region Properties

        public int BrojSobe
        {
            get => brojSobe;
        }

        public int Kapacitet
        {
            get => kapacitet;
        }

        public List<Student> Stanari
        {
            get => stanari;
        }

        #endregion

        #region Konstruktor

        public Soba(int id, int veličina)
        {
            brojSobe = id;
            kapacitet = veličina;
            stanari = new List<Student>();
        }

        #endregion

        #region Metode

        public void DodajStanara(Student student)
        {
            if (Stanari.Count == Kapacitet)
                throw new InvalidOperationException("Soba je popunjena!");

            Stanari.Add(student);
        }

        public void IsprazniSobu()
        {
            Stanari.Clear();
        }

        public void IzbaciStudenta(Student student)
        {
            Student stanar = Stanari.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj);

            if (stanar == null)
                throw new ArgumentException("Student nije stanar sobe!");

            Stanari.Remove(stanar);
        }

        public bool DaLiJeStanar(Student student)
        {
            return Stanari.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj) != null;
        }

        #endregion
    }
}
