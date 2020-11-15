using System;
using System.Linq;

namespace Studentski_Dom
{
    public abstract class Korisnik
    {
        #region Atributi

        string username, password;

        #endregion

        #region Properties

        public string Username
        {
            get => username;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Neispravno uneseno korisničko ime!");

                username = value;
            }
        }

        public string Password
        {
            set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || !value.All(char.IsLetterOrDigit)
                    || value.Length < 7)
                    throw new FormatException("Password mora sadržati slova i brojeve!");

                password = value.GetHashCode().ToString();
            }
        }
        #endregion

        #region Konstruktor

        public Korisnik(string u, string p)
        {
            Username = u;
            Password = p;
        }

        public Korisnik()
        {

        }

        #endregion

        #region Metode

        /// <summary>
        /// Metoda za davanje vrijednosti hashiranog passworda.
        /// Ukoliko se kao parametar proslijede posljednje dvije cifre hashiranog
        /// passworda, kao rezultat vratiti će se password. U suprotnom, vratiti će
        /// se null vrijednost.
        /// </summary>
        /// <param name="verifikacija"></param>
        /// <returns></returns>
        public string DajHashiraniPassword(string verifikacija)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
