using EBANK.Data;
using EBANK.Models.KreditRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.ZahtjevZaKreditRepository
{
    public class ZahtjeviZaKredit : IZahtjeviZaKredit
    {
        private OOADContext _context;
        private IZahtjevObserver zahtjevObserver;

        public ZahtjeviZaKredit(OOADContext context)
        {
            _context = context;
            zahtjevObserver = new Krediti(context);
        }
        public async Task<List<ZahtjevZaKredit>> DajSveZahtjeve()
        {
            return await _context.ZahtjevZaKredit.Include("Racun").Include(c => c.Racun.Klijent).Where(zahtjev=>zahtjev.StatusZahtjeva == StatusZahtjevaZaKredit.Neobradjen).ToListAsync();
        }

        public async Task<ZahtjevZaKredit> DajZahtjev(int? id)
        {
            ZahtjevZaKredit zahtjev = await _context.ZahtjevZaKredit.Include("Racun").Include(c => c.Racun.Klijent).Where(zahtjev => zahtjev.Id == id).FirstAsync(); ;
            return zahtjev;
        }

        public bool DaLiPostojiZahtjev(int? id)
        {
            return _context.ZahtjevZaKredit.Any(e => e.Id == id);
        }

        public async Task PodnesiZahtjevZaKredit(ZahtjevZaKredit zahtjevZaKredit)
        {
            _context.Add(zahtjevZaKredit);
            await _context.SaveChangesAsync();
        }

        public async Task RijesiZahtjev(int? id, bool prihvacen)
        {
            ZahtjevZaKredit zahtjev = await _context.ZahtjevZaKredit.Include("Racun").Where(zahtjev => zahtjev.Id == id).FirstAsync();
            if (prihvacen)
            {

                Kredit _noviKredit = new Kredit();
                _noviKredit.Racun = zahtjev.Racun;
                _noviKredit.Iznos = zahtjev.Iznos;
                _noviKredit.KamatnaStopa = zahtjev.KamatnaStopa;
                _noviKredit.RokOtplate = zahtjev.RokOtplate;
                await zahtjevObserver.NaOdobrenZahtjev(_noviKredit);
                zahtjev.StatusZahtjeva = StatusZahtjevaZaKredit.Odobren;
            }
            else zahtjev.StatusZahtjeva = StatusZahtjevaZaKredit.Odbijen;
            _context.ZahtjevZaKredit.Update(zahtjev);
            await _context.SaveChangesAsync();
        }

    }
}
