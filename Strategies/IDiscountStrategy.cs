namespace MatchaBarApp.Strategies;

public interface IDiscountStrategy
{
    string Name { get; }
    decimal ApplyDiscount(decimal total);
}