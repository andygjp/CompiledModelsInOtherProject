// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var optionsBuilder = new DbContextOptionsBuilder<BlogsContext>()
    .UseSqlite("Data Source=blogs.db")
    .LogTo(Console.WriteLine)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging();

var blogsContext = new BlogsContext(optionsBuilder.Options);
blogsContext.Database.EnsureCreated();

Console.WriteLine($"There are {blogsContext.Blogs.Count()} blogs");

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