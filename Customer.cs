class Customer
{
    public Dictionary<Product, int> cart;
    public double Balance { get; set; }

    public Customer(double balance)
    {
        Balance = balance;
        cart = new Dictionary<Product, int>();

    }
    bool isEmpty() => cart.Count == 0;

    public void add(Product product, int quantity)
    {
        if (product.Quantity < quantity)
        {
            Console.WriteLine($"Not enough stock for {product.Name}. Available: {product.Quantity}, Requested: {quantity}");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }


        if (cart.ContainsKey(product)) cart[product] += quantity;
        else cart[product] = quantity;
    }

    public double totalPrice()
    {
        double total = 0;
        foreach (var item in cart) total += item.Key.Price * item.Value;
        return total;
    }
    
    private List<Shippable> getShippableProducts()
    {
        List<Shippable> shippables = new List<Shippable>();
        foreach (var item in cart)
        {
            if (item.Key is Shippable shippable)
            {
                shippables.Add(shippable);
            }
        }
        return shippables;
    }

    private double processShipping(List<Shippable> shippables)
    {
        if (shippables.Count > 0)
        {
            ShippingService shippingService = new ShippingService(50);
            shippingService.ship(shippables);
            return shippingService.ShippingCost;
        }
        else
        {
            Console.WriteLine("No shippable products in cart.");
            return 0;
        }
    }

    public void checkout()
    {
        if (isEmpty())
        {
            Console.WriteLine("Cart is empty.");
            return;
        }

        double total = totalPrice();
        var shippables = getShippableProducts();
        double shippingCost = processShipping(shippables);
        double grandTotal = total + shippingCost;

        if (Balance < grandTotal)
        {
            Console.WriteLine($"Not enough balance. Required: {grandTotal}, Available: {Balance}");
            return;
        }

        Balance -= grandTotal;

        Console.WriteLine($"Order total: {total}");
        Console.WriteLine($"Shipping cost: {shippingCost}");
        Console.WriteLine($"Grand total: {grandTotal}");
        Console.WriteLine($"Remaining balance: {Balance}");
        cart.Clear();
    }

}