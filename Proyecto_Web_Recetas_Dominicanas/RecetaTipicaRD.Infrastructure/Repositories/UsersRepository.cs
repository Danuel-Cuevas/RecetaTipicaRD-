using Microsoft.EntityFrameworkCore;
using RecetaTipicaRD.Domain.Entities;
using RecetaTipicaRD.Infrastructure.Contracts;
using RecetaTipicaRD.Infrastructure.Data;

namespace RecetaTipicaRD.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RecetaTipicaRDContext _context;

        public UserRepository(RecetaTipicaRDContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserProfilePictureAsync(int userId, string profilePictureUrl)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (userDb != null)
            {
                userDb.ProfilePictureUrl = profilePictureUrl;
                _context.Users.Update(userDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetUserPostsAsync(int userId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Favorites)
                .Include(p => p.Comments).ThenInclude(c => c.User)
                .OrderByDescending(p => p.DateCreated)
                .ToListAsync();
        }

    }
}