namespace MatchaBarApp.Models.Drinks;

public class ClassicMatcha : MatchaDrink
{
    public ClassicMatcha() : base("Classic Matcha", 18)
    {
    }

    public override string GetDescription()
    {
        return "Pure matcha with milk and a smooth taste.";
    }
}