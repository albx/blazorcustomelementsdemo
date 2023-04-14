using MyAwesomeBlog.Core;
using MyAwesomeBlog.Web.Site.Models.Home;

namespace MyAwesomeBlog.Web.Site.Services;

public class HomeControllerServices
{
    public MyAwesomeBlogContext Context { get; }

    public HomeControllerServices(MyAwesomeBlogContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IndexViewModel GetIndexViewModel()
    {
        var model = new IndexViewModel();

        var posts = Context.Posts
            .OrderByDescending(p => p.PublishDate)
            .Select(p => new IndexViewModel.PostItem
            {
               Id = p.Id,
               Title = p.Title,
               PublishDate = p.PublishDate,
               Slug = p.Slug
            }).Take(4).ToArray();

        model.LatestPosts = posts;

        return model;
    }
}
