namespace MyAwesomeBlog.Web.Models.Posts;

public class PostListItem
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public DateTime PublishDate { get; init; }
}
