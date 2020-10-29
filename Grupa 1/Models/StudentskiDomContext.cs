using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.Models
{
    public class StudentskiDomContext : IdentityDbContext
    {
        public StudentskiDomContext(DbContextOptions<StudentskiDomContext> options): base(options)
        {
        }

        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<PrebivalisteInfo> PrebivalisteInfo { get; set; }
        public DbSet<SkolovanjeInfo> SkolovanjeInfo { get; set; }
        public DbSet<ZahtjevZaUpis> ZahtjevZaUpis { get; set; }
        public DbSet<LicniPodaci> LicniPodaci { get; set; }
        public DbSet<ZahtjevZaPremjestanje> ZahtjevZaPremjestanje { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Soba> Soba { get; set; }
        public DbSet<ZahtjevZaCimeraj> ZahtjevZaCimeraj { get; set; }
        public DbSet<ZahtjevZaNabavkuNamirnica> ZahtjevZaNabavkuNamirnica { get; set; }
        public DbSet<StavkaNarudzbe> StavkaNarudzbe { get; set; }
        public DbSet<Paviljon> Paviljon { get; set; }
        public DbSet<Blagajna> Blagajna { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<Uprava> Uprava { get; set; }
        public DbSet<DnevniMeni> DnevniMeni { get; set; }
        public DbSet<Rucak> Rucak { get; set; }
        public DbSet<Vecera> Vecera { get; set; }
        public DbSet<ZahtjevStudenta> ZahtjevStudenta { get; set; }
        public DbSet<ZahtjevRestorana> ZahtjevRestorana { get; set; }
        public DbSet<Mjesec> Mjesec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<PrebivalisteInfo>().ToTable("PrebivalisteInfo");
            modelBuilder.Entity<SkolovanjeInfo>().ToTable("SkolovanjeInfo");
            //modelBuilder.Entity<ZahtjevZaUpis>().ToTable("ZahtjevZaUpit");
            modelBuilder.Entity<LicniPodaci>().ToTable("LicniPodaci");
            //modelBuilder.Entity<ZahtjevZaPremjestanje>().ToTable("ZahtjevZaPremjestanje");
            //modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Soba>().ToTable("Soba");
            //modelBuilder.Entity<ZahtjevZaCimeraj>().ToTable("ZahtjevZaCimeraj");
            //modelBuilder.Entity<ZahtjevZaNabavkuNamirnica>().ToTable("ZahtjevZaNabavkuNamirnica");
            modelBuilder.Entity<StavkaNarudzbe>().ToTable("StavkaNarudzbe");
            modelBuilder.Entity<Paviljon>().ToTable("Paviljon");
            modelBuilder.Entity<Blagajna>().ToTable("Blagajna");
            //modelBuilder.Entity<Restoran>().ToTable("Restoran");
            //modelBuilder.Entity<Uprava>().ToTable("Uprava");
            modelBuilder.Entity<DnevniMeni>().ToTable("DnevniMeni");
            modelBuilder.Entity<Rucak>().ToTable("Rucak");
            modelBuilder.Entity<Vecera>().ToTable("Vecera");
            //modelBuilder.Entity<ZahtjevStudenta>().ToTable("ZahtjevStudenta");
            //modelBuilder.Entity<ZahtjevRestorana>().ToTable("ZahtjevRestorana");
            modelBuilder.Entity<Mjesec>().ToTable("Mjesec");

            //dodano ovo za identity
            base.OnModelCreating(modelBuilder);
        }
    }
}