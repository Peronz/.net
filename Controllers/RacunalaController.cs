using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Racunala.Data;
using Racunala.Models;

namespace Racunala.Controllers
{
    public class RacunalaController : Controller
    {
        private readonly RacunalaContext _context;

        public RacunalaController(RacunalaContext context)
        {
            _context = context;
        }

        // GET: Racunala
        public async Task<IActionResult> Index(string aktivnoRacunalo, string searchString)
{
    // Use LINQ to get list of genres.
    IQueryable<string> aktivnaQuery = from m in _context.Racunalo
                                    orderby m.Aktivno
                                    select m.Aktivno;

    var racunala = from m in _context.Racunalo
                 select m;

    if (!string.IsNullOrEmpty(searchString))
    {
        racunala = racunala.Where(s => s.Lokacija.Contains(searchString));
    }

    if (!string.IsNullOrEmpty(aktivnoRacunalo))
    {
        racunala = racunala.Where(x => x.Aktivno == aktivnoRacunalo);
    }

    var aktivnoRacunaloM = new AktivnaRacunala
    {
        Aktivna = new SelectList(await aktivnaQuery.Distinct().ToListAsync()),
        Racunala = await racunala.ToListAsync()
    };

    return View(aktivnoRacunaloM);
}
        // GET: Racunala/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunalo = await _context.Racunalo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunalo == null)
            {
                return NotFound();
            }

            return View(racunalo);
        }

        // GET: Racunala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racunala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lokacija,DatumPustanjaUPromet,Aktivno,DanasAktivno")] Racunalo racunalo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racunalo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(racunalo);
        }

        // GET: Racunala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunalo = await _context.Racunalo.FindAsync(id);
            if (racunalo == null)
            {
                return NotFound();
            }
            return View(racunalo);
        }

        // POST: Racunala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lokacija,DatumPustanjaUPromet,Aktivno,DanasAktivno")] Racunalo racunalo)
        {
            if (id != racunalo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racunalo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunaloExists(racunalo.Id))
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
            return View(racunalo);
        }

        // GET: Racunala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunalo = await _context.Racunalo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunalo == null)
            {
                return NotFound();
            }

            return View(racunalo);
        }

        // POST: Racunala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var racunalo = await _context.Racunalo.FindAsync(id);
            _context.Racunalo.Remove(racunalo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacunaloExists(int id)
        {
            return _context.Racunalo.Any(e => e.Id == id);
        }
    }
}
