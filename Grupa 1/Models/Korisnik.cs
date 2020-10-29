using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentskiDom.Models
{
    public class Korisnik
    {
        public int Id { get; set; }

        [Index(IsUnique=true)]
        public string Username { get; set; }
        public string Password { get; set; }

        // Veze sa ostalim klasama
        //public virtual ICollection<Zahtjev> Zahtjevi { get; set; }
        public virtual Student Student { get; set; }
        public virtual Restoran Restoran { get; set; }
        public virtual Uprava Uprava { get; set; }

        public Korisnik()
        {
            Username = "";
            Password = "";
        }

        public Korisnik(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
