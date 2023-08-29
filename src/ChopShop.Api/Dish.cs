namespace ChopShop.Api;

public class Dish
{
    public string Name { get; }

    public decimal Price { get; }

    public Dish(string name, decimal price)
    {
        Name = name ?? throw new ArgumentException(null, nameof(name));
        Price = price;
    }
}