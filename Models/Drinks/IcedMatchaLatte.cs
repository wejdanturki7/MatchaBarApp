namespace MatchaBarApp.Models.Drinks;

public class IcedMatchaLatte : MatchaDrink
{
    public IcedMatchaLatte() : base("Iced Matcha Latte", 20)
    {
    }

    public override string GetDescription()
    {
        return "Cold matcha latte served with ice.";
    }
}