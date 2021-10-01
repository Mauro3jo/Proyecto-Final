using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class OrdenController : Controller
    {
        private readonly TurnosContext _context;

        public OrdenController(TurnosContext context)
        {
            _context = context;
        }

        // GET: Orden
        public async Task<IActionResult> Index()
        {
            var turnosContext = _context.Orden.Include(o => o.Paciente).Include(o => o.Practica);
            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList() 
            select new{ IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre +""+ paciente.Apellido,DNI = paciente.DNI})
            ,"IdPaciente","NombreCompleto", "DNI");
            ViewData["IdPractica"] = new SelectList((from practica in _context.Practica.ToList() 
            select new{ IdPractica = practica.IdPractica, NombrePractica= practica.NombrePractica, Codigo = practica.Codigo})
            ,"IdMedico","NombrePractica","Codigo");
            
            return View(await turnosContext.ToListAsync());
            
        }
        public JsonResult ObtenerPaciente(int IdPaciente)
          {
              var Pacientes = _context.Orden.Where(t => t.IdPaciente == IdPaciente)
              .Select(t => new{
                  t.IdPaciente,
                  t.Paciente.Nombre,
                  t.Paciente.Apellido,
                  t.Paciente.DNI,
                  t.Paciente.FechaNac,
                  Paciente = t.Paciente.Nombre + ","+ t.Paciente.Apellido,
              })
              .ToList();
              return Json(Pacientes);
          }

        // GET: Orden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Paciente)
                .Include(o => o.Practica)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Orden/Create
        public IActionResult Create()
        {
            //ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "FechaNac");
          //  ViewData["DNI"] = new SelectList(_context.Paciente, "IdPaciente", "DNI");
          //  ViewData["Apellido"] = new SelectList(_context.Paciente, "IdPaciente", "Apellido");
//ViewData["Nombre"] = new SelectList(_context.Paciente, "IdPaciente", "Nombre");
           // ViewData["IdPractica"] = new SelectList(_context.Practica, "IdPractica", "NombrePractica");
            return View();
        }

        // POST: Orden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrden,NumeroOrden,FechaIngreso,IdPaciente,IdPractica")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "FechaNac", orden.IdPaciente);
           // ViewData["DNI"] = new SelectList(_context.Paciente, "IdPaciente", "DNI", orden.IdPaciente);
           //  ViewData["Apellido"] = new SelectList(_context.Paciente, "IdPaciente", "Apellido", orden.IdPaciente);
           //  ViewData["Nombre"] = new SelectList(_context.Paciente, "IdPaciente", "Nombre", orden.IdPaciente);
         //   ViewData["IdPractica"] = new SelectList(_context.Practica, "IdPractica", "NombrePractica", orden.IdPractica);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "DNI", orden.IdPaciente);
            ViewData["IdPractica"] = new SelectList(_context.Practica, "IdPractica", "NombrePractica", orden.IdPractica);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrden,NumeroOrden,FechaIngreso,IdPaciente,IdPractica")] Orden orden)
        {
            if (id != orden.IdOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.IdOrden))
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
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "DNI", orden.IdPaciente);
            ViewData["IdPractica"] = new SelectList(_context.Practica, "IdPractica", "NombrePractica", orden.IdPractica);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Paciente)
                .Include(o => o.Practica)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Orden.FindAsync(id);
            _context.Orden.Remove(orden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Orden.Any(e => e.IdOrden == id);
        }
    }
}
