using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Identity;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    { 
        private readonly IEmployeesData _Employees;

        // Создание конфигурации сопоставления и настройка AutoMapper'а для Employee in EmployeeViewModel
        private readonly Mapper mapperViewModel = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeViewModel>()));

        // Создание конфигурации сопоставления и настройка AutoMapper'а для EmployeeViewModel in Employee
        private readonly Mapper omapperModel = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, Employee>()));

        public EmployeesController(IEmployeesData EmloyeesData) => _Employees = EmloyeesData;

        public IActionResult Index()
        {
            return View(mapperViewModel.Map<IEnumerable<EmployeeViewModel>>(_Employees.Get()));
        }

        public IActionResult Details(int id)
        {
            var employee = _Employees.Details(id);
            if (employee is null)
                return NotFound();
            return View(mapperViewModel.Map<EmployeeViewModel>(employee));
        }

        public IActionResult Create(Employee employee) => View("Edit", new EmployeeViewModel());

        #region Edit
        [Authorize (Roles = Role.Administrators)]
        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();
            var employee = _Employees.Details(id);
            if (employee is not null)
                return View(mapperViewModel.Map<EmployeeViewModel>(employee));
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (!ModelState.IsValid) return View(model);

            var employee = omapperModel.Map<Employee>(model);

            if (employee.Id == 0)
                _Employees.Create(employee);
            else
                _Employees.Edit(employee);

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [Authorize(Roles = Role.Administrators)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _Employees.Details(id);

            if (employee is null)
                return NotFound();

            return View(mapperViewModel.Map<EmployeeViewModel>(employee));
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
