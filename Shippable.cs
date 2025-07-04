class Shippable : Product, IShippable
{
    public double Weight { get; set; }

    public double getWeight()
    {
        return Weight;
    }

    public string getName()
    {
        return Name;
    }

    public Shippable(string name, double price, int quantity, double weight) : base(name, price, quantity)
    {
        Weight = weight;
    }
}