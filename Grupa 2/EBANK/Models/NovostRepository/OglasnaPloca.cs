using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.NovostRepository
{
    public class OglasnaPloca : IOglasnaPloca
    {
        private OOADContext _context;

        public OglasnaPloca(OOADContext context)
        {
            _context = context;
        }

        public async Task<Novost> DajNovost(int? id)
        {
            Novost novost= await _context.Novost.FindAsync(id);
            return novost;
        }

        public async Task<List<Novost>> DajSveNovosti()
        {
            return await _context.Novost.ToListAsync();
        }

        public async Task<List<Novost>> DajSvePrikazaneNovosti()
        {
            return await _context.Novost.Where(n => n.Prikazana).ToListAsync();
        }

        public bool DaLiPostojiNovost(int? id)
        {
            return _context.Novost.Any(e => e.Id == id);
        }

        public async Task DodajNovost(Novost novost)
        {
            _context.Add(novost);
            await _context.SaveChangesAsync();
        }

        public async Task UkloniNovost(int? id)
        {
            var novost = await _context.Novost.FindAsync(id);
            _context.Novost.Remove(novost);
            await _context.SaveChangesAsync();
        }

        public async Task UrediNovost(Novost novost)
        {
            _context.Update(novost);
            await _context.SaveChangesAsync();
        }
    }
}
