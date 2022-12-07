using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csd412_final.Data;
using csd412_final.Models;

namespace csd412_final.Controllers
{
    public class NotecardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotecardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notecards1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notecards.ToListAsync());
        }

        // GET: Notecards1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notecards = await _context.Notecards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notecards == null)
            {
                return NotFound();
            }

            return View(notecards);
        }

        // GET: Notecards1/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Notecards1/CreateOnCollection
        [Route("Notecards/CreateOnCollection/{collectionID}")]
        public IActionResult CreateOnCollection(string collectionID)
        {
            ViewBag.collectionID = collectionID;
            return View();
        }

        // POST: Notecards1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer,Decoys,CollectionID")] Notecards notecards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notecards);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetOnCollection", new { id= notecards.CollectionID });
            }
            return View(notecards);
        }

        // GET: Notecards1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notecards = await _context.Notecards.FindAsync(id);
            if (notecards == null)
            {
                return NotFound();
            }
            return View(notecards);
        }

        // POST: Notecards1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer,Decoys")] Notecards notecards)
        {
            if (id != notecards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notecards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotecardsExists(notecards.Id))
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
            return View(notecards);
        }

        // GET: Notecards1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notecards = await _context.Notecards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notecards == null)
            {
                return NotFound();
            }

            return View(notecards);
        }

        // POST: Notecards1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notecards = await _context.Notecards.FindAsync(id);
            _context.Notecards.Remove(notecards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Notecards1/GetOnCollection
        [Route("Notecards/GetOnCollection/{collectionID}")]
        public IActionResult GetOnCollection(int collectionID)
        {
            var all = _context.Notecards.ToList();
            var found = new List<Notecards>();

            foreach (var card in all)
                if (card.CollectionID == collectionID)
                    found.Add(card);

            return View(found);
        }

        private bool NotecardsExists(int id)
        {
            return _context.Notecards.Any(e => e.Id == id);
        }
    }
}
