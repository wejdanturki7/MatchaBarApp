namespace MatchaBarApp.Strategies;

public class StudentDiscount : IDiscountStrategy
{
    public string Name => "Student Discount 10%";

    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.90m;
    }
}