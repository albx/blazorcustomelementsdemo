using Microsoft.AspNetCore.Mvc;
using MyAwesomeBlog.Web.Site.Services;

namespace MyAwesomeBlog.Web.Site.Controllers;

public class PostsController : Controller
{
    public PostsControllerServices Services { get; }

    public PostsController(PostsControllerServices services)
    {
        Services = services ?? throw new ArgumentNullException(nameof(services));
    }

    public IActionResult Archive(int page = 1)
    {
        var model = Services.GetPostsArchive(page);
        return View(model);
    }

    public IActionResult Detail(int id, string slug)
    {
        var model = Services.GetPostDetail(id, slug);
        return View(model);
    }
}
