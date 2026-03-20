using Company.ClassLibrary1;
using System;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        List<Blogdtos> blogs = [
            new (
                1,
                "How to implement Bresenhams Algorithm in that art editor.",
                "Many things to do bruhhhh",
                "Developer",
                new DateOnly(2026,12,1)
            ),
            new (
                2,
                "Understanding Midpoint Circle Algorithm for Drawing Tools",
                "A deep dive into efficient circle rendering in pixel-based editors.",
                "Graphics Dev",
                new DateOnly(2026, 11, 15)
            ),

            new (
                3,
                "Optimizing Canvas Rendering Performance",
                "Tips and tricks to make your art editor smooth and responsive.",
                "Performance Engineer",
                new DateOnly(2026, 10, 20)
            ),

            new (
                4,
                "Implementing Undo/Redo in a Drawing Application",
                "Learn how to manage state history effectively in your editor.",
                "Software Architect",
                new DateOnly(2026, 9, 30)
            ),

            new (
                5,
                "Raster vs Vector Graphics: What Your Editor Should Support",
                "Breaking down the pros and cons of raster and vector approaches.",
                "UI Engineer",
                new DateOnly(2026, 8, 18)
            ),

            new (
                6,
                "Handling Mouse Input for Precision Drawing",
                "Capture and process user input for smooth and accurate strokes.",
                "Frontend Dev",
                new DateOnly(2026, 7, 25)
            )
        ];

        var app = builder.Build();

        app.MapGet("/blogs", () => blogs);

        app.MapGet("/blog/{id}", (int id) => blogs.Find(blog => blog.ID == id));

        app.MapPost("/blogs", (CreateBlogDtos newBlog)=>
        {
            BlogDtos blog = new (
                blogs.Count + 1,
                newBlog.title,
                newBlog.content,
                newBlog.category,
                new DateOnly.FromDateTime(DateTime.UtcNow)
            );
        });

        app.Run();
    }
}