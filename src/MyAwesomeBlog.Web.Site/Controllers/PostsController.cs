using Microsoft.AspNetCore.Mvc;

namespace MyAwesomeBlog.Web.Site.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Archive()
        {
            return View();
        }

        public IActionResult Detail(int id, string slug)
        {
            return View();
        }
    }
}
