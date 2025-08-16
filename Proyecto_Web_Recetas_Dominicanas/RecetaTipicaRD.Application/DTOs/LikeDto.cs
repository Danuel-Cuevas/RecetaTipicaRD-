

namespace RecetaTipicaRD.Domain.Entities
{
    public class LikeDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public PostDto Post { get; set; }
        public UserDto User { get; set; }

    }
}