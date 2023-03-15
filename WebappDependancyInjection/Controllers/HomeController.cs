using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebappDependancyInjection.Models;
using WebappDependancyInjection;
namespace WebappDependancyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetClassFactory _gcf;
        public HomeController(ILogger<HomeController> logger, GetClassFactory getclassfactory)
        {
            _logger = logger;
            _gcf = getclassfactory;
        }

        public IActionResult Index()
        {
            ViewBag.MyString = _gcf.GetClassDeatils("Math").getStudentCount();
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