



using System.ComponentModel.DataAnnotations;
namespace RecetaTipicaRD.Domain.Entities
{
    public class PostDto
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NrOfReports { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


       
        public int UserId { get; set; }

       
        public UserDto User { get; set; }
        public ICollection<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<FavoriteDto> Favorites { get; set; } = new List<FavoriteDto>();

    }
}