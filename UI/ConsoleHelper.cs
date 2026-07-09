namespace MatchaBarApp.UI;

public static class ConsoleHelper
{
    public static int ReadInt(string message, int min, int max)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            bool isValidNumber = int.TryParse(input, out int number);

            if (isValidNumber && number >= min && number <= max)
            {
                return number;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please enter a number between {min} and {max}.");
            Console.ResetColor();
        }
    }

    public static void PrintHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("====================================");
        Console.WriteLine($"        {title}");
        Console.WriteLine("====================================");
        Console.ResetColor();
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}