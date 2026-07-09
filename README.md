<div align="center">

# 🍵 Matcha Bar Ordering System

A simple C# console application for creating and managing matcha drink orders.

![C#](https://img.shields.io/badge/C%23-Console%20App-8A2BE2?style=for-the-badge&logo=csharp)
![.NET](https://img.shields.io/badge/.NET-Application-512BD4?style=for-the-badge&logo=dotnet)
![OOP](https://img.shields.io/badge/OOP-Applied-2E8B57?style=for-the-badge)
![Design Patterns](https://img.shields.io/badge/Design%20Patterns-Factory%20%7C%20Strategy-6B8E23?style=for-the-badge)

</div>

---

## 📌 Project Overview

**Matcha Bar Ordering System** is a console-based ordering application built using C#.

The system allows users to create matcha drink orders by selecting a drink, size, toppings, and discount type. After completing the order, the program calculates the subtotal, applies the selected discount, and prints a formatted receipt.

The main focus of this project is to apply:

- Object-Oriented Programming
- SOLID Principles
- Clean Code
- Factory Pattern
- Strategy Pattern

---

## ✨ Features

- Create a new matcha order.
- Choose from different matcha drinks.
- Select drink size: Small, Medium, or Large.
- Add optional toppings.
- Apply different discount types.
- Print a clear receipt.
- View all created orders.
- Calculate the grand total of orders.

---

## 🖥️ Console UI Preview

```text
====================================
        MATCHA BAR ORDERING SYSTEM
====================================
1. Create New Order
2. View Orders Summary
0. Exit

Choose an option:
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

## 🧾 Available Drinks

| #   | Drink             | Base Price |
| --- | ----------------- | ---------- |
| 1   | Classic Matcha    | 18 SAR     |
| 2   | Strawberry Matcha | 24 SAR     |
| 3   | Vanilla Matcha    | 22 SAR     |
| 4   | Iced Matcha Latte | 20 SAR     |
| 5   | Mango Matcha      | 25 SAR     |

---

## 🧋 Available Toppings

| Topping         | Price |
| --------------- | ----- |
| Boba            | 4 SAR |
| Oat Milk        | 3 SAR |
| Vanilla Syrup   | 2 SAR |
| Strawberry Foam | 5 SAR |
| Extra Matcha    | 4 SAR |

---

## 🏷️ Discount Options

| Discount Type       | Percentage |
| ------------------- | ---------- |
| No Discount         | 0%         |
| Student Discount    | 10%        |
| Happy Hour Discount | 15%        |
| Employee Discount   | 20%        |

---

## 🧱 Project Structure

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

## 📂 Folder Description

| Folder       | Description                                                             |
| ------------ | ----------------------------------------------------------------------- |
| `Enums`      | Contains fixed options such as drink size and toppings.                 |
| `Models`     | Contains the main system objects such as orders and drinks.             |
| `Factories`  | Contains classes responsible for creating objects.                      |
| `Strategies` | Contains different discount behaviors.                                  |
| `Services`   | Contains business logic such as price calculation and receipt printing. |
| `UI`         | Contains console menus and input handling.                              |

---

## 🎯 Object-Oriented Programming

This project applies OOP concepts through the main classes and their relationships.

### Classes and Objects

The system is divided into multiple classes, where each class has a clear role.

Examples:

- `Order`
- `OrderService`
- `ReceiptPrinter`
- `MatchaDrink`
- `StudentDiscount`

---

### Inheritance

All drink classes inherit from the abstract class `MatchaDrink`.

```csharp
public class StrawberryMatcha : MatchaDrink
```

This helps share common drink properties while allowing each drink to have its own details.

---

### Abstraction

`MatchaDrink` is an abstract class because it represents the general idea of a drink.

```csharp
public abstract class MatchaDrink
{
    public string Name { get; }
    public decimal BasePrice { get; }

    public abstract string GetDescription();
}
```

Each specific drink class provides its own description.

---

### Polymorphism

The system can treat different drink types as one general type, which is `MatchaDrink`.

```csharp
MatchaDrink drink = MatchaFactory.CreateDrink(drinkChoice);
```

The actual object can be `ClassicMatcha`, `StrawberryMatcha`, `MangoMatcha`, or any other drink class.

---

### Encapsulation

The `Order` class keeps order details together in one place, including:

- Drink
- Size
- Toppings
- Discount strategy

---

## 🧩 Design Patterns

This project uses two design patterns: **Factory Pattern** and **Strategy Pattern**.

---

## 1. Factory Pattern

The Factory Pattern is used to create drink objects based on the user's choice.

Instead of creating drinks directly inside the console UI, the project uses `MatchaFactory`.

```csharp
MatchaDrink drink = MatchaFactory.CreateDrink(drinkChoice);
```

The factory returns the correct drink object.

Example:

- Choice 1 creates `ClassicMatcha`
- Choice 2 creates `StrawberryMatcha`
- Choice 5 creates `MangoMatcha`

### Why it was used

The Factory Pattern helps separate object creation from the user interface.
It also makes the project easier to extend when adding new drink types.

---

## 2. Strategy Pattern

The Strategy Pattern is used for applying discounts.

All discount classes follow the same interface:

```csharp
public interface IDiscountStrategy
{
    string Name { get; }
    decimal ApplyDiscount(decimal total);
}
```

Discount classes:

- `NoDiscount`
- `StudentDiscount`
- `HappyHourDiscount`
- `EmployeeDiscount`

Example usage:

```csharp
decimal total = order.DiscountStrategy.ApplyDiscount(subtotal);
```

### Why it was used

The discount behavior changes depending on the selected discount type.
Using Strategy Pattern keeps each discount calculation in a separate class and avoids long `if-else` statements.

---

## ✅ SOLID Principles

The project applies SOLID principles in a simple and practical way.

### Single Responsibility Principle

Each class has one main responsibility.

Examples:

| Class            | Responsibility                     |
| ---------------- | ---------------------------------- |
| `OrderService`   | Calculates subtotal and total.     |
| `ReceiptPrinter` | Prints the receipt.                |
| `MatchaFactory`  | Creates drink objects.             |
| `ConsoleHelper`  | Handles common console operations. |

---

### Open/Closed Principle

The system can be extended without changing many existing classes.

For example:

- A new drink can be added by creating a new drink class.
- A new discount can be added by creating a new discount strategy class.

---

### Liskov Substitution Principle

Any class that inherits from `MatchaDrink` can be used wherever `MatchaDrink` is expected.

For example:

```csharp
MatchaDrink drink = new MangoMatcha();
```

The system will still work correctly.

---

### Interface Segregation Principle

The discount interface is small and focused.
It only includes the members needed by discount classes.

---

### Dependency Inversion Principle

The `Order` class depends on the discount abstraction `IDiscountStrategy`, not on a specific discount class.

```csharp
public IDiscountStrategy DiscountStrategy { get; }
```

This makes the order flexible because it can work with any discount strategy.

---

## 🧼 Clean Code Practices

The project follows clean code practices by:

- Using clear class names.
- Using clear method names.
- Dividing the project into folders.
- Keeping each class focused on one task.
- Separating UI logic from business logic.
- Avoiding placing all code inside `Program.cs`.
- Using enums for fixed choices.
- Reducing repeated code.

---

## 🚀 How to Run

Clone the repository:

```bash
git clone https://github.com/wejdanturki7/MatchaBarApp.git
```

Go to the project folder:

```bash
cd MatchaBarApp
```

Run the application:

```bash
dotnet run
```

---

## 🛠️ Requirements

- .NET SDK
- Code editor such as Visual Studio Code or Visual Studio

---

## 💡 Future Improvements

Possible improvements for future versions:

- Add a simple graphical interface.
- Save orders to a file.
- Add admin options to manage drinks.
- Add more discount types.
- Add payment methods.
- Generate daily sales reports.

---

## 📍 Conclusion

This project is a simple matcha bar ordering system built as a C# console application.

The goal was to create a small but organized project that applies OOP, SOLID principles, Clean Code, Factory Pattern, and Strategy Pattern in a clear way.

The console interface is kept simple, while the code structure focuses on readability, maintainability, and separation of responsibilities.

---

<div align="center">

**Made with 🍵 using C#**

</div>
