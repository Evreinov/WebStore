using System.Collections.Generic;
using WebStore.Domain.Models;

namespace WebStore.Interfaces.Services
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Get();

        Employee Details(int id);

        int Create(Employee employee);

        void Edit(Employee employee);

        bool Delete(int id);
    }
}
