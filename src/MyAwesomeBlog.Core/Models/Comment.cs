namespace MyAwesomeBlog.Core.Models;

public class Comment
{
    public int Id { get; set; }

    public string Author { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public virtual Post Post { get; set; }

    public int PostId { get; set; }

    public DateTime PostedAt { get; set; }
}
