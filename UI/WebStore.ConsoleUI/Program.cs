using Microsoft.Extensions.Configuration;
using System;
using WebStore.Clients.Products;

namespace WebStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var products_client = new ProductsClient(configuration);

            Console.WriteLine("К запросу готов!");
            Console.ReadLine();

            foreach (var itemproduct in products_client.GetProducts())
                Console.WriteLine("{0} - {1}", itemproduct.Name, itemproduct.Price);

            Console.WriteLine("Запрос завершен!");
            Console.ReadLine();
        }
    }
}
