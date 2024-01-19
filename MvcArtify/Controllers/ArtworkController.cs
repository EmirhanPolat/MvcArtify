using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcArtify.Models;
using MvcArtify.DataContext; // Make sure this namespace matches your MvcArtifyContext location

namespace MvcArtify.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly MvcArtifyContext _context;

        public ArtworkController(MvcArtifyContext context)
        {
            _context = context;
        }

        // GET: Artwork
        // Displays a list of all artworks
        public async Task<IActionResult> Index()
        {
            var artworks = await _context.Artworks
                .Include(a => a.Gallery)
                .Include(a => a.Exhibition)
                .ToListAsync();
            return View(artworks);
        }

        // GET: Artwork/Details/5
        // Displays the details of a specific artwork
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks
                .Include(a => a.Gallery)
                .Include(a => a.Exhibition)
                .FirstOrDefaultAsync(m => m.ArtworkID == id);
            
            if (artwork == null)
            {
                return NotFound();
            }

            return View(artwork);
        }

        // GET: Artwork/Create
        // Shows a form to create a new artwork
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artwork/Create
        // Adds a new artwork to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtworkID,ATitle,ArtStyle,Type,ImagePath,Description,SalePrice")] Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artwork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: Artwork/Edit/5
        // Shows a form to edit an existing artwork
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artwork/Edit/5
        // Updates an existing artwork in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtworkID,ATitle,ArtStyle,Type,ImagePath,Description,SalePrice")] Artwork artwork)
        {
            if (id != artwork.ArtworkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtworkExists(artwork.ArtworkID))
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
            return View(artwork);
        }

        // GET: Artwork/Delete/5
        // Shows a confirmation page to delete an artwork
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks
                .FirstOrDefaultAsync(m => m.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }

            return View(artwork);
        }

        // POST: Artwork/Delete/5
        // Deletes an artwork from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            _context.Artworks.Remove(artwork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Checks if an artwork exists
        private bool ArtworkExists(int id)
        {
            return _context.Artworks.Any(e => e.ArtworkID == id);
        }

        // Displays reviews for a specific artwork
        public async Task<IActionResult> DisplayReviews(int artworkId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.ArtworkID == artworkId)
                .Include(r => r.User)
                .ToListAsync();

            // Assuming you have a view named "DisplayReviews" to show these reviews
            return View("DisplayReviews", reviews);
        }
    }
}
