using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NatureBlog.DAL;

public class BlogContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
        optionsBuilder.UseSqlServer("server=localhost,1433;user=sa;database=FrogBlog;password=34r0TNhvgOde;");
        return new BlogDbContext(optionsBuilder.Options);
    }
}