using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        [HttpGet] //http://localhost:5001/api/employees
        public IEnumerable<Employee> Get() => _EmployeesData.Get();

        [HttpGet("{id}")] //http://localhost:5001/api/employees/5
        public Employee Details(int id) => _EmployeesData.Details(id);

        [HttpPost] //http://localhost:5001/api/employees/
        public int Create(Employee employee) => _EmployeesData.Create(employee);

        [HttpPut] //http://localhost:5001/api/employees/5
        public void Edit(Employee employee) => _EmployeesData.Edit(employee);

        [HttpDelete("{id")] //http://localhost:5001/api/employees/5
        public bool Delete(int id) => _EmployeesData.Delete(id);
    }
}
