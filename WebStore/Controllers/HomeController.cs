using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View(new WebStore.AppData.InMemoryData().Employees);
        }
    }
}
