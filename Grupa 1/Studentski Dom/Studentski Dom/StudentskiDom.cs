using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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
                if (Studenti.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj) != null)
                    throw new DuplicateWaitObjectException("Nemoguće dodati postojećeg studenta!");
                Studenti.Add(student);
            }
            else if (opcija == 1)
            {
                Soba soba = Sobe.Find(s => s.DaLiJeStanar(student));
                if (soba == null)
                    throw new InvalidOperationException("Student nije stanar nijedne sobe!");
                soba.IzbaciStudenta(student);
            }
            else if (opcija == 2)
            {
                Student studentIzListe = Studenti.Find(s => s.IdentifikacioniBroj == student.IdentifikacioniBroj);
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
                if (s.Kapacitet == zeljeniKapacitet)
                    foreach (Soba s2 in Sobe)
                        if (s2.Stanari.Count < zeljeniKapacitet && s2 == s)
                            slobodnaSoba = s;
            }
            if (slobodnaSoba == null && !fleksibilnost)
                throw new InvalidOperationException("Nema slobodnih soba za studenta!");
            else if (slobodnaSoba == null)
            {
                Soba biloKoja = null;
                foreach (Soba s in Sobe)
                {
                    if (s.Stanari.Count < s.Kapacitet)
                        biloKoja = s;
                }
                if (biloKoja == null)
                    throw new IndexOutOfRangeException("Nema slobodnih soba u domu!");
                biloKoja.DodajStanara(student);
            }
            else
                slobodnaSoba.DodajStanara(student);
        }

        /// <summary>
        /// Metoda u kojoj se vrši premještaj studenta iz jedne u drugu sobu.
        /// Ukoliko student želi u sobu sa istim kapacitetom, premještaj se vrši u
        /// takvu sobu u kojoj ima slobodnog mjesta ili se baca izuzetak.
        /// U suprotnom se student smješta u bilo koju slobodnu sobu.
        /// Ukoliko nema nijedne slobodne sobe u domu, baca se izuzetak.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="istiKapacitet"></param>
        public void PremjestajStudenta(Student student, bool istiKapacitet)
        {
            if (Sobe != null && Sobe.Count > 0)
            {
                Soba slobodnaSoba = Sobe.Find(s => s.Stanari.Count < s.Kapacitet && !s.Stanari.Contains(student));
                if (slobodnaSoba == null)
                    throw new InvalidOperationException("Nema slobodnih soba u domu!");

                if (istiKapacitet)
                {
                    Soba trenutnaSoba = Sobe.Find(s => s.Stanari.Contains(student));
                    slobodnaSoba = Sobe.Find(s => s.Stanari.Count < s.Kapacitet && s.Kapacitet == trenutnaSoba.Kapacitet && !s.Stanari.Contains(student));
                    if (slobodnaSoba == null)
                        throw new InvalidOperationException("Nema slobodnih soba istog kapaciteta!");
                }
                slobodnaSoba.DodajStanara(student);
            }
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
