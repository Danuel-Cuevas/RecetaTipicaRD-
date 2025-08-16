using RecetaTipicaRD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaTipicaRD.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int userId);
        Task UpdateUserProfilePictureAsync(int userId, string profilePictureUrl);
        Task<List<Post>> GetUserPostsAsync(int userId);
    }
}