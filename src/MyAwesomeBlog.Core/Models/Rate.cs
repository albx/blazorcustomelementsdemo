namespace MyAwesomeBlog.Core.Models;

public class Rate
{
    public int Id { get; set; }

    public int Value { get; set; }

    public virtual Post Post { get; set; }

    public int PostId { get; set; }
}
