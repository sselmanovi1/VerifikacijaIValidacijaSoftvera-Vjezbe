using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    public class Transakcije : ITransakcije
    {
        private readonly OOADContext _context;

        public Transakcije(OOADContext context)
        {
            _context = context;
        }

        public async Task<List<Transakcija>> DajSveTransakcije()
        {
            return await _context.Transakcija.Include("NaRacun").Include("SaRacuna").ToListAsync();
        }

        public async Task<List<Transakcija>> DajTransakcije(int? id)
        {
            return await _context.Transakcija.Include("NaRacun").Include("SaRacuna")
                .Include(c => c.SaRacuna.Klijent).Include(c => c.NaRacun.Klijent)
                .Where(c => c.SaRacuna.Klijent.Id == id || c.NaRacun.Klijent.Id == id).ToListAsync();
        }

        public async Task<Transakcija> DajTransakciju(int? id)
        {
            Transakcija transakcija = await _context.Transakcija.Include("NaRacun").Include("SaRacuna").Where(m => m.Id == id).FirstAsync();
            return transakcija;
        }

        public bool DaLiPostojiTransakcija(int? id)
        {
            return _context.Transakcija.Any(e => e.Id == id);
        }

        public async Task Uplati(Transakcija transakcija)
        {
            if (transakcija.SaRacuna.StanjeRacuna < transakcija.Iznos) return;
            transakcija.SaRacuna.StanjeRacuna = transakcija.SaRacuna.StanjeRacuna - transakcija.Iznos;
            if (transakcija.NaRacun != null)
            {
                transakcija.NaRacun.StanjeRacuna = transakcija.NaRacun.StanjeRacuna + transakcija.Iznos;
            }
            _context.Add(transakcija);
            await _context.SaveChangesAsync();
        }
    }
}
