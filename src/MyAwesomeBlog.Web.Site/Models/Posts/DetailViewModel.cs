namespace MyAwesomeBlog.Web.Site.Models.Posts;

public class DetailViewModel
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Content { get; init; }

    public DateTime PublishDate { get; init; }
}
