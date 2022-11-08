using Microsoft.AspNetCore.Mvc;
using MVC_Apps.Models;
using System.Diagnostics;

namespace MVC_Apps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // THe View() w/o parameter
            // will return the view that matches
            // with the Action Method NAme
            // In the Sub-Folder of Views folder that matches
            // with the Controller NAme
            ViewData["Message"] = "Hello World MVC!!";
            ViewBag.Message = "This is From the ViewBag";
            return View();
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
}