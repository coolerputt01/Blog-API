namespace Blog.Dtos;

public record CreateBlogDtos (
    string title,
    string category,
    string content
);