using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EmployeesClient> _Logger;

        public EmployeesClient(IConfiguration Configuration, ILogger<EmployeesClient> Logger) 
            : base(Configuration, WebAPI.Employees)
        {
            _Logger = Logger;
        }

        public int Create(Employee employee) => Post(Address, employee).Content.ReadAsAsync<int>().Result;

        public bool Delete(int id)
        {
            _Logger.LogInformation("Удаление сотрудника {0}...", Details(id));
            using (_Logger.BeginScope("Удаление сотрудника {0}", Details(id)))
            { 
                var result = Delete($"{Address}/{id}").IsSuccessStatusCode;
                _Logger.LogInformation("Удаление сотрудника - {0}", result ? "выполнено" : "не выполнено");
                return result;
            }
        }

        public Employee Details(int id) => Get<Employee>($"{Address}/{id}");

        public void Edit(Employee employee) => Put(Address, employee);

        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(Address);
    }
}
