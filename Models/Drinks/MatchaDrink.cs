using MatchaBarApp.Enums;

namespace MatchaBarApp.Models.Drinks;

public abstract class MatchaDrink
{
    public string Name { get; }
    public decimal BasePrice { get; }

    protected MatchaDrink(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public virtual decimal GetPrice(DrinkSize size)
    {
        decimal sizePrice = size switch
        {
            DrinkSize.Small => 0,
            DrinkSize.Medium => 3,
            DrinkSize.Large => 6,
            _ => 0
        };

        return BasePrice + sizePrice;
    }

    public abstract string GetDescription();
}