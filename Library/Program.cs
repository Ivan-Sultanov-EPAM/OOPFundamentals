namespace Library
{
    internal class Program
    {
        private static string _mode;

        static void Main()
        {
            App.InitializeData();

            do
            {
                Console.WriteLine("To see all cards, enter All");
                Console.WriteLine("To search a card by number, enter a card number");

                _mode = Console.ReadLine() ?? "";

                if (_mode.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                {
                    App.PrintAllCards();
                }

                if (int.TryParse(_mode, out var number))
                {
                    App.DisplayByNumber(number);
                }

            } while (_mode.ToLower() != "q");
        }
    }
}