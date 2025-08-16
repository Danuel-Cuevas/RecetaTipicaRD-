


namespace RecetaTipicaRD.Domain.Entities
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Foreign keys
        public int PostId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public PostDto Post { get; set; }
        public UserDto User { get; set; }
    }
}