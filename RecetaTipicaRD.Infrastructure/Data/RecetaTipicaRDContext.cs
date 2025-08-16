using Microsoft.EntityFrameworkCore;
using RecetaTipicaRD.Domain.Entities;

namespace RecetaTipicaRD.Infrastructure.Data
{
    internal class RecetaTipicaRDContext: DbContext
    {
        public RecetaTipicaRDContext(DbContextOptions<RecetaTipicaRDContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
