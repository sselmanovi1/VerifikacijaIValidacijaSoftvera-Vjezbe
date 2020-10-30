using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.BankarRepository
{
    public class Bankari : IBankari
    {
        private OOADContext _context;

        public Bankari(OOADContext context)
        {
            _context = context;
        }

        public async Task<Bankar> DajBankara(int? id)
        {
            Bankar bankar = await _context.Bankar.Include("MjestoZaposlenja").Where(m => m.Id == id).FirstAsync();
            return bankar;
        }

        public async Task<Bankar> DajBankara(string korisnickoIme)
        {
            return await _context.Bankar.Where(m => m.KorisnickoIme == korisnickoIme).FirstOrDefaultAsync();
        }

        public async Task<List<Bankar>> DajSveBankare()
        {
            return await _context.Bankar.Include("MjestoZaposlenja").ToListAsync();
        }

        public bool DaLiPostojiBankar(int? id)
        {
            return _context.Bankar.Any(e => e.Id == id);
        }

        public async Task DodajBankara(Bankar bankar)
        {
            _context.Add(bankar);
            await _context.SaveChangesAsync();
        }

        public async Task UkloniBankara(int? id)
        {
            var bankar = await _context.Bankar.FindAsync(id);
            _context.Bankar.Remove(bankar);
            await _context.SaveChangesAsync();
        }

        public async Task UrediBankara(Bankar bankar)
        {
            _context.Update(bankar);
            await _context.SaveChangesAsync();
        }
    }
}
