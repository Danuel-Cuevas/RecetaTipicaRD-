using RecetaTipicaRD.Application.Contracts;
using RecetaTipicaRD.Domain.Entities;
using RecetaTipicaRD.Infrastructure.Contracts;

namespace RecetaTipicaRD.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }

        public async Task UpdateUserProfilePictureAsync(int userId, string profilePictureUrl)
        {
            await _userRepository.UpdateUserProfilePictureAsync(userId, profilePictureUrl);
        }

        public async Task<List<Post>> GetUserPostsAsync(int userId)
        {
            return await _userRepository.GetUserPostsAsync(userId);
        }
    }
}
