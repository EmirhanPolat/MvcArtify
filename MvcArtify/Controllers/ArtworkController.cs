using Microsoft.AspNetCore.Mvc;
using MvcArtify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcArtify.Controllers
{
    public class ArtworkController : Controller
    {
        // Mock data for artworks
        private List<Artwork> _mockArtworks = new List<Artwork>
        {
            new Artwork { ArtworkID = 1, ATitle = "Artwork 1", ArtStyle = "Style 1", Type = "Type 1", SalePrice = 100.00f },
            new Artwork { ArtworkID = 2, ATitle = "Artwork 2", ArtStyle = "Style 2", Type = "Type 2", SalePrice = 200.00f },
            // Additional mock artworks...
        };

        // GET: Artwork
        public IActionResult Index()
        {
            return View(_mockArtworks);
        }

        // GET: Artwork/Details/5
        public IActionResult Details(int id)
        {
            var artwork = _mockArtworks.FirstOrDefault(a => a.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }

            return View(artwork);
        }

        // GET: Artwork/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artwork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ArtworkID,ATitle,ArtStyle,Type,ImagePath,Description,SalePrice")] Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                // Mock adding the artwork. In reality, you'd add to the database
                artwork.ArtworkID = _mockArtworks.Max(a => a.ArtworkID) + 1;
                _mockArtworks.Add(artwork);

                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: Artwork/Edit/5
        public IActionResult Edit(int id)
        {
            var artwork = _mockArtworks.FirstOrDefault(a => a.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artwork/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ArtworkID,ATitle,ArtStyle,Type,ImagePath,Description,SalePrice")] Artwork artwork)
        {
            if (id != artwork.ArtworkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Mock edit logic. In reality, you'd update the database
                var existingArtwork = _mockArtworks.FirstOrDefault(a => a.ArtworkID == id);
                if (existingArtwork != null)
                {
                    existingArtwork.ATitle = artwork.ATitle;
                    existingArtwork.ArtStyle = artwork.ArtStyle;
                    existingArtwork.Type = artwork.Type;
                    existingArtwork.ImagePath = artwork.ImagePath;
                    existingArtwork.Description = artwork.Description;
                    existingArtwork.SalePrice = artwork.SalePrice;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: Artwork/Delete/5
        public IActionResult Delete(int id)
        {
            var artwork = _mockArtworks.FirstOrDefault(a => a.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Mock delete logic. In reality, you'd delete from the database
            var artwork = _mockArtworks.FirstOrDefault(a => a.ArtworkID == id);
            if (artwork != null)
            {
                _mockArtworks.Remove(artwork);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
