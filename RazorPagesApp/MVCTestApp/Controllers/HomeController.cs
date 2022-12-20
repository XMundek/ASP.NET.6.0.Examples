using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MVCTestApp.Models;
using System.Diagnostics;

namespace MVCTestApp.Controllers
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
            var logger = this.HttpContext.RequestServices.GetService<ILogger<HomeController>>();
            try
            {
                var config = this.HttpContext.RequestServices.GetService<IConfiguration>();
                //Request.Query["viewName"].ToString()
                var section = config.GetSection("AppSettings");
                var viewName = section["HomeView"];
                logger.Log(LogLevel.Information, "Home index processed");
                throw new Exception("My test exception");
                return View(viewName);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error in HomeIndex");
                return View("Error", new ErrorViewModel() { RequestId = Request.Path });
            }
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