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

        if (product is IExpirable expirableProduct && expirableProduct.isExpired())
        {
            Console.WriteLine($"expired item {product.Name}.");
            return;
        }

        if (cart.ContainsKey(product)) cart[product] += quantity;
        else cart[product] = quantity;
        product.updateQuantity(quantity);
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

    private double processShipping()
    {
        var shippables = getShippableProducts();
        if (shippables.Count > 0)
        {
            ShippingService shippingService = new ShippingService(30);
            shippingService.ship(cart);
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

        double shippingCost = processShipping();
        double subtotal = totalPrice();
        double amount = subtotal + shippingCost;

        if (Balance < amount)
        {
            Console.WriteLine($"Not enough balance. Required: {amount}, Available: {Balance}");
            return;
        }

        Balance -= amount;

        Console.WriteLine("** Checkout receipt **");
        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Value}x {item.Key.Name} {item.Key.Price * item.Value}");
        }
        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal {subtotal}");
        Console.WriteLine($"Shipping {shippingCost}");
        Console.WriteLine($"Amount {amount}");
        
        cart.Clear();
    }

}