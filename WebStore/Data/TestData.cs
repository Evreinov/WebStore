using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebStore.Models;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; set; }
        public static async void LoadEmployeesAsync()
        {
            using (FileStream fs = new FileStream($"Data//DataFiles//Employees.json", FileMode.OpenOrCreate))
            {
                Employees = await JsonSerializer.DeserializeAsync<List<Employee>>(fs);
            }
        }

        public static IEnumerable<Section> Sections { get; set; }
        public static async void LoadSectionsAsync()
        {
            using (FileStream fs = new FileStream($"Data//DataFiles//Sections.json", FileMode.OpenOrCreate))
            {
                Sections = await JsonSerializer.DeserializeAsync<IEnumerable<Section>>(fs);
            }
        }

        public static IEnumerable<Brand> Brands { get; set; }
        public static async void LoadBrandssAsync()
        {
            using (FileStream fs = new FileStream($"Data//DataFiles//Brands.json", FileMode.OpenOrCreate))
            {
                Brands = await JsonSerializer.DeserializeAsync<IEnumerable<Brand>>(fs);
            }
        }
    }
}
