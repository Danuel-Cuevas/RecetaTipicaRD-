


namespace RecetaTipicaRD.Domain.Entities
{
    public class FavoriteDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public PostDto Post { get; set; }
        public UserDto User { get; set; }
    }
}