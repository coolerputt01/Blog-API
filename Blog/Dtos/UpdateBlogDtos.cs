namespace Blog.Dtos;

public record UpdateBlogDtos (
    string title,
    string content,
    string category,
    DateOnly releaseDate
);
