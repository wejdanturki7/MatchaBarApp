namespace MatchaBarApp.Strategies;

public class EmployeeDiscount : IDiscountStrategy
{
    public string Name => "Employee Discount 20%";

    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.80m;
    }
}