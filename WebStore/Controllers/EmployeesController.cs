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

        public IActionResult Create()
        {
            Employee emploee = new Employee();
            return View(emploee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(employee is not null)
                employee.Id = _Employees.Max(i => i.Id) + 1;
            _Employees.Add(employee);
            return View("Index", _Employees);
        }

        public IActionResult Edit(int id)
        {
            var emploee = _Employees.FirstOrDefault(e => e.Id == id);
            if (emploee is not null)
                return View(emploee);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var currentEmployee = _Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (currentEmployee is not null)
                _Employees.Remove(currentEmployee);
            _Employees.Add(employee);
            _Employees.Sort();
            return View("Index", _Employees);
        }

        public IActionResult Delete(int id)
        {
            var emploee = _Employees.FirstOrDefault(e => e.Id == id);
            if (emploee is not null)
                _Employees.Remove(emploee);
            return View("Index", _Employees);
        }
    }
}
