using System;
using System.Collections.Generic;
using System.Text;

namespace EBank
{
    public class Banka
    {
        #region Atributi

        List<Klijent> klijenti;
        List<Kredit> krediti;

        #endregion

        #region Properties

        public List<Klijent> Klijenti
        {
            get => klijenti;
        }

        public List<Kredit> Krediti
        {
            get => krediti;
        }

        #endregion

        #region Konstruktor

        public Banka()
        {
            klijenti = new List<Klijent>();
            krediti = new List<Kredit>();
        }

        #endregion

        #region Metode

        public void RadSaKlijentom(Klijent k, int opcija, List<string> podaci)
        {
            if (opcija == 0)
            {
                Klijent klijent = null;
                foreach (Klijent client in Klijenti)
                {
                    if (client.BrojLicneKarte == k.BrojLicneKarte)
                        klijent = client;
                }
                klijenti.Add(k);
            }
            else if (opcija == 1)
            {
                Klijent klijent = null;
                foreach (Klijent client in Klijenti)
                {
                    if (client.BrojLicneKarte == k.BrojLicneKarte)
                        klijent = client;
                }
                if (klijent != null)
                {
                    if (podaci != null && podaci.Count > 4)
                        klijent.PromjenaPodataka(podaci[0], podaci[1], podaci[2], podaci[3], podaci[4]);
                }
            }

            else if (opcija == 2)
            {
                Klijent klijent = null;
                foreach (Klijent client in Klijenti)
                {
                    if (client.BrojLicneKarte == k.BrojLicneKarte)
                        klijent = client;
                }
                klijenti.Remove(klijent);
            }
        }

        public void OtvaranjeNovogRačuna(Klijent k, Racun r)
        {
            Klijent klijent = klijenti.Find(client => client.BrojLicneKarte == k.BrojLicneKarte);
            if (klijent == null)
                throw new ArgumentNullException("Klijent nije registrovan!");

            klijent.OtvoriNoviRacun(r);
        }

        /// <summary>
        /// Metoda u kojoj se vrši blokiranje računa klijenta.
        /// Ukoliko klijent ili račun nisu registrovani, baca se izuzetak.
        /// U suprotnom, blokiranje računa se vrši u skladu s postojećom programskom logikom.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="r"></param>
        public void BlokiranjeRacuna(Klijent k, Racun r)
        {
            Klijent klijent = Klijenti.Find(client => client.BrojLicneKarte == k.BrojLicneKarte);
            if (klijent == null)
                throw new Exception("Klijent ne postoji!");

            Racun racun = klijent.Racuni.Find(account => account.BrojRacuna == r.BrojRacuna);
            if (racun == null)
                throw new Exception("Klijent nema specificirani račun!");

            racun.Blokiran = true;
        }

        public void DajKredit(Kredit kredit)
        {
            Klijent k = klijenti.Find(client => client.BrojLicneKarte == kredit.Klijent.BrojLicneKarte);

            if (k == null || Krediti.Count > 99)
                throw new InvalidOperationException("Nemoguće dati kredit klijentu!");

            krediti.Add(kredit);
        }

        public bool OdobriKredit(IZahtjev zahtjev, Kredit kredit)
        {
            if (zahtjev.DaLiJePovoljan())
            {
                DajKredit(kredit);
                return true;
            }

            return false;
        }

        #endregion
    }
}
