using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;

namespace NatureBlog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogDbContext _db;
        
        public BlogPostService(BlogDbContext dbCtx)
        {
            _db = dbCtx;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _db.BlogPost.ToListAsync();
        }
    }
}