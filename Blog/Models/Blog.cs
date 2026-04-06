using System;

namespace Blog.Models;

public class Blog
{
    public int ID {get; set;}

    public required string title {get;set;}
    public required string content {get;set;}

    public Category? category{get;set;}
    public int categoryID{get;set;}

    public DateOnly releaseDate {get;set;}

}
