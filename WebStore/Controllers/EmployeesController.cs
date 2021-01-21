using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private List<Employee> _Employees;
        public EmployeesController()
        {
            _Employees = Data.TestData.Employees;
        }
        public IActionResult Index() => View(_Employees);

        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is not null)
                return View(employee);
            return NotFound();
        }
    }
}
