namespace Blog.Endpoints;
using Blog.Dtos;
using Company.ClassLibrary1;

public static class BlogEndpoints
{
    const string GetBlogEndpointName = "GetBlog";

    private static readonly List<Blogdtos> blogs = [
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

    public static void MapBlogEndpoints(this WebApplication app){
        var group = app.MapGroup("/blogs");

        group.MapGet("/", () => blogs);

        group.MapGet("/{id}", (int id) => {
            var blog = blogs.Find(blog => blog.ID == id);
            if (blog is null){
                return Results.NotFound();
            }else{
                return Results.Ok(blog);
            }
        }).WithName(GetBlogEndpointName);

        group.MapPost("/", (CreateBlogDtos newBlog)=>
        {
            Blogdtos blog = new (
                blogs.Count + 1,
                newBlog.title,
                newBlog.content,
                newBlog.category,
                DateOnly.FromDateTime(DateTime.UtcNow)
            );
            blogs.Add(blog);

            return Results.CreatedAtRoute(GetBlogEndpointName,new {id = blog.ID},blog);
        });

        group.MapPut("/{id}",(int id,UpdateBlogDtos updatedBlog) =>
        {
            var index = blogs.FindIndex(blog => blog.ID == id);

            if (index == -1){
                return Results.NotFound();
            }

            blogs[index] = new Blogdtos(
                id,
                updatedBlog.title,
                updatedBlog.content,
                updatedBlog.category,
                updatedBlog.releaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}",(int id) => {
            blogs.RemoveAll(blog => (id == blog.ID));
            return Results.NoContent();
        });
    }
}
