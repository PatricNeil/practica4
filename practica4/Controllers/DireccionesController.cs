using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practica4.Models;

namespace practica4.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly Practica4Context _context;

        public DireccionesController(Practica4Context context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Direcciones.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direccione == null)
            {
                return NotFound();
            }

            return View(direccione);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccion,Calle,Ciudad,Pais")] Direccione direccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccione);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones.FindAsync(id);
            if (direccione == null)
            {
                return NotFound();
            }
            return View(direccione);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccion,Calle,Ciudad,Pais")] Direccione direccione)
        {
            if (id != direccione.IdDireccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccioneExists(direccione.IdDireccion))
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
            return View(direccione);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccione = await _context.Direcciones
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direccione == null)
            {
                return NotFound();
            }

            return View(direccione);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccione = await _context.Direcciones.FindAsync(id);
            if (direccione != null)
            {
                _context.Direcciones.Remove(direccione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccioneExists(int id)
        {
            return _context.Direcciones.Any(e => e.IdDireccion == id);
        }
    }
}
