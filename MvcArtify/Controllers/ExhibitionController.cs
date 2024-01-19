using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcArtify.Models;
using MvcArtify.DataContext;

namespace MvcArtify.Controllers
{
    public class ExhibitionController : Controller
    {
        private readonly MvcArtifyContext _context;

        public ExhibitionController(MvcArtifyContext context)
        {
            _context = context;
        }

        // GET: Exhibition
        public async Task<IActionResult> Index()
        {
            var exhibitions = await _context.Exhibitions
                .Include(e => e.Gallery) // Assuming there's a navigation property to Gallery
                .Include(e => e.Artworks) // Assuming there's a collection of Artworks
                .ToListAsync();
            return View(exhibitions);
        }

        // GET: Exhibition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions
                .Include(e => e.Gallery)
                .Include(e => e.Artworks)
                .FirstOrDefaultAsync(m => m.ExhibitionID == id);

            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // GET: Exhibition/Create
        public IActionResult Create()
        {
            // You can pass galleries and artworks list to the view if needed for dropdowns
            // ViewData["GalleryID"] = new SelectList(_context.Galleries, "GalleryID", "GName");
            // ViewData["ArtworkID"] = new SelectList(_context.Artworks, "ArtworkID", "ATitle");
            return View();
        }

        // POST: Exhibition/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExhibitionID,ETitle,StartDate,EndDate,Location,IsOnline")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibition);
        }

        // GET: Exhibition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibition/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExhibitionID,ETitle,StartDate,EndDate,Location,IsOnline")] Exhibition exhibition)
        {
            if (id != exhibition.ExhibitionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.ExhibitionID))
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
            return View(exhibition);
        }

        // GET: Exhibition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibitions
                .FirstOrDefaultAsync(m => m.ExhibitionID == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // POST: Exhibition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            _context.Exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibitions.Any(e => e.ExhibitionID == id);
        }
    }
}
