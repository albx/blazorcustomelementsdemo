using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeBlog.Web.Site.Models;
using MyAwesomeBlog.Web.Site.Services;

namespace MyAwesomeBlog.Web.Site.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeControllerServices Services { get; }

    public HomeController(HomeControllerServices services, ILogger<HomeController> logger)
    {
        Services = services ?? throw new ArgumentNullException(nameof(services));
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = Services.GetIndexViewModel();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
