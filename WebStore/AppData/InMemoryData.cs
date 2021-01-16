using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.AppData
{
    public class InMemoryData
    {
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public InMemoryData()
        {
            Load();
        }
        public void Load()
        {
            if (Employees is null || Employees.Count == 0)
            {
                Employees = Enumerable.Range(1, 45)
                    .Select(i => new Employee
                    {
                        Id = i,
                        FirstName = $"Имя{i}",
                        LastName = $"Фамилия{i}",
                        Patronymic = $"Отчество{i}",
                        ShortName = $"Фамилия{i} И{i}. О{i}.",
                        Birthday = DateTime.Now.AddMonths(i * 2 + 240),
                        Sex = i % 2 == 0 ? 0 : 1,
                        Number = i.ToString("D5"),
                        InternalPhone = $"1{i:D2}",
                        HomePhone = $"+712345678{i:D2}",
                        MobilePhone = $"+712345678{i:D2}",
                        BusinessPhone = $"+712345678{i:D2}",
                        Fax = $"+712345678{i:D2}",
                        Email = $"user{i}@supermail.ru"
                    })
                    .ToList();
            }
        }
    }
}
