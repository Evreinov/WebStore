using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebStore.Models;
using System.Threading.Tasks;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> __Employees { get; set; }
        public static async void LoadEmployeesAsync()
        {
            using (FileStream fs = new FileStream($"Data//DataFiles//Employees.json", FileMode.OpenOrCreate))
            {
                __Employees = await JsonSerializer.DeserializeAsync<List<Employee>>(fs);
            }
        }
    }
}
