using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;
using NatureBlog.Services.Models;

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
            var posts = _db.BlogPosts.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                var splitString = searchString.Split(" ");
                foreach (var word in splitString)
                {
                    posts = posts.Where(b =>
                        b.Title.Contains(word) ||
                        b.Content.Contains(word) ||
                        b.PostedBy.UserName.Contains(word));
                }
            }
            return await posts.OrderByDescending(x => x.DateTime).Take(takeLimit).ToListAsync();
        }

        public async Task<AddEntryResult> AddEntry(string title, string content, int userId)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null)
                    throw new AccessViolationException("User id does not exist.");

                var blogPost = new BlogPost
                {
                    Content = content,
                    Title = title,
                    PostedBy = user,
                    DateTime = DateTime.UtcNow
                };

                _db.BlogPosts.Add(blogPost);

                await _db.SaveChangesAsync();

                return new AddEntryResult
                {
                    BlogPostId = blogPost.Id,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new AddEntryResult
                {
                    IsSuccessful = false,
                    ServiceException = ex
                };
            }

        }
    }
}