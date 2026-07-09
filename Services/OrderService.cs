using MatchaBarApp.Models;

namespace MatchaBarApp.Services;

public class OrderService
{
    public decimal CalculateSubtotal(Order order)
    {
        decimal drinkPrice = order.Drink.GetPrice(order.Size);

        decimal toppingsPrice = order.Toppings
            .Sum(topping => ToppingPricing.GetToppingPrice(topping));

        return drinkPrice + toppingsPrice;
    }

    public decimal CalculateTotal(Order order)
    {
        decimal subtotal = CalculateSubtotal(order);
        return order.DiscountStrategy.ApplyDiscount(subtotal);
    }
}