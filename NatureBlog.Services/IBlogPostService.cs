using Microsoft.EntityFrameworkCore;
using NatureBlog.DAL;
using NatureBlog.DAL.Models;

namespace NatureBlog.Services;

public interface IBlogPostService
{
    Task<List<BlogPost>> GetBlogPosts();
}