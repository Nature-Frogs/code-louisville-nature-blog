using NatureBlog.DAL.Models;

namespace NatureBlog.Services;

public class MockBlogPostService : IBlogPostService
{
    public Task<List<BlogPost>> GetBlogPosts()
    {
        return Task.FromResult(
            new List<BlogPost>()
            {
                new BlogPost()
                {
                    Id = Guid.NewGuid(),
                    Title = "Chris's first post",
                    Content = "as;dlkfjasdl;kjfal;skdjflk",
                    DateTime = DateTime.Now,
                    PostedBy = "Mr. Chris",
                },
            }
        );
    }
}