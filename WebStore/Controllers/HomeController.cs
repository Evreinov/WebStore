using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;


namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> __employees = new List<Employee>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
#if DEBUG
            new WebStore.AppData.InMemoryData().Load(ref __employees);
#endif
            return View(__employees);
        }

        public IActionResult DetailsEmployee (int id)
        {
            return View(__employees.Find(x => x.Id == id));
        }
    }
}
