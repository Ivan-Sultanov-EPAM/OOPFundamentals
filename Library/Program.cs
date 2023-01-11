using Library.Cache;
using Library.Repository;
using Library.StorageProviders;
using Library.UI;
using Microsoft.Extensions.Configuration;

namespace Library
{
    internal class Program
    {
        private static readonly IApp _app;

        static Program()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var cacheProvider = new AppCache(config);
            var fileStorageProvider = new FileStorageProvider();

            var fileRepository = new FileRepository(fileStorageProvider, cacheProvider);
            var ui = new ConsoleUI();

            _app = new App(fileRepository, ui);
            _app.InitializeData();
        }

        static void Main()
        {
            string mode;

            do
            {
                Console.WriteLine("To see all cards, enter All");
                Console.WriteLine("To search a card by number, enter a card number");

                mode = Console.ReadLine() ?? "";
                Console.WriteLine();

                if (mode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                {
                    _app.PrintAllCards();
                }

                if (int.TryParse(mode, out var number))
                {
                    _app.DisplayByNumber(number);
                }

            } while (mode.ToLower() != "q");
        }
    }
}