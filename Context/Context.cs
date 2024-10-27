namespace Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BlogsContext : DbContext
{
    public BlogsContext(DbContextOptions<BlogsContext> options) : base(options)
    {
    }

    protected BlogsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Blog> Blogs => Set<Blog>();
}

public class BlogsContextFactory : IDesignTimeDbContextFactory<BlogsContext>
{
    public BlogsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogsContext>();
        optionsBuilder.UseSqlite("Data Source=blog.db");

        return new BlogsContext(optionsBuilder.Options);
    }
}

public class Blog
{
    public int Id { get; set; }
    
    public ICollection<Post> Posts { get; } = new List<Post>();
}

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public Blog Blog { get; set; } = null!;
}