using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL.Models;

namespace NatureBlog.DAL;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions configuration) : base(configuration)
    {
    }
    
    public DbSet<BlogPost> BlogPost { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Comment> Comment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}