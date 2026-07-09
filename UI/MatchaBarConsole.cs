using MatchaBarApp.Enums;
using MatchaBarApp.Factories;
using MatchaBarApp.Models;
using MatchaBarApp.Models.Drinks;
using MatchaBarApp.Services;
using MatchaBarApp.Strategies;

namespace MatchaBarApp.UI;

public class MatchaBarConsole
{
    private readonly List<Order> _orders;
    private readonly OrderService _orderService;
    private readonly ReceiptPrinter _receiptPrinter;

    public MatchaBarConsole()
    {
        _orders = new List<Order>();
        _orderService = new OrderService();
        _receiptPrinter = new ReceiptPrinter(_orderService);
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            ConsoleHelper.PrintHeader("MATCHA BAR ORDERING SYSTEM");

            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. View Orders Summary");
            Console.WriteLine("0. Exit");

            int choice = ConsoleHelper.ReadInt("\nChoose an option: ", 0, 2);

            switch (choice)
            {
                case 1:
                    CreateOrder();
                    break;

                case 2:
                    ShowOrdersSummary();
                    break;

                case 0:
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;
            }
        }
    }

    private void CreateOrder()
    {
        Console.Clear();
        ConsoleHelper.PrintHeader("CREATE NEW ORDER");

        ShowDrinksMenu();

        int drinkChoice = ConsoleHelper.ReadInt("\nChoose your drink: ", 1, 5);
        MatchaDrink drink = MatchaFactory.CreateDrink(drinkChoice);

        Console.Clear();
        ConsoleHelper.PrintHeader("CHOOSE SIZE");

        Console.WriteLine("1. Small");
        Console.WriteLine("2. Medium  +3 SAR");
        Console.WriteLine("3. Large   +6 SAR");

        int sizeChoice = ConsoleHelper.ReadInt("\nChoose size: ", 1, 3);
        DrinkSize size = (DrinkSize)sizeChoice;

        Console.Clear();
        ConsoleHelper.PrintHeader("CHOOSE TOPPINGS");

        List<Topping> toppings = ChooseToppings();

        Console.Clear();
        ConsoleHelper.PrintHeader("CHOOSE DISCOUNT");

        Console.WriteLine("1. No Discount");
        Console.WriteLine("2. Student Discount 10%");
        Console.WriteLine("3. Happy Hour Discount 15%");
        Console.WriteLine("4. Employee Discount 20%");

        int discountChoice = ConsoleHelper.ReadInt("\nChoose discount: ", 1, 4);
        IDiscountStrategy discountStrategy = DiscountFactory.CreateDiscount(discountChoice);

        Order order = new Order(drink, size, toppings, discountStrategy);
        _orders.Add(order);

        Console.Clear();
        _receiptPrinter.Print(order);

        ConsoleHelper.Pause();
    }

    private List<Topping> ChooseToppings()
    {
        List<Topping> toppings = new List<Topping>();
        bool choosing = true;

        while (choosing)
        {
            Console.WriteLine("1. Boba              +4 SAR");
            Console.WriteLine("2. Oat Milk          +3 SAR");
            Console.WriteLine("3. Vanilla Syrup     +2 SAR");
            Console.WriteLine("4. Strawberry Foam   +5 SAR");
            Console.WriteLine("5. Extra Matcha      +4 SAR");
            Console.WriteLine("0. Done");

            int choice = ConsoleHelper.ReadInt("\nChoose topping: ", 0, 5);

            if (choice == 0)
            {
                choosing = false;
            }
            else
            {
                Topping selectedTopping = (Topping)choice;

                if (toppings.Contains(selectedTopping))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This topping is already added.\n");
                    Console.ResetColor();
                }
                else
                {
                    toppings.Add(selectedTopping);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Topping added successfully.\n");
                    Console.ResetColor();
                }
            }
        }

        return toppings;
    }

    private void ShowDrinksMenu()
    {
        Console.WriteLine("1. Classic Matcha        18 SAR");
        Console.WriteLine("2. Strawberry Matcha     24 SAR");
        Console.WriteLine("3. Vanilla Matcha        22 SAR");
        Console.WriteLine("4. Iced Matcha Latte     20 SAR");
        Console.WriteLine("5. Mango Matcha          25 SAR");
    }

    private void ShowOrdersSummary()
    {
        Console.Clear();
        ConsoleHelper.PrintHeader("ORDERS SUMMARY");

        if (_orders.Count == 0)
        {
            Console.WriteLine("No orders yet.");
            ConsoleHelper.Pause();
            return;
        }

        decimal grandTotal = 0;

        for (int i = 0; i < _orders.Count; i++)
        {
            Order order = _orders[i];
            decimal total = _orderService.CalculateTotal(order);
            grandTotal += total;

            Console.WriteLine($"Order #{i + 1}");
            Console.WriteLine($"Drink    : {order.Drink.Name}");
            Console.WriteLine($"Size     : {order.Size}");
            Console.WriteLine($"Discount : {order.DiscountStrategy.Name}");
            Console.WriteLine($"Total    : {total:0.00} SAR");
            Console.WriteLine("------------------------------------");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Grand Total: {grandTotal:0.00} SAR");
        Console.ResetColor();

        ConsoleHelper.Pause();
    }
}