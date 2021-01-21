using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees 
        { 
            get;
            set;
        }

        public static void Load()
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
                        ShortName = $"Фамилия{i} И. О.",
                        Birthday = DateTime.Now.AddMonths(i * 2 - 560),
                        Sex = i % 2 == 0 ? 0 : 1,
                        Number = i.ToString("D5"),
                        InternalPhone = $"1{i:D2}",
                        HomePhone = $"+712345678{i:D2}",
                        MobilePhone = $"+712345678{i:D2}",
                        BusinessPhone = $"+712345678{i:D2}",
                        Fax = $"+712345678{i:D2}",
                        Email = $"user{i}@supermail.ru",
                        ImagePath = i % 2 == 0 ? $"~/img/profile_female.png" : $"~/img/profile_male.png"
                    })
                    .ToList();
            }
        }
    }
}
