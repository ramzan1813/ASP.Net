using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokeWeb.Data;
using JokeWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace JokeWeb.Controllers
{
    public class RamzansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RamzansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ramzans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ramzan.ToListAsync());
        }

        // GET: Ramzans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramzan = await _context.Ramzan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramzan == null)
            {
                return NotFound();
            }

            return View(ramzan);
        }

        // GET: Ramzans/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ramzans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adress,DateOfBirth,Number,CNIC")] Ramzan ramzan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramzan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ramzan);
        }

        // GET: Ramzans/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramzan = await _context.Ramzan.FindAsync(id);
            if (ramzan == null)
            {
                return NotFound();
            }
            return View(ramzan);
        }

        // POST: Ramzans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Adress,DateOfBirth,Number,CNIC")] Ramzan ramzan)
        {
            if (id != ramzan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramzan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamzanExists(ramzan.Id))
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
            return View(ramzan);
        }

        // GET: Ramzans/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramzan = await _context.Ramzan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ramzan == null)
            {
                return NotFound();
            }

            return View(ramzan);
        }

        // POST: Ramzans/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ramzan = await _context.Ramzan.FindAsync(id);
            _context.Ramzan.Remove(ramzan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamzanExists(int id)
        {
            return _context.Ramzan.Any(e => e.Id == id);
        }
    }
}
