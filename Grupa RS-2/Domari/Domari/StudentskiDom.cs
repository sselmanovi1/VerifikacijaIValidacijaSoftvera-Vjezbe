using System;
using System.Collections.Generic;
using System.Text;

namespace Domari
{
    public class StudentskiDom
    {
        #region Atributi

        static string brojač;
        List<Student> studenti;
        List<Soba> sobe;

        #endregion

        #region Properties

        public List<Student> Studenti
        {
            get => studenti;
        }

        public List<Soba> Sobe
        {
            get => sobe;
        }

        #endregion

        #region Konstruktor

        public StudentskiDom(int brojSoba)
        {
            studenti = new List<Student>();
            sobe = new List<Soba>();
            for (int i = 0; i < brojSoba; i++)
            {
                int brojSobe = 100 + i;
                int kapacitet = 2;
                if (i != 0 && i >= brojSoba / 3 && i < brojSoba * 2 / 3)
                {
                    brojSobe += 100;
                    kapacitet += 1;
                }
                else if (i != 0 && i >= brojSoba * 2 / 3)
                {
                    brojSobe += 200;
                    kapacitet += 2;
                }
                Sobe.Add(new Soba(brojSobe, kapacitet));
            }
        }

        #endregion

        #region Metode

        public static string GenerišiSljedećiBroj()
        {
            int trenutniBrojInt;
            Int32.TryParse(brojač, out trenutniBrojInt);
            trenutniBrojInt += 1;
            brojač = trenutniBrojInt.ToString();
            return brojač;
        }

        public void RadSaStudentom(Student student, int opcija)
        {
            if (opcija == 0)
            {
                Student st = null;
                foreach (Student s in Studenti)
                {
                    if (s.IdentifikacioniBroj == student.IdentifikacioniBroj)
                        st = s;
                }
                if (st != null)
                    throw new DuplicateWaitObjectException("Nemoguće dodati postojećeg studenta!");
                Studenti.Add(student);
            }
            else if (opcija == 1)
            {
                Soba soba = null;
                foreach (Soba s in Sobe)
                    if (s.DaLiJeStanar(student))
                    {
                        soba = s;
                    }

                if (soba == null)
                    throw new InvalidOperationException("Student nije stanar nijedne sobe!");
                soba.IzbaciStudenta(student);
            }
            else if (opcija == 2)
            {
                Student studentIzListe = null;
                foreach (Student s in Studenti)
                    if (s.IdentifikacioniBroj == student.IdentifikacioniBroj)
                        studentIzListe = s;

                if (studentIzListe == null)
                    throw new MissingMemberException("Student nije prijavljen u dom!");
                Studenti.Remove(studentIzListe);
            }
        }

        public void UpisUDom(Student student, int zeljeniKapacitet, bool fleksibilnost)
        {
            Soba slobodnaSoba = null;
            foreach (Soba s in Sobe)
            {
                if (s.Kapacitet == zeljeniKapacitet && s.Stanari.Count < zeljeniKapacitet)
                {
                    slobodnaSoba = s;
                    break;
                }
            }
            if (slobodnaSoba == null && !fleksibilnost)
                throw new InvalidOperationException("Nema slobodnih soba za studenta!");
            else if (slobodnaSoba == null)
            {
                Soba biloKoja = null;
                foreach (Soba s in Sobe)
                {
                    if (s.Stanari.Count < s.Kapacitet)
                    {
                        slobodnaSoba = s;
                        break;
                    }
                }
                if (biloKoja == null)
                    throw new IndexOutOfRangeException("Nema slobodnih soba u domu!");
                biloKoja.DodajStanara(student);
            }
            else
                slobodnaSoba.DodajStanara(student);
        }

        /// <summary>
        /// Metoda u kojoj se vrši promjena informacija o sobi u domu.
        /// Ukoliko soba ne mijenja kapacitet, potrebno je izbaciti sve studente
        /// iz sobe. Ukoliko soba mijenja kapacitet, potrebno je provjeriti
        /// da li se kapacitet smanjuje ili povećava. Ukoliko se kapacitet smanjuje,
        /// potrebno je izbaciti višak studenata a ostaviti one koji mogu ostati.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="istiKapacitet"></param>
        public void PromjenaSobe(Soba soba, int noviKapacitet)
        {
            if (noviKapacitet == soba.Kapacitet)
                soba.Stanari.Clear();
            else if (noviKapacitet < soba.Kapacitet)
            {
                while (soba.Stanari.Count > noviKapacitet)
                    soba.Stanari.RemoveAt(0);
            }

            soba.Kapacitet = noviKapacitet;
        }

        public List<Student> DajStudenteIzPaviljona(IPodaci paviljon)
        {
            List<Student> studenti = new List<Student>();
            foreach (Student s in Studenti)
            {
                if (s.Skolovanje.MaticniFakultet == paviljon.DajImePaviljona())
                    studenti.Add(s);
            }
            return studenti;
        }

        #endregion
    }
}
