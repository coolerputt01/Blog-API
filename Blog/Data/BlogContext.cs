using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data;

public class BlogContext(DbContextOptions<BlogContext> options) : DbContext(options)
{
    public DbSet<Blog.Models.Blog> Blogs => Set<Blog.Models.Blog>();

    public DbSet<Blog.Models.Category> Categories => Set<Blog.Models.Category>();
}
