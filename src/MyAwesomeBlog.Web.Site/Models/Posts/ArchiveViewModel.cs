namespace MyAwesomeBlog.Web.Site.Models.Posts;

public class ArchiveViewModel
{
    public IEnumerable<PostItem> Posts { get; set; } = Enumerable.Empty<PostItem>();

    public int PageCount { get; set; }

    public int CurrentPage { get; set; }

    public record PostItem
    {
        public int Id { get; init; }

        public string Title { get; init; } = string.Empty;

        public string Slug { get; init; } = string.Empty;

        public DateTime PublishDate { get; init; }
    }
}
