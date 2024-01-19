using Microsoft.AspNetCore.Mvc;
using MvcArtify.Models; // Adjust to your model namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MvcArtify.Controllers
{
    public class ExhibitionController : Controller
    {
        // Temporary mock data for exhibitions
        private List<Exhibition> _mockExhibitions = new List<Exhibition>
        {
            new Exhibition { ExhibitionID = 1, ETitle = "Summer Art Expo", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), Location = "Downtown Gallery"},
            new Exhibition { ExhibitionID = 2, ETitle = "Modern Art Showcase", StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(25), Location = "Uptown Gallery"}
            // Add more mock exhibitions as needed
        };

        // GET: Exhibition
        public async Task<IActionResult> Index()
        {
            // Using mock data instead of database context
            return View(_mockExhibitions);
        }

        // GET: Exhibition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = _mockExhibitions.FirstOrDefault(e => e.ExhibitionID == id);

            if (exhibition == null)
            {
                return NotFound();
            }

            // You can add additional logic here to fetch associated artworks or other details if needed

            return View(exhibition);
        }

        // Remove Create, Edit, Delete actions as they are not needed
    }
}
