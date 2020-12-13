using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IMDB
{
    public class Gost
    {
        #region Atributi

        string username, password, ime, prezime, id;

        #endregion

        #region Properties

        public string Username 
        { 
            get => username;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 20
                    || value.Any(char.IsDigit))
                    throw new InvalidOperationException("Neispravan format za username!");

                username = value;
            }
        }

        public string Password 
        { 
            get => password;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 10
                    || !value.All(char.IsUpper))
                    throw new InvalidOperationException("Neispravan format za password!");

                password = value.GetHashCode().ToString(); ;
            }
        }

        public string Ime 
        { 
            get => ime;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.Substring(0, 1).All(char.IsUpper)
                    || !value.Substring(1).All(char.IsLower))
                    throw new InvalidOperationException("Neispravan format za ime!");

                ime = value;
            }
        }

        public string Prezime 
        { 
            get => prezime;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.Substring(0, 1).All(char.IsUpper)
                    || !value.Substring(1).All(char.IsLower))
                    throw new InvalidOperationException("Neispravan format za prezime!");

                prezime = value;
            }
        }

        public string Id 
        { 
            get => id;
        }

        #endregion

        #region Konstruktor

        public Gost(string user, string pass, string name, string surname)
        {
            id = IMDB.DajRandomID();
            Username = user;
            Password = pass;
            Ime = name;
            Prezime = surname;
        }

        public Gost()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda za promjenu ID-a korisnika.
        /// Ukoliko se unese netačan password ili netačan stari ID, ne omogućava se promjena ID-a.
        /// U suprotnom, umjesto starog ID zapisuje se novi ID u skladu s postojećom programskom logikom.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="stariID"></param>
        public void PromjenaID(string password, string stariID)
        {
            if (password.GetHashCode().ToString() != Password || stariID != Id)
                throw new Exception("Nedozvoljena promjena ID-a!");

            id = IMDB.DajRandomID();
        }

        #endregion
    }
}
