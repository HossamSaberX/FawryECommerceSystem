class ShippingService
{
    public double ShippingCost { get; set; }

    public ShippingService(double shippingCost)
    {
        ShippingCost = shippingCost;
    }

    public void ship(Dictionary<Product, int> cart)
    {
        
        Console.WriteLine("** Shipment notice **");
        
        double totalWeight = 0;
        foreach (var item in cart)
        {
            if (item.Key is IShippable shippable)
            {
                int quantity = item.Value;
                double itemWeight = shippable.getWeight();
                totalWeight += itemWeight * quantity;
                
                Console.WriteLine($"{quantity}x {shippable.getName()} {(int)(itemWeight * 1000)}g");
            }
        }
        
        Console.WriteLine($"Total package weight {totalWeight}kg");
    }
}