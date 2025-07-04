class ShippableExpirable : Product, IShippable, IExpirable
{
    public double Weight { get; set; }
    public DateTime ExpirationDate { get; set; }

    public double getWeight() => Weight;
    public string getName() => Name;
    public DateTime getExpirationDate() => ExpirationDate;

    public ShippableExpirable(string name, double price, int quantity, double weight, DateTime expirationDate) : base(name, price, quantity)
    {
        Weight = weight;
        ExpirationDate = expirationDate;
    }
    
    public bool isExpired() => DateTime.Now > ExpirationDate;
}