using EBANK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Data
{
    public class OOADContext : DbContext
    {
        public OOADContext(DbContextOptions<OOADContext> options) : base(options)
        {
        }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Bankar> Bankar { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Adresa> Adresa { get; set; }
        public DbSet<Bankomat> Bankomat { get; set; }
        public DbSet<Filijala> Filijala { get; set; }
        public DbSet<Kredit> Kredit { get; set; }
        public DbSet<Novost> Novost { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }
        public DbSet<ZahtjevZaKredit> ZahtjevZaKredit { get; set; }
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Adresa>().ToTable("Adresa");
            modelBuilder.Entity<Bankomat>().ToTable("Bankomat");
            modelBuilder.Entity<Filijala>().ToTable("Filijala");
            modelBuilder.Entity<Kredit>().ToTable("Kredit");
            modelBuilder.Entity<Novost>().ToTable("Novost");
            modelBuilder.Entity<Racun>().ToTable("Racun");
            modelBuilder.Entity<Transakcija>().ToTable("Transakcija");
            modelBuilder.Entity<ZahtjevZaKredit>().ToTable("ZahtjevZaKredit");
        }
    }
}
