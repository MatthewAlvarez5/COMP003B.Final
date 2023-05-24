using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Final.Models;
using COMP003B.FinalProject.Data;

namespace COMP003B.Final.Controllers
{
    public class GameDevelopersController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public GameDevelopersController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: GameDevelopers
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.GameDevelopers.Include(g => g.Developer).Include(g => g.Game);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: GameDevelopers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameDevelopers == null)
            {
                return NotFound();
            }

            var gameDeveloper = await _context.GameDevelopers
                .Include(g => g.Developer)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameDeveloper == null)
            {
                return NotFound();
            }

            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Create
        public IActionResult Create()
        {
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId");
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            return View();
        }

        // POST: GameDevelopers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,DeveloperId")] GameDeveloper gameDeveloper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameDeveloper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gameDeveloper.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gameDeveloper.GameId);
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameDevelopers == null)
            {
                return NotFound();
            }

            var gameDeveloper = await _context.GameDevelopers.FindAsync(id);
            if (gameDeveloper == null)
            {
                return NotFound();
            }
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gameDeveloper.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gameDeveloper.GameId);
            return View(gameDeveloper);
        }

        // POST: GameDevelopers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,DeveloperId")] GameDeveloper gameDeveloper)
        {
            if (id != gameDeveloper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameDeveloper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameDeveloperExists(gameDeveloper.Id))
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
            ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperId", gameDeveloper.DeveloperId);
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", gameDeveloper.GameId);
            return View(gameDeveloper);
        }

        // GET: GameDevelopers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameDevelopers == null)
            {
                return NotFound();
            }

            var gameDeveloper = await _context.GameDevelopers
                .Include(g => g.Developer)
                .Include(g => g.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameDeveloper == null)
            {
                return NotFound();
            }

            return View(gameDeveloper);
        }

        // POST: GameDevelopers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameDevelopers == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.GameDevelopers'  is null.");
            }
            var gameDeveloper = await _context.GameDevelopers.FindAsync(id);
            if (gameDeveloper != null)
            {
                _context.GameDevelopers.Remove(gameDeveloper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameDeveloperExists(int id)
        {
          return (_context.GameDevelopers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
