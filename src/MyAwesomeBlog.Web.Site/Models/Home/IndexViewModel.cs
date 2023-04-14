namespace MyAwesomeBlog.Web.Site.Models.Home;

public class IndexViewModel
{
    public IEnumerable<PostItem> LatestPosts { get; set; } = Enumerable.Empty<PostItem>();

    public record PostItem
    {
        public int Id { get; init; }

        public string Title { get; init; } = string.Empty;

        public string Slug { get; init; } = string.Empty;

        public DateTime PublishDate { get; init; }
    }
}
