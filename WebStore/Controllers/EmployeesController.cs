using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;
using System;
using System.Linq;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _Employees;
        public EmployeesController(IEmployeesData EmloyeesData) => _Employees = EmloyeesData;
        //public IActionResult Index() => View(_Employees.Get());
        public IActionResult Index()
        {
            var employeesViewModel = _Employees.Get()
                .Select(employee => new EmployeeViewModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    ShortName = employee.ShortName,
                    Birthday = employee.Birthday,
                    Sex = employee.Sex,
                    Number = employee.Number,
                    InternalPhone = employee.InternalPhone,
                    HomePhone = employee.HomePhone,
                    MobilePhone = employee.MobilePhone,
                    BusinessPhone = employee.BusinessPhone,
                    Fax = employee.Fax,
                    Email = employee.Email,
                    ImagePath = employee.ImagePath
                });
            return View(employeesViewModel);
        }

        public IActionResult Details(int id)
        {
            var employee = _Employees.Details(id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                ShortName = employee.ShortName,
                Birthday = employee.Birthday,
                Sex = employee.Sex,
                Number = employee.Number,
                InternalPhone = employee.InternalPhone,
                HomePhone = employee.HomePhone,
                MobilePhone = employee.MobilePhone,
                BusinessPhone = employee.BusinessPhone,
                Fax = employee.Fax,
                Email = employee.Email,
                ImagePath = employee.ImagePath
            });
        }

        public IActionResult Create(Employee employee) => View("Edit", new EmployeeViewModel());

        #region Edit
        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();
            var employee = _Employees.Details(id);
            if (employee is not null)
                return View(new EmployeeViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic,
                    ShortName = employee.ShortName,
                    Birthday = employee.Birthday,
                    Sex = employee.Sex,
                    Number = employee.Number,
                    InternalPhone = employee.InternalPhone,
                    HomePhone = employee.HomePhone,
                    MobilePhone = employee.MobilePhone,
                    BusinessPhone = employee.BusinessPhone,
                    Fax = employee.Fax,
                    Email = employee.Email,
                    ImagePath = employee.ImagePath,
                });
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (!ModelState.IsValid) return View(model);

            var employee = new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                ShortName = model.ShortName,
                Birthday = model.Birthday,
                Sex = model.Sex,
                Number = model.Number,
                InternalPhone = model.InternalPhone,
                HomePhone = model.HomePhone,
                MobilePhone = model.MobilePhone,
                BusinessPhone = model.BusinessPhone,
                Fax = model.Fax,
                Email = model.Email,
                ImagePath = model.ImagePath,
            };

            if (employee.Id == 0)
                _Employees.Create(employee);
            else
                _Employees.Edit(employee);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _Employees.Details(id);

            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                ShortName = employee.ShortName,
                Birthday = employee.Birthday,
                Sex = employee.Sex,
                Number = employee.Number,
                InternalPhone = employee.InternalPhone,
                HomePhone = employee.HomePhone,
                MobilePhone = employee.MobilePhone,
                BusinessPhone = employee.BusinessPhone,
                Fax = employee.Fax,
                Email = employee.Email,
                ImagePath = employee.ImagePath
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _Employees.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
