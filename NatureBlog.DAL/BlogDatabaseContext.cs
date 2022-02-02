using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL.Models;

namespace NatureBlog.DAL;

public class BlogDatabaseContext : DbContext
{
    public BlogDatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}