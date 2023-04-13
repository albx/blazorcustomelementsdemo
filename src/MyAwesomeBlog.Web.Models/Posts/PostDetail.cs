namespace MyAwesomeBlog.Web.Models.Posts;

public class PostDetail
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public string? Content { get; init; }

    public DateTime PublishDate { get; init; }
}
