using Microsoft.EntityFrameworkCore;

namespace BloggInlämning.Models
{
    public class BloggContext : DbContext
    {
        public BloggContext(DbContextOptions<BloggContext> options)
            : base(options)
        {
        }
        public DbSet<BloggPost> BloggPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
