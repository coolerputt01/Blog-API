namespace Blog.Dtos;

public record UpdateBlogDtos (
    [StringLength(50)] string title,
    string content,
    [StringLength(30)] string category,
    DateOnly releaseDate
);
