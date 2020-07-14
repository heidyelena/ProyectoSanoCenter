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
    public class ValoracionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValoracionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Valoraciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Valoracion.Include(v => v.Reto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Valoraciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _context.Valoracion
                .Include(v => v.Reto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valoracion == null)
            {
                return NotFound();
            }

            return View(valoracion);
        }

        // GET: Valoraciones/Create
        public IActionResult Create()
        {
            ViewData["RetoId"] = new SelectList(_context.Reto, "Id", "Id");
            return View();
        }

        // POST: Valoraciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Puntuacion,NumeroPuntuaciones,MediaPuntuaciones,RetoId")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valoracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RetoId"] = new SelectList(_context.Reto, "Id", "Id", valoracion.RetoId);
            return View(valoracion);
        }

        // GET: Valoraciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _context.Valoracion.FindAsync(id);
            if (valoracion == null)
            {
                return NotFound();
            }
            ViewData["RetoId"] = new SelectList(_context.Reto, "Id", "Id", valoracion.RetoId);
            return View(valoracion);
        }

        // POST: Valoraciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Puntuacion,NumeroPuntuaciones,MediaPuntuaciones,RetoId")] Valoracion valoracion)
        {
            if (id != valoracion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valoracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValoracionExists(valoracion.Id))
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
            ViewData["RetoId"] = new SelectList(_context.Reto, "Id", "Id", valoracion.RetoId);
            return View(valoracion);
        }

        // GET: Valoraciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _context.Valoracion
                .Include(v => v.Reto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valoracion == null)
            {
                return NotFound();
            }

            return View(valoracion);
        }

        // POST: Valoraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valoracion = await _context.Valoracion.FindAsync(id);
            _context.Valoracion.Remove(valoracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValoracionExists(int id)
        {
            return _context.Valoracion.Any(e => e.Id == id);
        }
    }
}
