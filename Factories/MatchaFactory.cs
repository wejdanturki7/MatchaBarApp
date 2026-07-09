using MatchaBarApp.Models.Drinks;

namespace MatchaBarApp.Factories;

public static class MatchaFactory
{
    public static MatchaDrink CreateDrink(int choice)
    {
        return choice switch
        {
            1 => new ClassicMatcha(),
            2 => new StrawberryMatcha(),
            3 => new VanillaMatcha(),
            4 => new IcedMatchaLatte(),
            5 => new MangoMatcha(),
            _ => throw new ArgumentException("Invalid drink choice.")
        };
    }
}