﻿using System;
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
    public class CiudadesController : Controller
    {
        private readonly mercadiaWilderContext _context;

        public CiudadesController(mercadiaWilderContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
            var mercadiaWilderContext = _context.Ciudad.Include(c => c.Departamento);
            return View(await mercadiaWilderContext.ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoID"] = new SelectList(_context.Departamento, "Id", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado,DepartamentoID")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamento, "Id", "Id", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamento, "Id", "Id", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado,DepartamentoID")] Ciudad ciudad)
        {
            if (id != ciudad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadExists(ciudad.Id))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Departamento, "Id", "Id", ciudad.DepartamentoID);
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudad.Any(e => e.Id == id);
        }
    }
}
