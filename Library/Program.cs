using Library.Entities;
using Library.Repository;
using Library.StorageProviders;
using Library.UI;

namespace Library
{
    internal class Program
    {
        private static readonly IApp _app;

        static Program()
        {
            var storageProvider = new FileStorageProvider();

            var bookFileRepository = new FileRepository<Book>(storageProvider);
            var localizedBookFileRepository = new FileRepository<LocalizedBook>(storageProvider);
            var patentFileRepository = new FileRepository<Patent>(storageProvider);
            var ui = new ConsoleUI();

            _app = new App(bookFileRepository, localizedBookFileRepository, patentFileRepository, ui);
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