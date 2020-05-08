using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadiaWilder.Data;
using MercadiaWilder.Models;

namespace MercadiaWilder.Controllers
{
    public class UnidadesResidencialesController : Controller
    {
        private readonly mercadiaWilderContext _context;

        public UnidadesResidencialesController(mercadiaWilderContext context)
        {
            _context = context;
        }

        // GET: UnidadesResidenciales
        public async Task<IActionResult> Index()
        {
            var mercadiaWilderContext = _context.UnidadResidencial.Include(u => u.Ciudad);
            return View(await mercadiaWilderContext.ToListAsync());
        }

        // GET: UnidadesResidenciales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadResidencial = await _context.UnidadResidencial
                .Include(u => u.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadResidencial == null)
            {
                return NotFound();
            }

            return View(unidadResidencial);
        }

        // GET: UnidadesResidenciales/Create
        public IActionResult Create()
        {
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Nombre");
            return View();
        }

        // POST: UnidadesResidenciales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono,CiudadID,Estado")] UnidadResidencial unidadResidencial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadResidencial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Id", unidadResidencial.CiudadID);
            return View(unidadResidencial);
        }

        // GET: UnidadesResidenciales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadResidencial = await _context.UnidadResidencial.FindAsync(id);
            if (unidadResidencial == null)
            {
                return NotFound();
            }
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Id", unidadResidencial.CiudadID);
            return View(unidadResidencial);
        }

        // POST: UnidadesResidenciales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,CiudadID,Estado")] UnidadResidencial unidadResidencial)
        {
            if (id != unidadResidencial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadResidencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadResidencialExists(unidadResidencial.Id))
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
            ViewData["CiudadID"] = new SelectList(_context.Ciudad, "Id", "Id", unidadResidencial.CiudadID);
            return View(unidadResidencial);
        }

        // GET: UnidadesResidenciales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadResidencial = await _context.UnidadResidencial
                .Include(u => u.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadResidencial == null)
            {
                return NotFound();
            }

            return View(unidadResidencial);
        }

        // POST: UnidadesResidenciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadResidencial = await _context.UnidadResidencial.FindAsync(id);
            _context.UnidadResidencial.Remove(unidadResidencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadResidencialExists(int id)
        {
            return _context.UnidadResidencial.Any(e => e.Id == id);
        }
    }
}
