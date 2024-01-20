using Microsoft.AspNetCore.Mvc;
using MvcArtify.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace MvcArtify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            if (!User.Identity.IsAuthenticated)
            {
                // Redirect to the Sign In page
                return RedirectToAction("SignIn", "Account");
            }

            // Continue to the Home/Index view if the user is authenticated
            return View();
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                // Redirect to the ArtworkList action with the search query as a parameter
                return RedirectToAction("ArtworkList", "Artwork", new { searchQuery });
            }
            else
            {
                // Handle empty search query, e.g., display a message or redirect
                return RedirectToAction("Index");
            }
        }
    }
}
