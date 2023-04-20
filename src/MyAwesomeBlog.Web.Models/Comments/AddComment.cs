using System.ComponentModel.DataAnnotations;

namespace MyAwesomeBlog.Web.Models.Comments;

public class AddComment
{
    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;
}
