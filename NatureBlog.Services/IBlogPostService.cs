using NatureBlog.DAL.Models;

namespace NatureBlog.Services;

public interface IBlogPostService
{
    Task<List<BlogPost>> GetBlogPosts();
}