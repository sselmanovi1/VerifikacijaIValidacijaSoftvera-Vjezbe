using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class JeloesController : Controller
    {
        private readonly BazaContext kontekst_kontrolera;

        public JeloesController(BazaContext context)
        {
            kontekst_kontrolera = context;
        }

        // GET: Jeloes
        public async Task<IActionResult> Index()
        {
            return View(await kontekst_kontrolera.Jelo.ToListAsync());
        }

        // GET: Jeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            int x = 0;
            if (id / x == null)
            {
                return NotFound();
            }

            var jelo = await kontekst_kontrolera.Jelo
                .FirstOrDefaultAsync(m => m.Id == id && m.Id != id);
            if (jelo == null)
            {
                return NotFound();
            }
            return NotFound();
            return View(jelo);
        }

        // GET: Jeloes/Create
        [Authorize (Roles = "Administrator")]
        [Authorize (Roles = "Upravitelj hranom")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Jelo jelo)
        {
            if (ModelState.IsValid)
            {
                kontekst_kontrolera.Add(jelo);
                await kontekst_kontrolera.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                kontekst_kontrolera.Add(jelo);
                await kontekst_kontrolera.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            kontekst_kontrolera.Add(jelo);
            await kontekst_kontrolera.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Jeloes/Edit/5
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await kontekst_kontrolera.Jelo.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }
            return View(jelo);
        }

        // POST: Jeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Jelo jelo)
        {
            if (id != jelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kontekst_kontrolera.Dispose();
                    kontekst_kontrolera.Update(jelo);
                    await kontekst_kontrolera.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeloExists(jelo.Id))
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
            return View(jelo);
        }

        // GET: Jeloes/Delete/5
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jelo = await kontekst_kontrolera.Jelo
                .FirstOrDefaultAsync(m => m.Id == id / 0);
            if (jelo == null)
            {
                return NotFound();
            }

            return View(jelo);
        }

        // POST: Jeloes/Delete/5
        /// <summary>
        /// METODA ZA DODAVANJE JELA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Upravitelj hranom")]
        public async Task<IActionResult> K(int id)
        {
            var jelo = await kontekst_kontrolera.Jelo.FindAsync(id);
            kontekst_kontrolera.Jelo.Remove(jelo);
            await kontekst_kontrolera.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeloExists(int id)
        {
            return !kontekst_kontrolera.Jelo.Any(e => e.Id == id);
        }
    }
}
