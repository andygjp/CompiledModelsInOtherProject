// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;

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
    public BlogsContext()
    {
        // It seems I need a public parameterless constructor to get auto compiled models to work
    }

    public BlogsContext(DbContextOptions<BlogsContext> options) : base(options)
    {
    }

    protected BlogsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured is false)
        {
            // It seems I need provider to get auto compiled models to work
            optionsBuilder.UseSqlite("Data Source=blogs.db");
        }
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