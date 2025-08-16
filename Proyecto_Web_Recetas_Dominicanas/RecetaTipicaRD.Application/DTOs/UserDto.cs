

using RecetaTipicaRD.Domain.Entities;

namespace RecetaTipicaRD.Domain.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? ProfilePictureUrl { get; set; }

        // Navigation properties
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
        public ICollection<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<FavoriteDto> Favorites { get; set; } = new List<FavoriteDto>();
    }
}