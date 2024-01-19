using Microsoft.AspNetCore.Mvc;
using MvcArtify.Models;
using System.Collections.Generic;

namespace MvcArtify.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            // Simulated user profile data
            User user = new User
            {
                UId = 1,
                UName = "Jane Doe",
                DigitalWallet = 1500,
                BoughtArtworks = new List<Artwork>
                {
                    new Artwork { ArtworkID = 1, ATitle = "Sunset", ArtStyle = "Impressionism", Type = "Painting", SalePrice = 300.00f },
                    new Artwork { ArtworkID = 2, ATitle = "Starry Night", ArtStyle = "Post-Impressionism", Type = "Painting", SalePrice = 400.00f },
                    // Add more mock bought artworks as needed
                }
            };

            return View(user);
        }

        // Additional methods (e.g., Profile, Edit, etc.) if needed
    }
}

