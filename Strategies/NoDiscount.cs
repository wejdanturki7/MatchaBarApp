namespace MatchaBarApp.Strategies;

public class NoDiscount : IDiscountStrategy
{
    public string Name => "No Discount";

    public decimal ApplyDiscount(decimal total)
    {
        return total;
    }
}