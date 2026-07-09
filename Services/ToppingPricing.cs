using MatchaBarApp.Enums;

namespace MatchaBarApp.Services;

public static class ToppingPricing
{
    public static decimal GetToppingPrice(Topping topping)
    {
        return topping switch
        {
            Topping.Boba => 4,
            Topping.OatMilk => 3,
            Topping.VanillaSyrup => 2,
            Topping.StrawberryFoam => 5,
            Topping.ExtraMatcha => 4,
            _ => 0
        };
    }

    public static string GetToppingName(Topping topping)
    {
        return topping switch
        {
            Topping.Boba => "Boba",
            Topping.OatMilk => "Oat Milk",
            Topping.VanillaSyrup => "Vanilla Syrup",
            Topping.StrawberryFoam => "Strawberry Foam",
            Topping.ExtraMatcha => "Extra Matcha",
            _ => "Unknown"
        };
    }
}