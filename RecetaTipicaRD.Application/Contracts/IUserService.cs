using RecetaTipicaRD.Domain.Entities;

namespace RecetaTipicaRD.Application.Services
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(int userId);
        Task UpdateUserProfilePictureAsync(int userId, string profilePictureUrl);
        Task<List<Post>> GetUserPostsAsync(int userId);
    }
}
