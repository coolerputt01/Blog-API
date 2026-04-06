using Company.ClassLibrary1;
using Blog.Dtos;
using System;
using Blog.Endpoints;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddValidation();
        var app = builder.Build();

        app.MapBlogEndpoints();

        app.Run();
    }
}