namespace MatchaBarApp.Strategies;

public class HappyHourDiscount : IDiscountStrategy
{
    public string Name => "Happy Hour Discount 15%";

    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.85m;
    }
}