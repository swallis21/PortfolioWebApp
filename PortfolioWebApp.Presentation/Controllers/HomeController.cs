using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Presentation.Attributes;
using PortfolioWebApp.Presentation.Models;
using System.Diagnostics;

namespace PortfolioWebApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [VirtualDom]
        public IActionResult Index()
        {
            return View();
        }

        [VirtualDom]
        public IActionResult Career()
        {
            return View();
        }

        [VirtualDom]
        public IActionResult About()
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
