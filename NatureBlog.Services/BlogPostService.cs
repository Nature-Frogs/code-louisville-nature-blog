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
        
        public async Task<List<BlogPost>> GetBlogPostsByDateDesc(int takeLimit = 5, string searchString = "")
        {
            var posts =  _db.BlogPosts.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                var splitString = searchString.Split(" ");
                foreach (var word in splitString)
                {
                    posts = posts.Where(b => 
                        b.Title.Contains(word) ||
                        b.Content.Contains(word) ||
                        b.PostedBy.Contains(word) );
                }
            }
            return await posts.OrderBy(x => x.DateTime).Take(takeLimit).ToListAsync();
        }
    }
}