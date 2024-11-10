using Microsoft.AspNetCore.Mvc;
using RouteApi.Models;
using System.Diagnostics;

namespace RouteApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            this.ViewData["APP_NAME"] = _configuration.GetValue<string>("APP_NAME");
            this.ViewData["MACHINE_NAME"] = Environment.MachineName;
            this.ViewData["REQUEST_HOST"] = this.Request.Host;
            this.ViewData["REQUEST_PATH"] = this.Request.Path;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
