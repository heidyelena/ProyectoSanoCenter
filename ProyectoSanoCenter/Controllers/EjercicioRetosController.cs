using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSanoCenter.Data;
using ProyectoSanoCenter.Models;

namespace ProyectoSanoCenter.Controllers
{
    public class EjercicioRetosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EjercicioRetosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EjercicioRetos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EjercicioReto.Include(e => e.Ejercicio).ThenInclude(x => x.NombreEjercicio).Include(e => e.Reto);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: EjercicioRetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicioReto = await _context.EjercicioReto
                .Include(e => e.Ejercicio)
                .Include(e => e.Reto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicioReto == null)
            {
                return NotFound();
            }

            return View(ejercicioReto);
        }

        // GET: EjercicioRetos/Create
        public IActionResult Create()
        {
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicio, "Id", "NombreEjercicio");
            ViewData["RetoId"] = new SelectList(_context.Set<Reto>(), "Id", "NombreReto");
            return View();
        }

        // POST: EjercicioRetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RetoId,EjercicioId")] EjercicioReto ejercicioReto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicioReto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicio, "Id", "Id", ejercicioReto.EjercicioId);
            ViewData["RetoId"] = new SelectList(_context.Set<Reto>(), "Id", "Id", ejercicioReto.RetoId);
            return View(ejercicioReto);
        }

        // GET: EjercicioRetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicioReto = await _context.EjercicioReto.FindAsync(id);
            if (ejercicioReto == null)
            {
                return NotFound();
            }
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicio, "Id", "Id", ejercicioReto.EjercicioId);
            ViewData["RetoId"] = new SelectList(_context.Set<Reto>(), "Id", "Id", ejercicioReto.RetoId);
            return View(ejercicioReto);
        }

        // POST: EjercicioRetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RetoId,EjercicioId")] EjercicioReto ejercicioReto)
        {
            if (id != ejercicioReto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicioReto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioRetoExists(ejercicioReto.Id))
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
            ViewData["EjercicioId"] = new SelectList(_context.Ejercicio, "Id", "Id", ejercicioReto.EjercicioId);
            ViewData["RetoId"] = new SelectList(_context.Set<Reto>(), "Id", "Id", ejercicioReto.RetoId);
            return View(ejercicioReto);
        }

        // GET: EjercicioRetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicioReto = await _context.EjercicioReto
                .Include(e => e.Ejercicio)
                .Include(e => e.Reto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicioReto == null)
            {
                return NotFound();
            }

            return View(ejercicioReto);
        }

        // POST: EjercicioRetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicioReto = await _context.EjercicioReto.FindAsync(id);
            _context.EjercicioReto.Remove(ejercicioReto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioRetoExists(int id)
        {
            return _context.EjercicioReto.Any(e => e.Id == id);
        }
    }
}
