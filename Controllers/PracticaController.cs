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
    public class PracticaController : Controller
    {
        private readonly TurnosContext _context;

        public PracticaController(TurnosContext context)
        {
            _context = context;
        }

        // GET: Practica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Practica.ToListAsync());
        }

        // GET: Practica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practica = await _context.Practica
                .FirstOrDefaultAsync(m => m.IdPractica == id);
            if (practica == null)
            {
                return NotFound();
            }

            return View(practica);
        }

        // GET: Practica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Practica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPractica,Codigo,NombrePractica")] Practica practica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(practica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practica);
        }

        // GET: Practica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practica = await _context.Practica.FindAsync(id);
            if (practica == null)
            {
                return NotFound();
            }
            return View(practica);
        }

        // POST: Practica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPractica,Codigo,NombrePractica")] Practica practica)
        {
            if (id != practica.IdPractica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracticaExists(practica.IdPractica))
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
            return View(practica);
        }

        // GET: Practica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practica = await _context.Practica
                .FirstOrDefaultAsync(m => m.IdPractica == id);
            if (practica == null)
            {
                return NotFound();
            }

            return View(practica);
        }

        // POST: Practica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var practica = await _context.Practica.FindAsync(id);
            _context.Practica.Remove(practica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracticaExists(int id)
        {
            return _context.Practica.Any(e => e.IdPractica == id);
        }
    }
}
