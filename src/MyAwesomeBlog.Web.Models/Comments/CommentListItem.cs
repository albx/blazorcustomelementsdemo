namespace MyAwesomeBlog.Web.Models.Comments;

public class CommentListItem
{
    public int Id { get; init; }

    public string Author { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;

    public DateTime PostedAt { get; init; }
}
