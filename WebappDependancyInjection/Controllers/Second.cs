using Microsoft.AspNetCore.Mvc;
using WebappDependancyInjection;
namespace WebappDependancyInjection.Controllers
{
    public class SecondController : Controller
    {
        private readonly GetClassFactory _gcf;
        public SecondController(GetClassFactory getclassfactory)
        {
            _gcf = getclassfactory;
        }

        public IActionResult Index()
        {
            ViewBag.MyString = _gcf.GetClassDeatils("Mathee").getStudentCount();
            return View();
        }

    //    public IActionResult Index()
    //    {
    //        ViewBag.MyString = _student.getStudentCount().ToString();
    //        return View();
    //    }
    }
}
