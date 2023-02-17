namespace MyAwesomeBlog.Core.Models;

public class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Content { get; set; }

    public DateTime PublishDate { get; set; }
}
