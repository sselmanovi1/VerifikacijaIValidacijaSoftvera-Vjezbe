using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.KlijentRepository
{
    public class Klijenti : IKlijenti
    {
        private OOADContext _context;

        public Klijenti(OOADContext context)
        {
            _context = context;
        }

        public async Task<Klijent> DajKlijenta(int? id)
        {
            Klijent klijent = await _context.Klijent.Include("Adresa").Where(m => m.Id == id).FirstAsync();
            return klijent;
        }

        public async Task<Klijent> DajKlijenta(string korisnickoIme)
        {
            return await _context.Klijent.Where(m => m.KorisnickoIme == korisnickoIme).FirstOrDefaultAsync();
        }

        public async Task<Klijent> DajKlijentaLK(string brojLicneKarte)
        {
            return await _context.Klijent.Where(m => m.BrojLicneKarte == brojLicneKarte).FirstOrDefaultAsync();
        }

        public async Task<List<Klijent>> DajSveKlijente()
        {
            return await _context.Klijent.Where((m => m.KorisnickoIme != "a")).ToListAsync();
        }

        public bool DaLiPostojiKlijent(int? id)
        {
            return _context.Klijent.Any(e => e.Id == id);
        }

        public async Task DodajKlijenta(Klijent klijent)
        {
            _context.Add(klijent);
            await _context.SaveChangesAsync();
        }

        public async Task UkloniKlijenta(int? id)
        {
            var klijent = await _context.Klijent.FindAsync(id);
            _context.Klijent.Remove(klijent);
            await _context.SaveChangesAsync();
        }

        public async Task UrediKlijenta(Klijent klijent)
        {
            _context.Update(klijent);
            await _context.SaveChangesAsync();
        }
    }
}
