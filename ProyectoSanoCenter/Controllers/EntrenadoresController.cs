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
    public class EntrenadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntrenadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entrenadores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entrenador.Include(e => e.Gimnasio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Entrenadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenador
                .Include(e => e.Gimnasio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrenador == null)
            {
                return NotFound();
            }

            return View(entrenador);
        }

        // GET: Entrenadores/Create
        public IActionResult Create()
        {
            ViewData["GimnasioId"] = new SelectList(_context.Set<Gimnasio>(), "Id", "Id");
            return View();
        }

        // POST: Entrenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Foto,NombreEntrenador,ApellidoEntrenador,Telefono,Especialidad,GimnasioId")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrenador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GimnasioId"] = new SelectList(_context.Set<Gimnasio>(), "Id", "Id", entrenador.GimnasioId);
            return View(entrenador);
        }

        // GET: Entrenadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenador.FindAsync(id);
            if (entrenador == null)
            {
                return NotFound();
            }
            ViewData["GimnasioId"] = new SelectList(_context.Set<Gimnasio>(), "Id", "Id", entrenador.GimnasioId);
            return View(entrenador);
        }

        // POST: Entrenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Foto,NombreEntrenador,ApellidoEntrenador,Telefono,Especialidad,GimnasioId")] Entrenador entrenador)
        {
            if (id != entrenador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrenador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrenadorExists(entrenador.Id))
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
            ViewData["GimnasioId"] = new SelectList(_context.Set<Gimnasio>(), "Id", "Id", entrenador.GimnasioId);
            return View(entrenador);
        }

        // GET: Entrenadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrenador = await _context.Entrenador
                .Include(e => e.Gimnasio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrenador == null)
            {
                return NotFound();
            }

            return View(entrenador);
        }

        // POST: Entrenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrenador = await _context.Entrenador.FindAsync(id);
            _context.Entrenador.Remove(entrenador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrenadorExists(int id)
        {
            return _context.Entrenador.Any(e => e.Id == id);
        }
    }
}
