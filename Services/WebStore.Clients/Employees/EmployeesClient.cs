using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Domain.Models;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration Configuration) : base(Configuration, WebAPI.Employees) { TestData.LoadEmployees(); }

        public int Create(Employee employee) => Post(Address, employee).Content.ReadAsAsync<int>().Result;

        public bool Delete(int id) => Delete($"{Address}/{id}").IsSuccessStatusCode;

        public Employee Details(int id) => Get<Employee>($"{Address}/{id}");

        public void Edit(Employee employee) => Put(Address, employee);

        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(Address);
    }
}
