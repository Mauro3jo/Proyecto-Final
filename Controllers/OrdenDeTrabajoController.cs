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
    public class OrdenDeTrabajoController : Controller
    {
        private readonly TurnosContext _context;

        public OrdenDeTrabajoController(TurnosContext context)
        {
            _context = context;
        }

        // GET: OrdenDeTrabajo
        public async Task<IActionResult> Index()
        {
            var turnosContext = _context.OrdenDeTrabajo.Include(o => o.Orden);
             ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList() 
            select new{ IdPaciente = paciente.IdPaciente, NombreCompleto= paciente.Nombre +""+ paciente.Apellido, paciente.DNI})
            ,"IdPaciente","NombreCompleto", "DNI");
              ViewData["IdPractica"] = new SelectList((from practica in _context.Practica.ToList() 
            select new{ IdPractica = practica.IdPractica, practica.NombrePractica, practica.Codigo})
            ,"IdPractica", "Codigo");

            return View(await turnosContext.ToListAsync());
        }

        // GET: OrdenDeTrabajo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .Include(o => o.Orden)
                .FirstOrDefaultAsync(m => m.IdOrdenDeTrabajo == id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Create
        public IActionResult Create()
        {
            ViewData["IdOrden"] = new SelectList(_context.Orden, "IdOrden", "IdOrden");
            return View();
        }

        // POST: OrdenDeTrabajo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenDeTrabajo,ValoresDePractica,IdOrden")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrden"] = new SelectList(_context.Orden, "IdOrden", "IdOrden", ordenDeTrabajo.IdOrden);
            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }
            ViewData["IdOrden"] = new SelectList(_context.Orden, "IdOrden", "IdOrden", ordenDeTrabajo.IdOrden);
            return View(ordenDeTrabajo);
        }

        // POST: OrdenDeTrabajo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenDeTrabajo,ValoresDePractica,IdOrden")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (id != ordenDeTrabajo.IdOrdenDeTrabajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeTrabajoExists(ordenDeTrabajo.IdOrdenDeTrabajo))
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
            ViewData["IdOrden"] = new SelectList(_context.Orden, "IdOrden", "IdOrden", ordenDeTrabajo.IdOrden);
            return View(ordenDeTrabajo);
        }

        // GET: OrdenDeTrabajo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenDeTrabajo = await _context.OrdenDeTrabajo
                .Include(o => o.Orden)
                .FirstOrDefaultAsync(m => m.IdOrdenDeTrabajo == id);
            if (ordenDeTrabajo == null)
            {
                return NotFound();
            }

            return View(ordenDeTrabajo);
        }

        // POST: OrdenDeTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenDeTrabajo = await _context.OrdenDeTrabajo.FindAsync(id);
            _context.OrdenDeTrabajo.Remove(ordenDeTrabajo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeTrabajoExists(int id)
        {
            return _context.OrdenDeTrabajo.Any(e => e.IdOrdenDeTrabajo == id);
        }
    }
}
