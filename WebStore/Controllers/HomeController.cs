using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;


namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> __employees = new List<Employee>();

        public HomeController()
        {
#if DEBUG
            new WebStore.AppData.InMemoryData().Load(ref __employees);
#endif
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View(__employees);
        }

        public IActionResult DetailsEmployee (int id)
        {
            return View(__employees.Find(x => x.Id == id));
        }
    }
}
