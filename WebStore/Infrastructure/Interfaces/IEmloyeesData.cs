using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    interface IEmloyeesData
    {
        IEnumerable<Employee> Get();

        Employee Details(int id);

        int Create(Employee employee);

        void Edit(Employee employee);

        bool Delete(int id);
    }
}
