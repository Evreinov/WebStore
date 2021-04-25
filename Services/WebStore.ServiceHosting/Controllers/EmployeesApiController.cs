using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;
        private readonly ILogger<EmployeesApiController> _Logger;

        public EmployeesApiController(IEmployeesData EmployeesData, ILogger<EmployeesApiController> Logger)
        {
            _EmployeesData = EmployeesData;
            _Logger = Logger;
        }

        [HttpGet] //http://localhost:5001/api/employees
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")] //http://localhost:5001/api/employees/5
        public Employee Details(int id) => _EmployeesData.Details(id);

        [HttpPost] //http://localhost:5001/api/employees/
        public int Create(Employee employee)
        {
            _Logger.LogInformation("Добавление сотрудника {0}", employee);
            return _EmployeesData.Create(employee);
        }

        [HttpPut] //http://localhost:5001/api/employees/5
        public void Edit(Employee employee)
        {
            _Logger.LogInformation("Редактирование сотрудника {0}", employee);
            _EmployeesData.Edit(employee);
        }

        [HttpDelete("{id}")] //http://localhost:5001/api/employees/5
        public bool Delete(int id)
        {
            _Logger.LogInformation("Удаление сотрудника {0}...", _EmployeesData.Details(id));
            var result = _EmployeesData.Delete(id);
            _Logger.LogInformation("Удаление сотрудника - {0}", result ? "выполнено" : "не выполнено");
            return result;
        }
    }
}
