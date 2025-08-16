

using RecetaTipicaRD.Domain.Entities;

namespace RecetaTipicaRD.Application.Contracts
{
    public interface IPostsService
    {
        Task<List<Post>> GetAllPostsAsync(int loggedInUserId);
        Task<Post> GetPostByIdAsync(int postId);
        Task<List<Post>> GetAllFavoritedPostsAsync(int loggedInUserId);
        Task<Post> CreatePostAsync(Post post);
        

        Task AddPostCommentAsync(Comment comment);
        

        Task TogglePostVisibilityAsync(int postId, int userId);
        
    }
}