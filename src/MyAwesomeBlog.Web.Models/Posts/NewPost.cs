namespace MyAwesomeBlog.Web.Models.Posts;

public class NewPost
{
    public string Title { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public string? Content { get; init; }
}
