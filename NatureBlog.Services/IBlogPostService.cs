using NatureBlog.DAL.Models;

namespace NatureBlog.Services;

public interface IBlogPostService
{
    Task<List<BlogPost>> GetBlogPostsByDateDesc(int takeLimit = 5, string searchString = "");
}