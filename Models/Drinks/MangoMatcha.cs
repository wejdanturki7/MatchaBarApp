namespace MatchaBarApp.Models.Drinks;

public class MangoMatcha : MatchaDrink
{
    public MangoMatcha() : base("Mango Matcha", 25)
    {
    }

    public override string GetDescription()
    {
        return "Matcha latte mixed with mango flavor.";
    }
}