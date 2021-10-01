using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace turnos.Controllers
{
    public class AnalisisFinalController : Controller
    {
        private readonly TurnosContext _context;

        public AnalisisFinalController(TurnosContext context)
        {
            _context = context;
        }

        // GET: AnalisisFinal
        public async Task<IActionResult> Index()
        {
            var turnosContext = _context.AnalisisFinal.Include(a => a.OrdenDeTrabajo);
            return View(await turnosContext.ToListAsync());
        }

        // GET: AnalisisFinal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisisFinal = await _context.AnalisisFinal
                .Include(a => a.OrdenDeTrabajo)
                .FirstOrDefaultAsync(m => m.IdAnalisisFinal == id);
            if (analisisFinal == null)
            {
                return NotFound();
            }

            return View(analisisFinal);
        }

        // GET: AnalisisFinal/Create
        public IActionResult Create()
        {
            ViewData["IdOrdenDeTrabajo"] = new SelectList(_context.OrdenDeTrabajo, "IdOrdenDeTrabajo", "ValoresDePractica");
            return View();
        }

        // POST: AnalisisFinal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnalisisFinal,FechaEmision,IdOrdenDeTrabajo")] AnalisisFinal analisisFinal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analisisFinal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrdenDeTrabajo"] = new SelectList(_context.OrdenDeTrabajo, "IdOrdenDeTrabajo", "ValoresDePractica", analisisFinal.IdOrdenDeTrabajo);
            return View(analisisFinal);
        }

        // GET: AnalisisFinal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisisFinal = await _context.AnalisisFinal.FindAsync(id);
            if (analisisFinal == null)
            {
                return NotFound();
            }
            ViewData["IdOrdenDeTrabajo"] = new SelectList(_context.OrdenDeTrabajo, "IdOrdenDeTrabajo", "ValoresDePractica", analisisFinal.IdOrdenDeTrabajo);
            return View(analisisFinal);
        }

        // POST: AnalisisFinal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnalisisFinal,FechaEmision,IdOrdenDeTrabajo")] AnalisisFinal analisisFinal)
        {
            if (id != analisisFinal.IdAnalisisFinal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analisisFinal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalisisFinalExists(analisisFinal.IdAnalisisFinal))
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
            ViewData["IdOrdenDeTrabajo"] = new SelectList(_context.OrdenDeTrabajo, "IdOrdenDeTrabajo", "ValoresDePractica", analisisFinal.IdOrdenDeTrabajo);
            return View(analisisFinal);
        }

        // GET: AnalisisFinal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisisFinal = await _context.AnalisisFinal
                .Include(a => a.OrdenDeTrabajo)
                .FirstOrDefaultAsync(m => m.IdAnalisisFinal == id);
            if (analisisFinal == null)
            {
                return NotFound();
            }

            return View(analisisFinal);
        }

        // POST: AnalisisFinal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analisisFinal = await _context.AnalisisFinal.FindAsync(id);
            _context.AnalisisFinal.Remove(analisisFinal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalisisFinalExists(int id)
        {
            return _context.AnalisisFinal.Any(e => e.IdAnalisisFinal == id);
        }
    }
}
