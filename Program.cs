using System.Text;
using MatchaBarApp.UI;

namespace MatchaBarApp;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        MatchaBarConsole app = new MatchaBarConsole();
        app.Run();
    }
}