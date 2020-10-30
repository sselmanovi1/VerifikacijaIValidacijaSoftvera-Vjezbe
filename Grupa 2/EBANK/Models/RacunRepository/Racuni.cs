using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.RacunRepository
{
    public class Racuni : IRacuni
    {
        private OOADContext _context;

        public Racuni(OOADContext context)
        {
            _context = context;
        }

        public async Task<Racun> DajRacun(int? id)
        {
            Racun racun = await _context.Racun.Include("Klijent").Where(m => m.Id == id).FirstAsync();
            return racun;
        }

        public async Task<List<Racun>> DajSveRacune()
        {
            return await _context.Racun.Include("Klijent").Where(m => m.Id != 4).ToListAsync();
        }

        public bool DaLiPostojiRacun(int? id)
        {
            return _context.Racun.Any(e => e.Id == id);
        }

        public async Task OtvoriRacun(Racun racun)
        {
            _context.Add(racun);
            await _context.SaveChangesAsync();
        }

        public async Task ZatvoriRacun(int? id)
        {
            var racun = await _context.Racun.FindAsync(id);
            _context.Racun.Remove(racun);
            await _context.SaveChangesAsync();
        }

    
        public async Task<List<Racun>> DajSveRacuneKlijenta(int? id)
        {
            return await _context.Racun.Include("Klijent").Where(m => m.Klijent.Id == id).ToListAsync();
        }

        public async Task UrediStanjeRacuna(Racun racun)
        {
            var racun1 = await _context.Racun.Include("Klijent").Where(m => m.Id == racun.Id).FirstAsync();
            racun1.StanjeRacuna = racun.StanjeRacuna;
            _context.Update(racun1);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Racun>> DajRacune(int? id)
        {
            return await _context.Racun.Include("Klijent").Where(c => c.Klijent.Id == id).ToListAsync();
        }
    }
}

