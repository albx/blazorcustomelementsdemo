using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Web.Site.Models.Posts;

namespace MyAwesomeBlog.Web.Site.Services;

public class PostsControllerServices
{
    public MyAwesomeBlogContext Context { get; }

    public PostsControllerServices(MyAwesomeBlogContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public DetailViewModel? GetPostDetail(int id, string slug)
    {
        var post = Context.Posts.SingleOrDefault(p => p.Id == id && p.Slug == slug);
        if (post is null)
        {
            return null;
        }

        return new DetailViewModel
        {
            Id = post.Id,
            Content = post.Content,
            PublishDate = post.PublishDate,
            Title = post.Title 
        };
    }

    public ArchiveViewModel GetPostsArchive(int page)
    {
        var skip = (page - 1) * 20;

        var posts = Context.Posts.AsNoTracking()
            .OrderBy(p => p.PublishDate)
            .Select(p => new ArchiveViewModel.PostItem
            {
                Id = p.Id,
                Title = p.Title,
                PublishDate = p.PublishDate,
                Slug = p.Slug
            });

        var pageCount = posts.Any() ? (int)Math.Ceiling(posts.Count() / 20.0) : 1;

        var model = new ArchiveViewModel
        {
            CurrentPage = page,
            PageCount = pageCount,
            Posts = posts.Skip(skip).Take(20).ToArray()
        };

        return model;
    }
}
