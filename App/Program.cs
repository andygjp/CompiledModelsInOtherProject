// See https://aka.ms/new-console-template for more information

using Context;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<BlogsContext>()
    .UseSqlite("Data Source=blogs.db")
    .LogTo(Console.WriteLine)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging();

var blogsContext = new BlogsContext(optionsBuilder.Options);
blogsContext.Database.EnsureCreated();

Console.WriteLine($"There are {blogsContext.Blogs.Count()} blogs");