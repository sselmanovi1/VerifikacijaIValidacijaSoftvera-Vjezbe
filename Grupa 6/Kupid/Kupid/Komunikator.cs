using System;
using System.Collections.Generic;
using System.Text;

namespace Kupid
{
    public class Komunikator
    {
        #region Atributi

        List<Korisnik> korisnici;
        List<Chat> razgovori;

        #endregion

        #region Properties

        public List<Korisnik> Korisnici 
        { 
            get => korisnici; 
        }

        public List<Chat> Razgovori 
        { 
            get => razgovori;  
        }

        #endregion

        #region Konstruktor

        public Komunikator()
        {
            korisnici = new List<Korisnik>();
            razgovori = new List<Chat>();
        }

        #endregion

        #region Metode

        public void RadSaKorisnikom(Korisnik k, int opcija)
        {
            if (opcija == 0)
            {
                Korisnik postojeci = null;
                foreach (Korisnik korisnik in korisnici)
                    if (korisnik.Ime == k.Ime)
                        postojeci = korisnik;

                if (postojeci != null)
                    throw new InvalidOperationException("Korisnik već postoji!");

                korisnici.Add(k);
            }
            else if (opcija == 1)
            {
                Korisnik postojeci = null;
                foreach (Korisnik korisnik in korisnici)
                    if (korisnik.Ime == k.Ime)
                        postojeci = korisnik;

                if (postojeci == null)
                    throw new InvalidOperationException("Korisnik ne postoji!");

                korisnici.Remove(k);

                List<Chat> razgovoriZaBrisanje = new List<Chat>();
                foreach(Chat c in razgovori)
                {
                    bool postoji = false;
                    foreach (Korisnik korisnik in c.Korisnici)
                    {
                        if (korisnik.Ime == k.Ime)
                            postoji = true;
                    }
                    if (postoji)
                        razgovoriZaBrisanje.Add(c);
                }

                foreach (Chat brisanje in razgovoriZaBrisanje)
                    razgovori.Remove(brisanje);
            }
        }

        public void DodavanjeRazgovora(List<Korisnik> korisnici, bool grupniChat)
        {
            if (korisnici == null || korisnici.Count < 2 || (!grupniChat && korisnici.Count > 2))
                throw new ArgumentException("Nemoguće dodati razgovor!");

            if (grupniChat)
                razgovori.Add(new GrupniChat(korisnici));

            else
                razgovori.Add(new Chat(korisnici[0], korisnici[1]));
        }

        /// <summary>
        /// Metoda u kojoj se vrši pronalazak svih poruka koje u sebi sadrže traženi sadržaj.
        /// Ukoliko je sadržaj prazan ili ne postoji nijedan chat, baca se izuzetak.
        /// U razmatranje se uzimaju i grupni, i individualni chatovi, a ne smije se uzeti u razmatranje
        /// nijedan chat u kojem se nalazi korisnik sa imenom "admin".
        /// </summary>
        public List<Poruka> IzlistavanjeSvihPorukaSaSadržajem(string sadržaj)
        {
            if (razgovori.Count < 1 || String.IsNullOrWhiteSpace(sadržaj))
                throw new Exception("Izlistavanje nije moguće!");

            List<Poruka> poruke = new List<Poruka>();
            foreach(Chat razgovor in razgovori)
            {
                if (razgovor.Korisnici.Find(k => k.Ime == "admin") != null)
                    continue;

                foreach (Poruka p in razgovor.Poruke)
                {
                    if (p.Sadrzaj.Contains(sadržaj))
                        poruke.Add(p);
                }
            }

            return poruke;
        }

        public bool DaLiJeSpajanjeUspjesno(Chat c, IRecenzija r)
        {
            if (c is GrupniChat)
                throw new InvalidOperationException("Grupni chatovi nisu podržani!");

            if (c.Poruke.Find(poruka => poruka.IzračunajKompatibilnostKorisnika() == 100) != null
                && r.DajUtisak() == "Pozitivan")
                return true;

            else
                return false;
        }

        public void SpajanjeKorisnika()
        {
            bool stvorenRazgovor = false;
            foreach(Korisnik prvi in korisnici)
            {
                foreach(Korisnik drugi in korisnici)
                {
                    if (prvi.Ime == drugi.Ime)
                        continue;
                    if (razgovori.Find(r => r.Korisnici.Find(k => k.Ime == prvi.Ime) != null && r.Korisnici.Find(k => k.Ime == drugi.Ime) != null) != null)
                        continue;

                    if (prvi.Lokacija == drugi.ZeljenaLokacija || prvi.ZeljenaLokacija == drugi.Lokacija
                        || prvi.Godine == drugi.Godine)
                    {
                        stvorenRazgovor = true;
                        Chat noviChat = new Chat(prvi, drugi);
                        razgovori.Add(noviChat);
                    }
                }
            }
            if (!stvorenRazgovor)
                throw new ArgumentException("Nemoguće spojiti korisnike!");
        }

        #endregion
    }
}
