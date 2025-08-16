using Microsoft.EntityFrameworkCore;
using RecetaTipicaRD.Domain.Entities;
using RecetaTipicaRD.Infrastructure.Contracts;
using RecetaTipicaRD.Infrastructure.Data;


namespace RecetaTipicaRD.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly RecetaTipicaRDContext _context;

        public PostRepository(RecetaTipicaRDContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPostsAsync(int loggedInUserId)
        {
            return await _context.Posts
                .Include(n => n.User)
                .Include(n => n.Likes)
                .Include(n => n.Favorites)
                .Include(n => n.Comments).ThenInclude(n => n.User)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _context.Posts
                .Include(n => n.User)
                .Include(n => n.Likes)
                .Include(n => n.Favorites)
                .Include(n => n.Comments).ThenInclude(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == postId);
        }

        public async Task<List<Post>> GetAllFavoritedPostsAsync(int loggedInUserId)
        {
            return await _context.Favorites
                .Include(f => f.Post.User)
                .Include(f => f.Post.Comments).ThenInclude(c => c.User)
                .Include(f => f.Post.Likes)
                .Include(f => f.Post.Favorites)
                .OrderByDescending(f => f.DateCreated)
                .Select(n => n.Post)
                .ToListAsync();
        }

        public async Task AddPostCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> RemovePostAsync(int postId)
        {
            var postDb = await _context.Posts.FirstOrDefaultAsync(n => n.Id == postId);
            if (postDb != null)
            {

                _context.Posts.Update(postDb);
                await _context.SaveChangesAsync();
            }
            return postDb;
        }

        public async Task RemovePostCommentAsync(int commentId)
        {
            var commentDb = await _context.Comments.FirstOrDefaultAsync(n => n.Id == commentId);
            if (commentDb != null)
            {
                _context.Comments.Remove(commentDb);
                await _context.SaveChangesAsync();
            }
        }

  

        public async Task<bool> TogglePostFavoriteAsync(int postId, int userId)
        {
            var favorite = await _context.Favorites.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
                return false; // unfavorited
            }
            else
            {
                var newFavorite = new Favorite()
                {
                    PostId = postId,
                    UserId = userId,
                    DateCreated = DateTime.UtcNow
                };
                await _context.Favorites.AddAsync(newFavorite);
                await _context.SaveChangesAsync();
                return true; // favorited
            }
        }

        public async Task<bool> TogglePostLikeAsync(int postId, int userId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                return false; // unliked
            }
            else
            {
                var newLike = new Like()
                {
                    PostId = postId,
                    UserId = userId
                };
                await _context.Likes.AddAsync(newLike);
                await _context.SaveChangesAsync();
                return true; // liked
            }
        }

        public async Task TogglePostVisibilityAsync(int postId, int userId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(l => l.Id == postId && l.UserId == userId);
            if (post != null)
            {
                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
