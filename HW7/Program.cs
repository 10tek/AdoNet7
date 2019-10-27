using HW7.DataAccess;
using HW7.Models;
using HW7.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("DebugConnectionString");
            using (var context = new Context(connectionString))
            {
                var searchService = new SearchService(context);
                var pageNumber = 0;
                searchService.ShowGames();
                while (true)
                {
                    Console.Write("Введите номер страницы: ");
                    if (int.TryParse(Console.ReadLine(), out pageNumber) && searchService.GetPageCount() >= pageNumber && pageNumber > 0)
                    {
                        searchService.ShowGames(pageNumber);
                    }
                    else
                    {
                        Console.Write("Неккоректный ввод! Повторите попытку: ");
                    }
                }
            }
            //while (true)
            //{
            //    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            //    {
            //        Console.Clear();
            //        Console.Write($"{Guid.NewGuid()}");
            //    }
            //}
        }
    }
}
