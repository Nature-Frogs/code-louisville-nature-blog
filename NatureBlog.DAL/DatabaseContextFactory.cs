using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NatureBlog.DAL;

public class DatabaseContextFactory: IDesignTimeDbContextFactory<BlogDatabaseContext>
{
    public BlogDatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogDatabaseContext>();
        optionsBuilder.UseSqlServer("server=localhost,1433;user=sa;database=FrogBlog;password=34r0TNhvgOde;");
        return new BlogDatabaseContext(optionsBuilder.Options);
    }
}