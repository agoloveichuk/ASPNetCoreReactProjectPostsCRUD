using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace aspnetserver.Data
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VAVTTP2; database=PostsDb; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];

            for (int i = 1; i <= 6; i++)
            {
                postsToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is content to Post {i}"
                };
            }
            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
    }
}
