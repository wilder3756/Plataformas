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
    public class ApartamentoesController : Controller
    {
        private readonly mercadiaWilderContext _context;

        public ApartamentoesController(mercadiaWilderContext context)
        {
            _context = context;
        }

        // GET: Apartamentoes
        public async Task<IActionResult> Index()
        {
            var mercadiaWilderContext = _context.Apartamento.Include(a => a.UnidadResidencial);
            return View(await mercadiaWilderContext.ToListAsync());
        }

        // GET: Apartamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .Include(a => a.UnidadResidencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Apartamentoes/Create
        public IActionResult Create()
        {
            ViewData["UnidadResidencialId"] = new SelectList(_context.UnidadResidencial, "Id", "Nombre");
            return View();
        }

        // POST: Apartamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Piso,Bloque,UnidadResidencialId,Estado")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidadResidencialId"] = new SelectList(_context.UnidadResidencial, "Id", "Id", apartamento.UnidadResidencialId);
            return View(apartamento);
        }

        // GET: Apartamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            ViewData["UnidadResidencialId"] = new SelectList(_context.UnidadResidencial, "Id", "Id", apartamento.UnidadResidencialId);
            return View(apartamento);
        }

        // POST: Apartamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Piso,Bloque,UnidadResidencialId,Estado")] Apartamento apartamento)
        {
            if (id != apartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.Id))
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
            ViewData["UnidadResidencialId"] = new SelectList(_context.UnidadResidencial, "Id", "Id", apartamento.UnidadResidencialId);
            return View(apartamento);
        }

        // GET: Apartamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .Include(a => a.UnidadResidencial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Apartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamento = await _context.Apartamento.FindAsync(id);
            _context.Apartamento.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(int id)
        {
            return _context.Apartamento.Any(e => e.Id == id);
        }
    }
}
