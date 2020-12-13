using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_Lot
{
    public class Parking
    {
        #region Atributi

        List<Korisnik> korisnici;
        List<Lokacija> lokacije;

        #endregion

        #region Properties

        public List<Korisnik> Korisnici
        {
            get => korisnici;
        }

        public List<Lokacija> Lokacije
        {
            get => lokacije;
        }

        #endregion

        #region Konstruktor

        public Parking()
        {
            korisnici = new List<Korisnik>();
            lokacije = new List<Lokacija>();
        }

        #endregion

        #region Metode

        public void RadSaLokacijom(Lokacija l, int opcija, List<string> podaci = null)
        {
            if (opcija == 0)
            {
                if (Lokacije.Find(lokacija => lokacija.Naziv == l.Naziv) != null)
                    throw new InvalidOperationException("Lokacija već postoji!");

                Lokacije.Add(l);
            }
            else if (opcija == 1)
            {
                Lokacija lokacija = Lokacije.Find(loc => loc.Naziv == l.Naziv);
                if (lokacija == null)
                    throw new InvalidOperationException("Lokacija ne postoji!");

                Lokacije.Remove(lokacija);
            }
            else if (opcija == 2)
            {
                Lokacija lokacija = Lokacije.Find(loc => loc.Naziv == l.Naziv);
                if (lokacija == null)
                    throw new InvalidOperationException("Lokacija ne postoji!");

                foreach (string ulica in podaci)
                    if (!lokacija.Ulice.Contains(ulica))
                        lokacija.Ulice.Add(ulica);
            }
        }

        public void DodajKorisnika(Korisnik k, bool clan)
        {
            Korisnik korisnik = null;
            foreach (Korisnik kor in Korisnici)
            {
                if (kor.Username == k.Username)
                    korisnik = kor;
            }

            if (korisnik != null && !clan)
                throw new ArgumentException("Korisnik već postoji!");
            else if (korisnik != null)
            {
                foreach (Korisnik kor in Korisnici)
                {
                    if (kor.Username == k.Username)
                        korisnik = kor;
                }
                Korisnici.Remove(korisnik);
                Korisnici.Add(k);
            }
            else
                Korisnici.Add(k);
        }

        public void RezervišiParking(Clan c, Lokacija l)
        {
            Tuple<int, Lokacija> pm = new Tuple<int, Lokacija>(l.DajTrenutniBrojSlobodnogMjesta(), l);
            c.RezervisanoParkingMjesto = pm;
        }

        public void OslobodiParkingMjesto(ITransakcija transakcija, Clan c)
        {
            if (transakcija.DajVrijemeDolaska(c.Vozilo).AddHours(24) < DateTime.Now)
            {
                c.RezervisanoParkingMjesto.Item2.OslobodiMjesto();
                c.RezervisanoParkingMjesto = null;
            }
            else
                throw new InvalidOperationException("Još uvijek nisu prošla 24 sata!");
        }

        /// <summary>
        /// Metoda u kojoj se vrši pretvaranje korisnika u člana.
        /// Prvo je potrebno pronaći postojećeg korisnika sa poslanim korisničkim imenom.
        /// Ukoliko korisnik ne postoji, baca se izuzetak.
        /// Podacima od pronađenog korisnika dodaje se nasumično generisani password sa
        /// ispravnim formatom prema postojećoj programskoj logici, a članarina mu se
        /// odobrava na narednih godinu dana. Zatim se password vraća kao rezultat metode.
        /// </summary>
        /// <param name="username"></param>
        public string DodavanjeČlana(string username)
        {
            Korisnik k = Korisnici.Find(korisnik => korisnik.Username == username);
            if (k == null)
                throw new Exception("Član ne postoji!");

            Random rand = new Random();
            string password = "";
            for (int i = 0; i < 15; i++)
                password += rand.Next(10).ToString();

            Clan c = new Clan(k.Username, password, k.Adresa, k.Vozilo, DateTime.Now.AddYears(1));

            Korisnici.Remove(k);
            Korisnici.Add(c);

            return password;
        }

        public double DajUkupnuMogućuDobitZaKorisnika(Clan c)
        {
            if (Lokacije.Count < 1)
                throw new ArgumentNullException("Nema nijedne lokacije!");

            double zarada = 0;
            
            foreach (Lokacija l in Lokacije)
            {
                zarada += l.Cijena * l.Ulice.Count;
            }

            zarada /= c.Vozilo.BrojSjedišta;

            return zarada;
        }

        #endregion
    }
}
