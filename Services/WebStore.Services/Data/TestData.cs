using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebStore.Domain.Entities;
using WebStore.Domain.Models;

namespace WebStore.Services.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; set; }
        public static async void LoadEmployeesAsync()
        {
            using (FileStream fs = new FileStream($"..//..//Services//WebStore.Services//Data//DataFiles//Employees.json", FileMode.OpenOrCreate))
            {
                Employees = await JsonSerializer.DeserializeAsync<List<Employee>>(fs);
            }
        }

        public static IEnumerable<Section> Sections { get; set; }
        public static void LoadSections()
        {
            using (StreamReader sr = new StreamReader($"..//..//Services//WebStore.Services//Data//DataFiles//Sections.json"))
            {
                Sections = JsonSerializer.Deserialize<IEnumerable<Section>>(sr.ReadToEnd());
            }
        }
        public static async void LoadSectionsAsync()
        {
            using (FileStream fs = new FileStream($"..//..//Services//WebStore.Services//Data//DataFiles//Sections.json", FileMode.OpenOrCreate))
            {
                Sections = await JsonSerializer.DeserializeAsync<IEnumerable<Section>>(fs);
            }
        }

        public static IEnumerable<Brand> Brands { get; set; }
        public static void LoadBrands()
        {
            using (StreamReader sr = new StreamReader($"..//..//Services//WebStore.Services//Data//DataFiles//Brands.json"))
            {
                Brands = JsonSerializer.Deserialize<IEnumerable<Brand>>(sr.ReadToEnd());
            }
        }
        public static async void LoadBrandsAsync()
        {
            using (FileStream fs = new FileStream($"..//..//Services//WebStore.Services//Data//DataFiles//Brands.json", FileMode.OpenOrCreate))
            {
                Brands = await JsonSerializer.DeserializeAsync<IEnumerable<Brand>>(fs);
            }
        }

        public static IEnumerable<Product> Products { get; set; }
        public static void LoadProducts()
        {
            using (StreamReader sr = new StreamReader($"..//..//Services//WebStore.Services//Data//DataFiles//Products.json"))
            {
                Products = JsonSerializer.Deserialize<IEnumerable<Product>>(sr.ReadToEnd());
            }
        }
        public static async void LoadProductsAsync()
        {
            using (FileStream fs = new FileStream($"..//..//Services//WebStore.Services//Data//DataFiles//Products.json", FileMode.OpenOrCreate))
            {
                Products = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(fs);
            }
        }
    }
}
