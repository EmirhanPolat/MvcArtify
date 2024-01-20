using Microsoft.AspNetCore.Mvc;
 // Adjust this to the actual namespace of UserRepository
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MvcArtify.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserProfileController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve user ID from claims
            if (User.Identity.IsAuthenticated && int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user != null)
                {
                    return View(user);
                }
            }

            // Handle unauthorized access or user not found
            return Unauthorized(); // Or redirect to a different view
        }
    }

}

