using System.ComponentModel.DataAnnotations;
namespace Blog.Dtos;

public record CreateBlogDtos (
    [Required] [StringLength(50)] string title,
    [Required] [StringLength(30)] string category,
    [Required] string content
);