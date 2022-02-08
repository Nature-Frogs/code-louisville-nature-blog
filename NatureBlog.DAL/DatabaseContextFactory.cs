using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NatureBlog.DAL;

public class DatabaseContextFactory: IDesignTimeDbContextFactory<BlogDatabaseContext>
{
    public BlogDatabaseContext CreateDbContext(string[] args)
    {
    
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var cxString = configuration.GetConnectionString("SQLConnectionString");
        if (string.IsNullOrWhiteSpace(cxString))
        {
            cxString = Environment.GetEnvironmentVariable("SQLConnectionString");
        }

        var optionsBuilder = new DbContextOptionsBuilder<BlogDatabaseContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
        return new BlogDatabaseContext(optionsBuilder.Options);
    }
}