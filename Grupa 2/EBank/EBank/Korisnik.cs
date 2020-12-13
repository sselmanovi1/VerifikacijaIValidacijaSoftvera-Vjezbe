using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EBank
{
    public abstract class Korisnik
    {
        #region Atributi

        static int brojač = 0;
        int id;
        string ime, prezime, korisnickoIme, lozinka;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
        }

        public string Ime
        {
            get => ime;
            set
            {
                if (value == null || value.Length < 1
                    || !(value.Substring(0, 1).All(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new ArgumentException("Ime je neispravno!");

                ime = value;
            }
        }

        public string Prezime
        {
            get => prezime;
            set
            {
                if (value == null || value.Length < 1
                    || !(value.Substring(0, 1).All(char.IsUpper)
                    && value.Substring(1).All(char.IsLower)))
                    throw new ArgumentException("Prezime je neispravno!");

                prezime = value;
            }
        }
        public string KorisnickoIme
        {
            get => korisnickoIme;
            set
            {
                if (value == null || value.Length < 1)
                    throw new ArgumentException("Korisničko ime je neispravno!");

                korisnickoIme = value;
            }
        }
        public string Lozinka
        {
            get => lozinka;
            set
            {
                if (value == null || value.Length < 20
                    || value.Any(char.IsWhiteSpace) || value.All(char.IsLetterOrDigit))
                    throw new ArgumentException("Lozinka je neispravna!!");

                byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                lozinka = System.Text.Encoding.ASCII.GetString(data);
            }
        }

        #endregion

        #region Konstruktor

        public Korisnik(string name, string surname, string username, string password)
        {
            Ime = name;
            Prezime = surname;
            KorisnickoIme = username;
            Lozinka = password;

            brojač++;
            id = brojač;
        }

        public Korisnik()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda u kojoj se omogućava promjena korisničkih podataka korisnika.
        /// Ukoliko se hashevi trenutnog passworda ne poklapaju, baca se izuzetak.
        /// U suprotnom, onaj podatak koji je proslijeđen kao parametar se mijenja,
        /// a vrijednosti ostalih atributa se ne mijenjaju.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void PromjenaPodataka(string oldPass, string name = null, string surname = null, string user = null, string pass = null)
        {
            if (!String.IsNullOrWhiteSpace(oldPass))
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(oldPass);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                string hashirani = System.Text.Encoding.ASCII.GetString(data);

                if (hashirani != Lozinka)
                    throw new Exception("Netačna lozinka!");
                else
                {
                    if (name != null)
                        Ime = name;
                    if (surname != null)
                        Prezime = surname;
                    if (user != null)
                        KorisnickoIme = user;
                    if (pass != null)
                        Lozinka = pass;
                }
            }
        }

        #endregion
    }
}
