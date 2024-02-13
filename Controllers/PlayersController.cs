using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoCrudMvc;
using DemoCrudMvc.Entities;

namespace DemoCrudMvc.Controllers
{
    public class PlayersController : Controller
    {
        AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Players
        //public async Task<IActionResult> Index()
        //{
        //    return _context.Players != null ? View(await _context.Players.ToListAsync()) :
        //                Problem("Entity set 'AppDbContext.Players'  is null.");
        //}

        public IActionResult Index()
        {
            var players = _context.Players.ToList();
            _context.SaveChanges();
            return View(players);
        }

        // GET: Players/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Players == null)
        //    {
        //        return NotFound();
        //    }

        //    var player = await _context.Players.FirstOrDefaultAsync(m => m.PlayerID == id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(player);
        //}

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = _context.Players.FirstOrDefault(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create([Bind("PlayerID,PlayerName,PlayerAge,PlayerAddress,PlayerJoiningDate")] Player player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(player);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(player);
        //}

        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Players == null)
        //    {
        //        return NotFound();
        //    }

        //    var player = await _context.Players.FindAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(player);
        //}

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int id, [Bind("PlayerID,PlayerName,PlayerAge,PlayerAddress,PlayerJoiningDate")] Player player)
        //{
        //    if (id != player.PlayerID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(player);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PlayerExists(player.PlayerID))
        //                return NotFound();
        //            else
        //                throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(player);
        //}

        public IActionResult Edit(int id, Player player)
        {
            if (id != player.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (!PlayerExists(player.PlayerID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Players == null)
        //    {
        //        return NotFound();
        //    }

        //    var player = await _context.Players.FirstOrDefaultAsync(m => m.PlayerID == id);
        //    if (player == null)
        //        return NotFound();

        //    return View(player);
        //}

        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = _context.Players.FirstOrDefault(p => p.PlayerID == id);
            if (player == null)
                return NotFound();

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Players == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.Players'  is null.");
        //    }
        //    var player = await _context.Players.FindAsync(id);
        //    if (player != null)
        //        _context.Players.Remove(player);

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'AppDbContext.Players'  is null.");
            }
            var player = _context.Players.Find(id);
            if (player != null)
            {
                _context.Players.Remove(player);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return (_context.Players?.Any(e => e.PlayerID == id)).GetValueOrDefault();
        }
    }
}
