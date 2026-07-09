using MatchaBarApp.Strategies;

namespace MatchaBarApp.Factories;

public static class DiscountFactory
{
    public static IDiscountStrategy CreateDiscount(int choice)
    {
        return choice switch
        {
            1 => new NoDiscount(),
            2 => new StudentDiscount(),
            3 => new HappyHourDiscount(),
            4 => new EmployeeDiscount(),
            _ => new NoDiscount()
        };
    }
}