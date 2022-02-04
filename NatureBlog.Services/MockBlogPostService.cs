using NatureBlog.DAL.Models;

namespace NatureBlog.Services;

public class MockBlogPostService : IBlogPostService
{
    public Task<List<BlogPost>> GetBlogPosts()
    {
        var blogPosts = new List<BlogPost>()
        {
            new BlogPost()
            {
                Title = "Chris's first blog post",
                Content =" My content aslkdjflskdjf",
                DateTime = DateTimeOffset.Now,
                PostedBy = "Chris Soliday",
            },
            new BlogPost()
            {
                Title = "Brad's blog post",
                Content =" Brad's content aslkdjflskdjf",
                DateTime = DateTimeOffset.Now,
                PostedBy = "Brad ",
            },
        };
        return Task.FromResult(blogPosts);
    }
}