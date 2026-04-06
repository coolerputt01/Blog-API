using Company.ClassLibrary1;
using Blog.Dtos;
using System;
using Blog.Endpoints;
using Blog.Data;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddValidation();

        var connString = "Data Source=main.db";
        builder.Services.AddSqlite<BlogContext>(connString);
        var app = builder.Build();

        app.MapBlogEndpoints();

        app.Run();
    }
}