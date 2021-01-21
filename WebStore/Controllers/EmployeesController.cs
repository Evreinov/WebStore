using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
