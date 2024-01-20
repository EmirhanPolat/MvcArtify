using Microsoft.EntityFrameworkCore;
using MvcArtify.DataContext;
using MvcArtify.Models;

public class UserRepository
{
    private readonly MvcArtifyContext _context;

    public UserRepository(MvcArtifyContext context)
    {
        _context = context;
    }

     public async Task<User> GetUserByIdAsync(int userId)
    {
        // Eager load the BoughtArtworks collection with the user
    return await _context.Users
                         .Include(u => u.BoughtArtworks)
                         .FirstOrDefaultAsync(u => u.UId == userId); 
    }

    public async Task<IEnumerable<MvcArtify.Models.Artwork>> GetBoughtArtworksAsync(int userId)
    {
        return await _context.Users
                             .Where(u => u.UId == userId)
                             .SelectMany(u => u.BoughtArtworks)
                             .ToListAsync();
    }
}
