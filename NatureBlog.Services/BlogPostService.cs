using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;

namespace NatureBlog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogDatabaseContext _db;

        public BlogPostService(BlogDatabaseContext context)
        {
            _db = context;
        }
        
        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _db.BlogPosts.OrderBy(x => x.DateTime).ToListAsync();
        }
    }
}