using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _Employees;
        private int _CurrentMaxId;
        public InMemoryEmployeesData()
        {
            _Employees = Data.TestData.__Employees;
            _CurrentMaxId = _Employees.DefaultIfEmpty().Max(e => e?.Id ?? 1);
        }
        public IEnumerable<Employee> Get() => _Employees;
        public Employee Details(int id) => _Employees.FirstOrDefault(e => e.Id == id);
        public int Create(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (_Employees.Contains(employee)) return employee.Id;
            employee.Id = ++_CurrentMaxId;
            _Employees.Add(employee);
            return employee.Id;
        }
        public void Edit(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (_Employees.Contains(employee)) return;
            var item = Details(employee.Id);
            if (item is null) return;
            item.FirstName = employee.FirstName;
            item.LastName = employee.LastName;
            item.Patronymic = employee.Patronymic;
            item.ShortName = employee.ShortName;
            item.Birthday = employee.Birthday;
            item.Sex = employee.Sex;
            item.Number = employee.Number;
            item.InternalPhone = employee.InternalPhone;
            item.HomePhone = employee.HomePhone;
            item.MobilePhone = employee.MobilePhone;
            item.BusinessPhone = employee.BusinessPhone;
            item.Fax = employee.Fax;
            item.Email = employee.Email;
            item.ImagePath = employee.ImagePath;
        }

        public bool Delete(int id)
        {
            var item = Details(id);
            if (item is null) return false;
            return _Employees.Remove(item);
        }
    }
}
