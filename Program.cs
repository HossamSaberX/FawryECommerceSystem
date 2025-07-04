public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Fawry E-Commerce System ---");

        Console.WriteLine("\nSetting up inventory...");
        
        var cheese = new ShippableExpirable("Cheese", 100, 15, 0.4, DateTime.Now.AddDays(30));
        var tv = new Shippable("4K TV", 8500, 5, 12.5);
        var biscuits = new ShippableExpirable("Biscuits", 50, 30, 0.7, DateTime.Now.AddDays(90));
        var scratchCard = new Product("Mobile Scratch Card", 25, 100);
        var expiredMilk = new Expirable("Expired Milk", 15, 10, DateTime.Now.AddDays(-5));

        Console.WriteLine("Inventory ready.\n");


        // Use Case 1: Successful Purchase
        Console.WriteLine("--- Use Case 1: Successful Customer Checkout ---");
        var customer1 = new Customer(10000);
        customer1.add(cheese, 2);
        customer1.add(tv, 1);
        customer1.add(biscuits, 3);
        customer1.add(scratchCard, 4);
        customer1.checkout();
        Console.WriteLine($"Remaining Cheese stock: {cheese.Quantity}");
        Console.WriteLine($"Remaining TV stock: {tv.Quantity}");
        Console.WriteLine($"Remaining Biscuits stock: {biscuits.Quantity}");
        Console.WriteLine("------------------------------------------\n");


        // Use Case 2: Validation Scenarios during Shopping
        Console.WriteLine("--- Use Case 2: Add to Cart Validations(expired and not enough stock) ---");
        var customer2 = new Customer(500);
        customer2.add(tv, 99);
        customer2.add(expiredMilk, 1);
        Console.WriteLine("------------------------------------------\n");


        // Use Case 3: Checkout with Insufficient Balance
        Console.WriteLine("--- Use Case 3: Checkout with Insufficient Balance ---");
        customer2.add(tv, 1);
        customer2.checkout();
        Console.WriteLine("------------------------------------------\n");


        // Use Case 4: Checkout with an Empty Cart
        Console.WriteLine("--- Use Case 4: Checkout with an Empty Cart ---");
        var customer3 = new Customer(1000);
        customer3.checkout();
        Console.WriteLine("------------------------------------------\n");
    }
}
