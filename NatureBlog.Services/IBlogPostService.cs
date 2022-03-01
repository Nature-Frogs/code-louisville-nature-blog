using NatureBlog.DAL.Models;
using NatureBlog.Services.Models;

namespace NatureBlog.Services;

public interface IBlogPostService
{
    Task<List<BlogPost>> GetBlogPostsByDateDesc(int takeLimit = 5, string searchString = "");
    Task<AddEntryResult> AddEntry(string title, string content, int userId);
}