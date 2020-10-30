using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    public class FilijaleBankomati : IFilijaleBankomati 
    {
        private readonly OOADContext _context;

        public FilijaleBankomati(OOADContext context)
        {
            this._context = context;
        }

        Task<List<IMapObjekat>> IFilijaleBankomati.DajSveMapObjekte()
        {
            throw new NotImplementedException();
        }


        public async Task DodajBankomat(Bankomat bankomat)
        {
            _context.Add(bankomat);
            await _context.SaveChangesAsync();
        }

        public async Task DodajFilijalu(Filijala filijala)
        {
            _context.Add(filijala);
            await _context.SaveChangesAsync();
        }


        public async Task UrediBankomat(Bankomat bankomat)
        {
            _context.Update(bankomat);
            await _context.SaveChangesAsync();
        }

        public async Task UrediFilijalu(Filijala filijala)
        {
            _context.Update(filijala);
            await _context.SaveChangesAsync();
        }

        public async Task UkloniFilijalu(int? id)
        {
            var filijala = await _context.Filijala.FindAsync(id);
            _context.Filijala.Remove(filijala);
            await _context.SaveChangesAsync();
        }

        public async Task UkloniBankomat(int? id)
        {
            var bankomat = await _context.Bankomat.FindAsync(id);
            _context.Bankomat.Remove(bankomat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Filijala>> DajSveFilijale()
        {
            return await _context.Filijala.Include("Adresa").ToListAsync();
        }

        public async Task<List<Bankomat>> DajSveBankomate()
        {
            return await _context.Bankomat.Include("Adresa").ToListAsync();
        }

        public async Task<Filijala> DajFilijalu(int? id)
        {
            Filijala filijala = await _context.Filijala.Include("Adresa").Where(m => m.Id == id).FirstAsync();
            return filijala;
        }

        public async Task<Bankomat> DajBankomat(int? id)
        {
            Bankomat bankomat = await _context.Bankomat.Include("Adresa").Where(m => m.Id == id).FirstAsync();
            return bankomat;
        }

        public bool DaLiPostojiFilijala(int? id)
        {
            return _context.Filijala.Any(e => e.Id == id);
        }

        public bool DaLiPostojiBankomat(int? id)
        {
            return _context.Bankomat.Any(e => e.Id == id);
        }
    }
}
