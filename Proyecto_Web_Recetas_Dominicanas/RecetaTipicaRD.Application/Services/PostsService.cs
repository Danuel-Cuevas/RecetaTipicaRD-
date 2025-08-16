using RecetaTipicaRD.Application.Contracts;
using RecetaTipicaRD.Domain.Entities;
using RecetaTipicaRD.Infrastructure.Contracts;

namespace RecetaTipicaRD.Application.Services
{
    public class PostsService : IPostsService

    {
        private readonly IPostRepository _postRepository;

        public PostsService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllPostsAsync(int loggedInUserId)
        {
            return await _postRepository.GetAllPostsAsync(loggedInUserId);
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetPostByIdAsync(postId);
        }

        public async Task<List<Post>> GetAllFavoritedPostsAsync(int loggedInUserId)
        {
            return await _postRepository.GetAllFavoritedPostsAsync(loggedInUserId);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            // Aquí puedes añadir validaciones (ej: no permitir texto vacío, etc.)
            return await _postRepository.CreatePostAsync(post);
        }



        public async Task AddPostCommentAsync(Comment comment)
        {
            await _postRepository.AddPostCommentAsync(comment);
        }

        

        public async Task<bool> TogglePostFavoriteAsync(int postId, int userId)
        {
            return await _postRepository.TogglePostFavoriteAsync(postId, userId);
        }

        public async Task<bool> TogglePostLikeAsync(int postId, int userId)
        {
            return await _postRepository.TogglePostLikeAsync(postId, userId);
        }

        public async Task TogglePostVisibilityAsync(int postId, int userId)
        {
            await _postRepository.TogglePostVisibilityAsync(postId, userId);
        }
    }
}
