# Matcha Bar Ordering System

## About the Project

This project is a simple console application for a matcha bar.
The idea is that the user can create an order by choosing a matcha drink, size, toppings, and discount type. After that, the program calculates the price and prints a receipt.

I chose this idea because it is simple, clear, and easy to apply Object-Oriented Programming and Design Patterns on it.

---

## Project Features

The system allows the user to:

* Create a new order.
* Choose a matcha drink.
* Choose the drink size.
* Add toppings.
* Choose a discount type.
* View the final receipt.
* View a summary of all orders.

---

## Technologies Used

* C#
* .NET Console Application

---

## Project Structure

The project is divided into folders to keep the code organized:

```text
MatchaBarApp
│
├── Program.cs
│
├── Enums
│   ├── DrinkSize.cs
│   └── Topping.cs
│
├── Models
│   ├── Order.cs
│   └── Drinks
│       ├── MatchaDrink.cs
│       ├── ClassicMatcha.cs
│       ├── StrawberryMatcha.cs
│       ├── VanillaMatcha.cs
│       ├── IcedMatchaLatte.cs
│       └── MangoMatcha.cs
│
├── Factories
│   ├── MatchaFactory.cs
│   └── DiscountFactory.cs
│
├── Strategies
│   ├── IDiscountStrategy.cs
│   ├── NoDiscount.cs
│   ├── StudentDiscount.cs
│   ├── HappyHourDiscount.cs
│   └── EmployeeDiscount.cs
│
├── Services
│   ├── OrderService.cs
│   ├── ReceiptPrinter.cs
│   └── ToppingPricing.cs
│
└── UI
    ├── ConsoleHelper.cs
    └── MatchaBarConsole.cs
```

---

## Folder Explanation

### Enums

This folder contains fixed options used in the project, such as drink sizes and toppings.

### Models

This folder contains the main classes of the system, such as `Order` and the drink classes.

### Factories

This folder contains the factory classes that are responsible for creating objects.

### Strategies

This folder contains the discount classes. Each class represents a different discount type.

### Services

This folder contains classes that handle the main logic, such as calculating prices and printing receipts.

### UI

This folder contains the console interface and user input methods.

---

## Object-Oriented Programming

This project applies OOP concepts in different parts of the code.

### Classes and Objects

The project has many classes, such as:

* `Order`
* `OrderService`
* `ReceiptPrinter`
* `ClassicMatcha`
* `StudentDiscount`

Each class has a specific role in the system.

### Inheritance

The drink classes inherit from the base class `MatchaDrink`.

For example:

```csharp
public class StrawberryMatcha : MatchaDrink
```

This helps avoid repeating common drink properties.

### Abstraction

The `MatchaDrink` class is abstract because it represents a general drink, not a specific one.

Each drink class gives its own description.

### Polymorphism

The program can deal with different drink types as `MatchaDrink`.

For example:

```csharp
MatchaDrink drink = MatchaFactory.CreateDrink(choice);
```

The actual drink can be Classic Matcha, Strawberry Matcha, Mango Matcha, or another type.

### Encapsulation

The `Order` class stores the order details in one place, such as the drink, size, toppings, and discount.

---

## Design Patterns Used

This project uses two design patterns:

---

## 1. Factory Pattern

The Factory Pattern is used to create matcha drinks.

Instead of creating drink objects directly in the console class, I used `MatchaFactory`.

Example:

```csharp
MatchaDrink drink = MatchaFactory.CreateDrink(drinkChoice);
```

The factory returns the correct drink based on the user choice.

For example:

* If the user chooses 1, it creates `ClassicMatcha`.
* If the user chooses 2, it creates `StrawberryMatcha`.
* If the user chooses 5, it creates `MangoMatcha`.

This makes the code cleaner because the object creation is separated from the user interface.

---

## 2. Strategy Pattern

The Strategy Pattern is used for discounts.

Each discount has its own class:

* `NoDiscount`
* `StudentDiscount`
* `HappyHourDiscount`
* `EmployeeDiscount`

All discount classes use the same interface:

```csharp
public interface IDiscountStrategy
{
    string Name { get; }
    decimal ApplyDiscount(decimal total);
}
```

This makes it easier to add a new discount later without changing the whole price calculation code.

---

## SOLID Principles

The project tries to apply SOLID principles in a simple way.

### Single Responsibility Principle

Each class has one main responsibility.

For example:

* `OrderService` calculates prices.
* `ReceiptPrinter` prints the receipt.
* `MatchaFactory` creates drink objects.
* `ConsoleHelper` handles console input.

### Open/Closed Principle

The project can be extended without changing a lot of existing code.

For example, to add a new drink, I can create a new drink class and add it to the factory.

### Liskov Substitution Principle

Any drink class that inherits from `MatchaDrink` can be used as a `MatchaDrink`.

For example, `ClassicMatcha` and `MangoMatcha` can both be used in the order.

### Interface Segregation Principle

The discount interface is small and only contains what the discount classes need.

### Dependency Inversion Principle

The order depends on the discount interface `IDiscountStrategy`, not on a specific discount class.

This makes the code more flexible.

---

## Clean Code

I tried to make the code clean by:

* Giving classes clear names.
* Dividing the code into folders.
* Keeping each class focused on one task.
* Avoiding putting everything inside `Program.cs`.
* Using enums for fixed choices.
* Separating the console interface from the calculation logic.

---

## How to Run the Project

Create the project:

```bash
dotnet new console -n MatchaBarApp
```

Go to the project folder:

```bash
cd MatchaBarApp
```

Run the project:

```bash
dotnet run
```

---

## Example Output

```text
====================================
        MATCHA BAR ORDERING SYSTEM
====================================
1. Create New Order
2. View Orders Summary
0. Exit

Choose an option: 1
```

Example receipt:

```text
====================================
             RECEIPT
====================================
Drink       : Strawberry Matcha
Description : Matcha latte with fresh strawberry flavor.
Size        : Medium
Toppings    : Boba, Oat Milk
Discount    : Student Discount 10%
------------------------------------
Subtotal    : 31.00 SAR
Saved       : 3.10 SAR
Total       : 27.90 SAR
====================================
Thank you for visiting Matcha Bar!
====================================
```

---

## Conclusion

This project is a simple matcha bar ordering system.
It uses C# console application and applies OOP, SOLID principles, Factory Pattern, and Strategy Pattern.

The main focus of the project is not the interface, but the way the code is organized and how the design patterns are applied.
