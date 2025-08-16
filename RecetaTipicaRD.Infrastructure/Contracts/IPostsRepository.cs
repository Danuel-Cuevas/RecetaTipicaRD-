using RecetaTipicaRD.Domain.Entities;


namespace RecetaTipicaRD.Infrastructure.Contracts
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync(int loggedInUserId);
        Task<Post?> GetPostByIdAsync(int postId);
        Task<List<Post>> GetAllFavoritedPostsAsync(int loggedInUserId);
        Task AddPostCommentAsync(Comment comment);
        Task<Post> CreatePostAsync(Post post);
        Task<Post?> RemovePostAsync(int postId);
        Task RemovePostCommentAsync(int commentId);
        
        Task<bool> TogglePostFavoriteAsync(int postId, int userId);
        Task<bool> TogglePostLikeAsync(int postId, int userId);
        Task TogglePostVisibilityAsync(int postId, int userId);
    }
}
