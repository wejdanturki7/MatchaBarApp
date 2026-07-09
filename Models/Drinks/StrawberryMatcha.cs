namespace MatchaBarApp.Models.Drinks;

public class StrawberryMatcha : MatchaDrink
{
    public StrawberryMatcha() : base("Strawberry Matcha", 24)
    {
    }

    public override string GetDescription()
    {
        return "Matcha latte with fresh strawberry flavor.";
    }
}