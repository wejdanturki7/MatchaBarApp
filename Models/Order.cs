using MatchaBarApp.Enums;
using MatchaBarApp.Models.Drinks;
using MatchaBarApp.Strategies;

namespace MatchaBarApp.Models;

public class Order
{
    public MatchaDrink Drink { get; }
    public DrinkSize Size { get; }
    public List<Topping> Toppings { get; }
    public IDiscountStrategy DiscountStrategy { get; }

    public Order(
        MatchaDrink drink,
        DrinkSize size,
        List<Topping> toppings,
        IDiscountStrategy discountStrategy)
    {
        Drink = drink;
        Size = size;
        Toppings = toppings;
        DiscountStrategy = discountStrategy;
    }
}