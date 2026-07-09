using MatchaBarApp.Models;

namespace MatchaBarApp.Services;

public class ReceiptPrinter
{
    private readonly OrderService _orderService;

    public ReceiptPrinter(OrderService orderService)
    {
        _orderService = orderService;
    }

    public void Print(Order order)
    {
        decimal subtotal = _orderService.CalculateSubtotal(order);
        decimal total = _orderService.CalculateTotal(order);
        decimal discountAmount = subtotal - total;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n====================================");
        Console.WriteLine("             RECEIPT");
        Console.WriteLine("====================================");
        Console.ResetColor();

        Console.WriteLine($"Drink       : {order.Drink.Name}");
        Console.WriteLine($"Description : {order.Drink.GetDescription()}");
        Console.WriteLine($"Size        : {order.Size}");

        if (order.Toppings.Count == 0)
        {
            Console.WriteLine("Toppings    : None");
        }
        else
        {
            string toppings = string.Join(", ",
                order.Toppings.Select(topping => ToppingPricing.GetToppingName(topping)));

            Console.WriteLine($"Toppings    : {toppings}");
        }

        Console.WriteLine($"Discount    : {order.DiscountStrategy.Name}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Subtotal    : {subtotal:0.00} SAR");
        Console.WriteLine($"Saved       : {discountAmount:0.00} SAR");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Total       : {total:0.00} SAR");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("====================================");
        Console.WriteLine("Thank you for visiting Matcha Bar!");
        Console.WriteLine("====================================\n");
        Console.ResetColor();
    }
}