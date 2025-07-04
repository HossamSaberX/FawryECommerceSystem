class ShippingService
{
    public double ShippingCost { get; set; }

    public ShippingService(double shippingCost)
    {
        ShippingCost = shippingCost;
    }

    public void ship(List<Shippable> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products to ship.");
            return;
        }
        Console.WriteLine("** Shipment notice **");

        double totalWeight = 0;
        foreach (var product in products)
        {
            totalWeight += product.getWeight();
            Console.WriteLine($"Shipping {product.getName()} with weight {product.getWeight()} kg.");
        }

        Console.WriteLine($"Shipping {products.Count} products with a total weight of {totalWeight} kg.");
        Console.WriteLine($"Total shipping cost: {ShippingCost}");
    }
}