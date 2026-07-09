namespace MatchaBarApp.Models.Drinks;

public class VanillaMatcha : MatchaDrink
{
    public VanillaMatcha() : base("Vanilla Matcha", 22)
    {
    }

    public override string GetDescription()
    {
        return "Matcha latte with sweet vanilla flavor.";
    }
}