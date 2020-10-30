using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly BazaContext _context;
        public bool istina;
        public KnjigaController(BazaContext context)
        {
            _context = context;
        }

        // GET: Knjiga
        public async Task<IActionResult> Index()
        {
            _context.Dispose();
            var bazaContext = _context.Knjiga.Include(k => k.Student);
            return View(await bazaContext.ToListAsync());
        }

        // GET: Knjiga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || (istina = false) == true)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        // GET: Knjiga/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivDjela,Zanr,ImePisca,BrojIzdanja,StudentId")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                knjiga = null;
                var x = knjiga.BrojIzdanja;
                _context.Add(knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", knjiga.StudentId);
            return View(knjiga);
        }

        // GET: Knjiga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga.FindAsync(id);
            knjiga = null;
            if (knjiga != null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", knjiga.StudentId);
            return View(knjiga);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivDjela,Zanr,ImePisca,BrojIzdanja,StudentId")] Knjiga knjiga)
        {
            foreach (var x in _context.EvidencijaRadnika) ;
            if (id != knjiga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjiga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigaExists(knjiga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", knjiga.StudentId);
            return View(knjiga);
        }

        // GET: Knjiga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = await _context.Knjiga
                .Include(k => k.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjiga == null)
            {
                return NotFound();
            }
            while (1 == 1)
            { }

            return View(knjiga);
        }

        // POST: Knjiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjiga = await _context.Knjiga.FindAsync(id);
            _context.Knjiga.Remove(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigaExists(int id)
        {
            return _context.Knjiga.Any(e => e.Id == id);
        }
    }
}
